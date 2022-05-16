using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    class MonsterData
    {
        public static int MonsterStatCount = 16;
        public static Monster GetMonster(int image, int posX, int posY)
        {
            Vector2 pos = new Vector2(posX, posY);
            Monster monster = new Monster();
            monster.collider.Position = pos;
            if (image == 500)
            {
                monster.monsterName = "Rat";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 1;
                monster.monsterAvatar = image;
                monster.monsterRace = "Rodent";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 10;
                monster.maxHitPoints = 10;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 10000;
                return monster;
            };
            if (image == 501)
            {
                monster.monsterName = "Giant Rat";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 3;
                monster.monsterAvatar = image;
                monster.monsterRace = "Rodent";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 20;
                monster.maxHitPoints = 20;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 10;
                return monster;
            };
            if (image == 502)
            {
                monster.monsterName = "Goblin";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 5;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 40;
                monster.maxHitPoints = 40;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 45;
                return monster;
            };
            if (image == 503)
            {
                monster.monsterName = "Goblin Warrior";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 7;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 65;
                monster.maxHitPoints = 65;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 65;
                return monster;
            };
            if (image == 504)
            {
                monster.monsterName = "Orc";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 9;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 100;
                monster.maxHitPoints = 100;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 75;
                return monster;
            };
            if (image == 505)
            {
                monster.monsterName = "Orc Warrior";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 11;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 120;
                monster.maxHitPoints = 120;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 200;
                return monster;
            };
            if (image == 506)
            {
                monster.monsterName = "Orc Leader";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 20;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 150;
                monster.maxHitPoints = 150;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 250;
                return monster;
            };
            if (image == 507)
            {
                monster.monsterName = "Minotaur";
                monster.monsterStrength = 10;
                monster.monsterDexterity = 10;
                monster.monsterConstitution = 10;
                monster.monsterIntellect = 10;
                monster.monsterWisdom = 10;
                monster.monsterCharisma = 10;
                monster.monsterLevel = 10;
                monster.monsterAvatar = image;
                monster.monsterRace = "Humanoid";
                monster.monsterClass = "Fighter";
                monster.currentHitPoints = 120;
                monster.maxHitPoints = 120;
                monster.currentManaPoints = 0;
                monster.maxManaPoints = 0;
                monster.monsterPosition = pos;
                monster.spawnPosition = pos;
                monster.monsterExperienceGiven = 100;
                return monster;
            };
            return monster;
        }
    }
}
