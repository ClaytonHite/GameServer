using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Game_Server;
using Game_Server.AIPathfinding;
using Game_Server.PlayerInteractions;

namespace Game_Server
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }

        }
        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }
        public static void Welcome(int _toClient, string _msg)
        {
            // packet class inherits from Idisposable so needs to be dispose of when done
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);
                _packet.Write(TileMap.MainMap);
                _packet.Write(TileMap.mapSize);
                SendTCPData(_toClient, _packet);
            }
        }

        public static void PopulatePlayersOnAccount(int _toClient, string _characters, bool _bool)
        {
            // packet class inherits from Idisposable so needs to be dispose of when done
            using (Packet _packet = new Packet((int)ServerPackets.characterSelect))
            {
                _packet.Write(_toClient);
                _packet.Write(_characters);
                _packet.Write(_bool);

                SendTCPData(_toClient, _packet);

            }
        }
        public static void WrongAccountorPassword(int _toClient, int _connectionAttempts)
        {
            using (Packet _packet = new Packet((int)ServerPackets.wrongAccountorPassword))
            {
                _packet.Write(_toClient);
                _packet.Write(false);
                _packet.Write((int)_connectionAttempts);

                SendTCPData(_toClient, _packet);

            }
        }
        public static void PopulateMonsters(int _toClient)
        {
            string monsters = Monster.MonsterDataString();
            using (Packet _packet = new Packet((int)ServerPackets.PopulateMonsters))
            {
                _packet.Write(_toClient);
                _packet.Write(monsters);

                SendTCPData(_toClient, _packet);
            }
        }
        public static void MonsterUpdate(bool respawn, string monsterData, int damage, int damageFrom)
        {
            string monsters = Monster.MonsterDataString();
            using (Packet _packet = new Packet((int)ServerPackets.MonsterUpdate))
            {
                _packet.Write(respawn);
                _packet.Write(monsterData);
                _packet.Write(damage);
                _packet.Write(damageFrom);

                SendTCPDataToAll(_packet);
            }
        }
        public static void UpdateMonsterPosition(int monsterID, Vector2 monsterPosition)
        {
            using (Packet _packet = new Packet((int)ServerPackets.UpdateMonsterPosition))
            {
                _packet.Write(monsterID);
                _packet.Write(monsterPosition);

                SendTCPDataToAll(_packet);
            }
        }
        public static void PlayerDamageDone(int monsterID, int damage, Vector2 position, int damageFrom)
        {
            using (Packet _packet = new Packet((int)ServerPackets.PlayerDamageDone))
            {
                _packet.Write(monsterID);
                _packet.Write(damage);
                _packet.Write(position);
                _packet.Write(damageFrom);

                SendTCPDataToAll(_packet);
            }
        }
        public static void MonsterDamageDone(int monsterID, int damage, Vector2 position, int _toClient)
        {
            using (Packet _packet = new Packet((int)ServerPackets.MonsterDamageDone))
            {
                _packet.Write(monsterID);
                _packet.Write(damage);
                _packet.Write(position);
                _packet.Write(_toClient);
                _packet.Write(Player.players[_toClient].currentHitPoints);

                SendTCPDataToAll(_packet);
            }
        }
        public static void CreateAccount(int _toClient, bool _create)
        {
            // packet class inherits from Idisposable so needs to be dispose of when done
            using (Packet _packet = new Packet((int)ServerPackets.CreateAccount))
            {
                _packet.Write(_toClient);
                _packet.Write(_create);

                SendTCPData(_toClient, _packet);

            }
        }
        public static void CreatePlayer(int _toClient, bool _createCharacter)
        {
            using (Packet _packet = new Packet((int)ServerPackets.CreateCharacter))
            {
                _packet.Write(_toClient);
                _packet.Write(_createCharacter);

                SendTCPData(_toClient, _packet);

            }
        }
        public static void SpawnPlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.spawnPosition);
                _packet.Write(_player.playerLevel);
                _packet.Write(_player.playerAvatar);
                _packet.Write(_player.currentHitPoints);
                _packet.Write(_player.maxHitPoints);
                _packet.Write(_player.currentManaPoints);
                _packet.Write(_player.maxManaPoints);
                _packet.Write(_player.playerRace);
                _packet.Write(_player.playerClass);
                _packet.Write(_player.playerStrength);
                _packet.Write(_player.playerDexterity);
                _packet.Write(_player.playerConstitution);
                _packet.Write(_player.playerIntellect);
                _packet.Write(_player.playerWisdom);
                _packet.Write(_player.playerCharisma);
                _packet.Write(_player.playerCarryingWeight);
                _packet.Write(_player.playerExperience);
                _packet.Write(_player.playerSkillPoints);
                _packet.Write(_player.isStealth);
                _packet.Write(_player.ExperienceRequired);
                _packet.Write(_player.PreviousExperienceRequired);

                SendTCPData(_toClient, _packet);
                TargetFinder.Update(_player);
            }
        }

        public static void UpdatePlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.updatePlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.position);
                _packet.Write(_player.playerLevel);
                _packet.Write(_player.currentHitPoints);
                _packet.Write(_player.maxHitPoints);
                _packet.Write(_player.currentManaPoints);
                _packet.Write(_player.maxManaPoints);
                _packet.Write(_player.playerStrength);
                _packet.Write(_player.playerDexterity);
                _packet.Write(_player.playerConstitution);
                _packet.Write(_player.playerIntellect);
                _packet.Write(_player.playerWisdom);
                _packet.Write(_player.playerCharisma);
                _packet.Write(_player.playerCarryingWeight);
                _packet.Write(_player.playerExperience);
                _packet.Write(_player.playerSkillPoints);
                _packet.Write(_player.isStealth);
                _packet.Write(_player.ExperienceRequired);
                _packet.Write(_player.PreviousExperienceRequired);

                SendTCPData(_toClient, _packet);
                TargetFinder.Update(_player);
            }
        }

        public static void RejectPlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerPosition(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.position);

                SendUDPDataToAll(_packet);
            }
        }
        public static void ChatBox(int _fromId, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.ChatBox))
            {
                _packet.Write(_fromId);
                _packet.Write(_msg);

                SendTCPDataToAll(_packet);
            }
        }
    }
}
