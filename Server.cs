using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Game_Server;
using Game_Server.PlayerInteractions;
using Game_Server.AIPathfinding;

namespace Game_Server
{
    class Server
    {
        public static int MaxPlayers { get; private set; }
        public static int Port { get; private set; }
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public static Dictionary<int, PacketHandler> packetHandlers;
        private static TcpListener tcpListener;
        private static UdpClient udpListener;

        public static void Start(int _maxPlayers, int _port)
        {
            MaxPlayers = _maxPlayers;
            Port = _port;

            Console.WriteLine(DateTime.Now + $" -- Starting Server...");
            InitializeServerData();
            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            udpListener = new UdpClient(Port);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            Console.WriteLine(DateTime.Now + $" -- Server started on port = {Port}.");
            Console.WriteLine(DateTime.Now + $" -- Dice rolls Initialized... Rolled {Dice.D20Die()}.");
        }

        private static void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine(DateTime.Now + $" -- Incoming connection from {_client.Client.RemoteEndPoint}...");

            for (int i = 1; i <= MaxPlayers; i++)
            {
                if (clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(_client);
                    return;
                }
            }

            Console.WriteLine(DateTime.Now + $" -- {_client.Client.RemoteEndPoint} failed to connect to the server: Server is Full!");
        }

        private static void UDPReceiveCallback(IAsyncResult _result)
        {
            try
            {
                IPEndPoint _clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] _data = udpListener.EndReceive(_result, ref _clientEndPoint);
                udpListener.BeginReceive(UDPReceiveCallback, null);

                if (_data.Length < 4)
                {
                    return;
                    //MAY NEED ADDITIONAL CHECKS HERE!
                }

                using (Packet _packet = new Packet(_data))
                {
                    int _clientId = _packet.ReadInt();

                    if (_clientId == 0)
                    {
                        return;
                    }

                    if (clients[_clientId].udp.endPoint == null)
                    {
                        clients[_clientId].udp.Connect(_clientEndPoint);
                        return;
                    }

                    if (clients[_clientId].udp.endPoint.ToString() == _clientEndPoint.ToString())
                    {
                        clients[_clientId].udp.HandleData(_packet);
                    }
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine(DateTime.Now + $" -- Error receiving UDP data: {_ex}");
            }
        }

        public static void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet)
        {
            try
            {
                if (_clientEndPoint != null)
                {
                    udpListener.BeginSend(_packet.ToArray(), _packet.Length(), _clientEndPoint, null, null);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine(DateTime.Now + $" -- Error sending data to {_clientEndPoint} via UDP: {_ex}");
            }
        }

        private static void InitializeServerData()
        {
            TileMap.LoadMap();
            GameObject.onLoad();
            TileMap.OnLoad();
            MonsterManager.LoadMonsters();
            RandomNumberGenerator.Start();
            PlayerStatModifiers.LoadStatMods();
            for (int i = 1; i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
                { (int)ClientPackets.login, ServerHandle.Login },
                { (int)ClientPackets.characterSelect, ServerHandle.CharacterSelect },
                { (int)ClientPackets.playerMovement, ServerHandle.PlayerMovement },
                { (int)ClientPackets.createAccount, ServerHandle.CreateAccount },
                { (int)ClientPackets.CreateCharacter, ServerHandle.CreateCharacter },
                { (int)ClientPackets.playerCombat, ServerHandle.PlayerCombat },
                { (int)ClientPackets.addSkill, ServerHandle.AddSkill },
                { (int)ClientPackets.CharacterToDelete, ServerHandle.CharacterToDelete },
                { (int)ClientPackets.AccountToDelete, ServerHandle.AccountToDelete },
                { (int)ClientPackets.ChatBox, ServerHandle.ChatBox }
            };
            Console.WriteLine(DateTime.Now + $" -- Initialized packets.");
        }
    }
}
