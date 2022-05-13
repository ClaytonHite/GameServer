using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.AIPathfinding
{
    public class Pathfinding
    {
        public Player _target;
        public Monster _selectedUnit;
        public bool isActive = false;
        public Vector2 _targetOriginPos = new Vector2(0,0);
        int[,] tiles;
        static int pathfindingGraphSizeX = 6;
        static int pathfindingGraphSizeY = 6;
        int tilesX = pathfindingGraphSizeX * 4;
        int tilesY = pathfindingGraphSizeY * 4;
        public List<Node> currentPath = null;
        public List<Node> movementList = null;
        Node[,] graph;
        public void EnteredMonsterRange(Player _player, Monster _monster)
        {
            isActive = true;
            _target = _player;
            _selectedUnit = _monster;
        }
        public void ExitedMonsterRange()
        {
            isActive = false;
            _target = null;
        }
        public float isNear()
        {
            if(Player.players[_selectedUnit.currentTargetID] == null)
            {
                return 100;
            }
            return Vector2.Distance(_selectedUnit.monsterPosition, Player.players[_selectedUnit.currentTargetID].position);
        }
        public void Update()
        {
            if (!isActive || _target == null || _selectedUnit.isMoving == true) return;
            if(isNear() < 1.75) { return; }
            _selectedUnit.isMoving = true;
            if (_targetOriginPos != _target.position)
            {
                _targetOriginPos = _target.position;
                GenerateMapData();
                GeneratePathfindingGraph();
                GeneratePathTo((int)_target.position.X - (int)_selectedUnit.monsterPosition.X + pathfindingGraphSizeX, (int)_target.position.Y - (int)_selectedUnit.monsterPosition.Y + pathfindingGraphSizeY);
            }
            Task.Run(async delegate
            {
                await Task.Delay((1000 / (1 + (_selectedUnit.monsterDexterity / 50))));
                _selectedUnit.isMoving = false;
            });
            if (movementList == null) return;
            MoveNextTile(movementList);
        }
        void GenerateMapData()
        {
            int x, y;
            tiles = new int[tilesX, tilesY];

            for (x = 0; x < tilesX; x++)
            {
                for (y = 0; y < tilesY; y++)
                {
                    Vector2 GridPosition = new Vector2((x + _selectedUnit.monsterPosition.X - pathfindingGraphSizeX), (y + _selectedUnit.monsterPosition.Y - pathfindingGraphSizeY));
                    if (!Collider.CheckForCollider(GridPosition))
                    {
                        tiles[x, y] = 9999;
                    }
                    else if (Collider.CheckForCollider(GridPosition))
                    {
                        tiles[x, y] = 1;
                    }
                    else
                    {
                        tiles[x, y] = 9999;
                    }
                }
            }
        }
        void GeneratePathfindingGraph()
        {
            // Initialize the array
            graph = new Node[(tilesX), (tilesY)];
            // Initialize a Node for each spot in the array
            for (int x = 0; x < (tilesX); x++)
            {
                for (int y = 0; y < (tilesY); y++)
                {
                    graph[x, y] = new Node();
                    graph[x, y].x = (int)(x + _selectedUnit.monsterPosition.X - pathfindingGraphSizeX);
                    graph[x, y].y = (int)(y + _selectedUnit.monsterPosition.Y - pathfindingGraphSizeY);
                }
            }

            // Now that all the nodes exist, calculate their neighbours
            for (int x = 0; x < (tilesX); x++)
            {
                for (int y = 0; y < (tilesY); y++)
                {
                    // Look Left
                    if (x > 0)
                    {
                        graph[x, y].neighbours.Add(graph[x - 1, y]);
                        if (y > 0)
                            graph[x, y].neighbours.Add(graph[x - 1, y - 1]);
                        if (y < (tilesY) - 1)
                            graph[x, y].neighbours.Add(graph[x - 1, y + 1]);
                    }

                    // Look right
                    if (x < (tilesX) - 1)
                    {
                        graph[x, y].neighbours.Add(graph[x + 1, y]);
                        if (y > 0)
                            graph[x, y].neighbours.Add(graph[x + 1, y - 1]);
                        if (y < (tilesY) - 1)
                            graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
                    }

                    // Look up and down
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x, y - 1]);
                    if (y < (tilesY) - 1)
                        graph[x, y].neighbours.Add(graph[x, y + 1]);

                }
            }
        }
        public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY)
        {
            if (UnitCanEnterTile(targetX + pathfindingGraphSizeX - (int)_selectedUnit.monsterPosition.X, targetY + pathfindingGraphSizeY - (int)_selectedUnit.monsterPosition.Y) == false)
                return (float)Double.PositiveInfinity;

            float cost = 1;
            if (sourceX != targetY + pathfindingGraphSizeY - (int)_selectedUnit.monsterPosition.Y || sourceY != targetY + pathfindingGraphSizeY - (int)_selectedUnit.monsterPosition.Y)
            {//For Diagonal Movement
                cost += 0.00001f;
            }
            return cost;
        }
        public bool UnitCanEnterTile(int x, int y)
        {
            if(tiles[x, y] < 4)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void GeneratePathTo(int x, int y)
        {
            if(x < 0 || y < 0)
            {
                //For when player moves out of search box and sends -1 to the array if let through
                return;
            }
            List<Node> unvisited = new List<Node>();
            Dictionary<Node, float> dist = new Dictionary<Node, float>();
            Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

            Node source = graph[pathfindingGraphSizeX, pathfindingGraphSizeX];
            Node target = graph[x, y];// Figure out how to debug when player moves and is outside of the array
            dist[source] = 0;
            prev[source] = null;

            foreach (Node v in graph)
            {
                if (v != source)
                {
                    dist[v] = (float)Double.PositiveInfinity;
                    prev[v] = null;
                }
                unvisited.Add(v);
            }

            while (unvisited.Count > 0)
            {
                Node u = null;

                foreach (Node possibleU in unvisited)
                {
                    if (u == null || dist[possibleU] < dist[u])
                    {
                        u = possibleU;
                    }
                }
                if (u == target)
                {
                    break;  // Found Target, Exit the while loop!
                }
                unvisited.Remove(u);
                foreach (Node v in u.neighbours)
                {
                    float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }
                }
            }
            if (prev[target] == null)
            {
                // No route between our target and the source
                return;
            }
            List<Node> currentPath = new List<Node>();
            Node curr = target;
            while (curr != null)
            {
                currentPath.Add(curr);
                curr = prev[curr];
            }
            currentPath.Reverse();

            if (currentPath != null)
            {
                int currNode = 0;
                while (currNode < currentPath.Count - 1)
                {
                    Vector2 start = new Vector2(currentPath[currNode].x, currentPath[currNode].y);
                    Vector2 end = new Vector2(currentPath[currNode + 1].x, currentPath[currNode + 1].y);
                    currNode++;
                }
            }
            movementList = currentPath;
        }

        public void MoveNextTile(List<Node> currentPath)
        {
            if (currentPath.Count > 2)
            {
                Vector2 movePosition = new Vector2(currentPath[1].x, currentPath[1].y);
                _selectedUnit.monsterPosition = movePosition;
                ServerSend.UpdateMonsterPosition(_selectedUnit.monsterID, _selectedUnit.monsterPosition);
                currentPath.RemoveAt(0);
                movementList = currentPath;
            }
            else
            {
                movementList = null;
            }
        }
    }
}