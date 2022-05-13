using System;
using System.Collections.Generic;
using System.Text;
using Game_Server;
using System.Numerics;
using System.Xml;
using System.Xml.Linq;
using Game_Server.PlayerInteractions;

namespace Game_Server
{
    class ServerHandle
    {
        #region Login
        public static void CharacterSelect(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();
            string _password = _packet.ReadString();
            string _character = _packet.ReadString();
            List<int> _characterStats = DatabaseManager.GetPlayerStats(_character);
            List<string> _characterInfo = DatabaseManager.GetPlayerInfo(_character);
            if (_fromClient != _clientIdCheck && _character != null)
            {
                Console.WriteLine(DateTime.Now + $" -- Player \"{_username}\" (ID: {_fromClient} has assumed the wrong client ID ({_clientIdCheck})!!");
                Server.clients[_fromClient].Disconnect();
            }
            else
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- {_username} connected with player name: {_character} and is now player {_fromClient}.");

                Server.clients[_fromClient].SendIntoGame(_character, _characterStats, _characterInfo);
            }
        }

        public static void CharacterSelection(int _fromClient, string _username, string _password, bool _bool)
        {

            List<String> PlayersOnAccount = ReadPlayersXML(_username, _password);
            if (PlayersOnAccount.Count >= 1)
            {
                //converts the list we got to a string to send back to client
                string Characters = string.Join(",", PlayersOnAccount.ToArray());
                ServerSend.PopulatePlayersOnAccount(_fromClient, Characters, _bool);
                ServerSend.PopulateMonsters(_fromClient);
            }
            else
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- No players on account to deliver.");
                ServerSend.PopulatePlayersOnAccount(_fromClient, "No Characters", _bool);
            }
        }

        public static void Login(int _fromClient, Packet _packet)
        {
            //TODO CHANGES WELCOME RECEIVED TO MINIMUM DATA PASSAGE AND REWRITE NEW PACKET TO SEND THE CLIENTS INFO. 
            //always pass data the order that we wrote it
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();
            string _password = _packet.ReadString();
            bool _bool = DatabaseManager.ReadAccountXML(_username, _password);

            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine(DateTime.Now + $" -- Player \"{_username}\" (ID: {_fromClient} has assumed the wrong client ID ({_clientIdCheck})!!");
                Server.clients[_fromClient].Disconnect();
            }
            if (_bool)
            {
                CharacterSelection(_fromClient, _username, _password, _bool);
            }
            if (!_bool)
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- Entered the wrong information.");
                CharacterSelection(_fromClient, _username, _password, _bool);
                Server.clients[_fromClient].Disconnect();
            }

        }
        public static void CreateAccount(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();
            string _password = _packet.ReadString();
            bool _createAccountBool = DatabaseManager.ReadCreateAccountXML(_username, _password);
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine(DateTime.Now + $" -- Player \"{_username}\" (ID: {_fromClient} has assumed the wrong client ID ({_clientIdCheck})!!");
                Server.clients[_fromClient].Disconnect();
            }
            if (_createAccountBool)
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- Tried to create an account that already exists.");
                ServerSend.CreateAccount(_fromClient, false);
            }
            if (!_createAccountBool)
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- has made a new account!");
                ServerSend.CreateAccount(_fromClient, true);
                DatabaseManager.WriteAccountXML(_username, _password);
            }
        }

        public static void CreateCharacter(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();
            string _password = _packet.ReadString();
            string _characterName = _packet.ReadString();
            string _Race = _packet.ReadString();
            string _Class = _packet.ReadString();
            string _Avatar = $"{_packet.ReadInt()}";

            List<string> _characterInfo = new List<string>() { _Race, _Class, _Avatar };

            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine(DateTime.Now + $" -- Player \"{_username}\" (ID: {_fromClient} has assumed the wrong client ID ({_clientIdCheck})!!");
                Server.clients[_fromClient].Disconnect();
            }
            if (DatabaseManager.ReadCreateCharacterXML(_characterName, _username, _characterInfo))
            {
                DatabaseManager.WritePlayerXML(_characterName, _username, _characterInfo);
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- Created a new Character with the name {_characterName}.");
                ServerSend.CreatePlayer(_fromClient, true);
            }
            else
            {
                Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} -- Tried to make a character with a name that already exists.");
                ServerSend.CreatePlayer(_fromClient, false);
            }

        }

        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            //TODO CHANGES WELCOME RECEIVED TO MINIMUM DATA PASSAGE AND REWRITE NEW PACKET TO SEND THE CLIENTS INFO. 
            //always pass data the order that we wrote it
            //----------------check client version or check how many times spammed to login------------------
            int _clientIdCheck = _packet.ReadInt();
            float _clientVersion = _packet.ReadFloat();
            Console.WriteLine(DateTime.Now + $" -- {Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} has connected with ID : {_clientIdCheck} and client version {_clientVersion}.");
        }
        public static List<string> ReadPlayersXML(string _username, string _password)
        {
            XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
            IEnumerable<XElement> elements = doc.Descendants();
            List<string> Players = new List<string>();
            foreach (XElement element in elements)
            {
                if (element.Name == "Account")
                {
                    IEnumerable<XAttribute> attribute = element.Attributes();
                    foreach (XAttribute eleAttri in attribute)
                    {
                        if (eleAttri.Value == _username)
                        {
                            XElement root = element;
                            foreach (XElement ele in root.Elements())
                            {
                                XAttribute attributes = ele.FirstAttribute;
                                Players.Add(Convert.ToString(attributes.Value));
                                while ((attributes = attributes.NextAttribute) != null)
                                {
                                    Players.Add(Convert.ToString(attributes.Value));
                                }
                            }
                        }
                    }
                }
            }
            return Players;
        }
        #endregion
        #region PlayerInput
        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            Vector2 location = _packet.ReadVector2();
            Server.clients[_fromClient].player.MovePlayerLocation(location, _fromClient);
        }
        public static void ChatBox(int _fromClient, Packet _packet)
        {
            int _clientId = _packet.ReadInt();
            string _msg = _packet.ReadString();
            string _sendmsg = $"{DateTime.Now.ToShortTimeString()} -- {_msg}";
            Console.WriteLine(DateTime.Now + $" -- {_msg}");
            ServerSend.ChatBox(_clientId, _sendmsg);
        }
        public static void PlayerCombat(int _fromClient, Packet _packet)
        {
            int monsterId = _packet.ReadInt();
            Vector2 monsterLocation = _packet.ReadVector2();
            PlayerInteractions.Combat.PlayerAttack(_fromClient, monsterId, monsterLocation);
        }
        public static void AddSkill(int _fromClient, Packet _packet)
        {
            int skill = _packet.ReadInt();
            AddSkills.StatRoll(_fromClient, skill);
        }
        #endregion
    }
}