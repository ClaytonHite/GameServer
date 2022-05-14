
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public class TileMap
    {
        public static int mapSize = 1000;
        public static string MainMap = "";
        public static string mapFilePath = "C:/Users/Clayt/Desktop/TestMap.txt";
        public static string[,] InitializeMainMap;
        public static string[] LoadFile;
        public static string[] mapTileNames = { "Grass", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DirtRoad", "DungeonFortress", "DungeonTower", "MainCity", "DeadTree", "GreenTree", "TealTree", "MapleTree", "Autumn Tree", "RedoTree", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "CobblestoneRoad", "DoubleCabin", "Cabin", "TripleCabin", "MowedGrass", "Water", "SandWaterSW", "SandWaterSE", "SandWaterNE", "SandWaterNW", "Sand", "GrassWaterNW", "GrassWaterSW", "GrassWaterSE", "GrassWaterNE", "MountainSnow", "Mountain", "Mountain", "Mountain", "CaveEntrance", "MountainSnow" };
        static string[] mapTileColliders = { "Water", "Mountain" };
        public static void LoadMap()
        {
            MainMap = File.ReadAllText(mapFilePath);
            LoadFile = MainMap.Split(':');
            InitializeMainMap = new string[mapSize, mapSize];
            for (int i = 0; i < LoadFile.Length; i++)
            {
                int posY = i / mapSize;
                int posX = i % mapSize;
                InitializeMainMap[posY, posX] = LoadFile[i];
            }
        }
        public static void OnLoad()
        {
            for (int i = 0; i < InitializeMainMap.GetLength(1); i++)
            {
                for (int j = 0; j < InitializeMainMap.GetLength(0); j++)
                {
                    if (InitializeMainMap[j, i] != ".")
                    {
                        string tileName = mapTileNames[Convert.ToInt32(InitializeMainMap[j, i])];
                        for (int k = 0; k < mapTileColliders.Length; k++)
                        {
                            if (tileName.Contains(mapTileColliders[k]))
                            {
                                new Collider(new Vector2(i, j), false);
                            }
                        }
                    }
                }
            }
        }
    }
}
