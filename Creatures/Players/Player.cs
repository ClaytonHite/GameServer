using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Timers;
using Game_Server.PlayerInteractions;
using Game_Server.AIPathfinding;

namespace Game_Server
{
    public class Player
    {
        public bool isMoving = false;
        public int id;
        public string username;
        public Vector2 position;
        public int playerLevel;
        public string playerAvatar;
        public int currentHitPoints;
        public int maxHitPoints;
        public int currentManaPoints;
        public int maxManaPoints;
        public Vector2 currentLocation;
        public string playerRace;
        public string playerClass;
        public int playerStrength;
        public int playerDexterity;
        public int playerConstitution;
        public int playerIntellect;
        public int playerWisdom;
        public int playerCharisma;
        public Vector2 spawnPosition;
        //
        public int playerExperience;
        public int playerCarryingWeight;
        public int playerSkillPoints;
        public bool playerBusy;
        public bool isStealth;
        public bool playerAttacking;
        public bool playerMoving;
        //
        public long ExperienceRequired;
        public long PreviousExperienceRequired;
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();

        //Player.players[ClientID].username gets the name of the player
        public Player(int _id, string _username, List<int> _characterStats, List<string> _characterInfo)
        {
            id = _id;
            username = _username;
            playerStrength = _characterStats[0];
            playerDexterity = _characterStats[1];
            playerConstitution = _characterStats[2];
            playerIntellect = _characterStats[3];
            playerWisdom = _characterStats[4];
            playerCharisma = _characterStats[5];
            playerLevel = Convert.ToInt32(_characterInfo[0]);
            playerAvatar = _characterInfo[1];
            playerRace = _characterInfo[2];
            playerClass = _characterInfo[3];
            currentHitPoints = Convert.ToInt32(_characterInfo[4]);
            maxHitPoints = Convert.ToInt32(_characterInfo[5]);
            currentManaPoints = Convert.ToInt32(_characterInfo[6]);
            maxManaPoints = Convert.ToInt32(_characterInfo[7]);
            string[] splitLocation = _characterInfo[8].Split(':');
            int x = Convert.ToInt32(splitLocation[0]);
            int y = Convert.ToInt32(splitLocation[1]);
            playerCarryingWeight = Convert.ToInt32(_characterInfo[9]);
            playerExperience = Convert.ToInt32(_characterInfo[10]);
            playerSkillPoints = Convert.ToInt32(_characterInfo[11]);
            currentLocation.X = x;
            currentLocation.Y = y;
            spawnPosition = currentLocation;
            position = currentLocation;
            playerBusy = false;
            playerMoving = false;
            isStealth = false;
            ExperienceRequired = (long)LevelUp.ExperienceTableForLevel(playerLevel);
            PreviousExperienceRequired = (long)LevelUp.ExperienceTableForLevel(playerLevel - 1);
            if ((_characterInfo[12]) == "true")
            {
                isStealth = true;
            }
            playerAttacking = false;
            if (players.ContainsKey(_id))
            {
                players.Remove(_id);
            }
            players.Add(_id, this);
        }

        public void Update()
        {

        }
        public void MovePlayerLocation(Vector2 location, int _fromClient)
        {
            if (players[_fromClient].playerMoving == false)
            {
                players[_fromClient].playerMoving = true;
                Task.Run(async delegate
                {
                    await Task.Delay((1000 / (1 + (players[_fromClient].playerDexterity / 50))));
                    players[_fromClient].playerMoving = false;
                });
                TargetFinder.Update(players[_fromClient]);
                currentLocation = location;
                position = location;
            }
            ServerSend.PlayerPosition(this);
        }
    }
}
