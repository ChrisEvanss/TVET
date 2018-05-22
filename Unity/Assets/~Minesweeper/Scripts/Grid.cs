using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        // Functions & Variables go here
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            // Edit it's properties
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            // Return it
            return currentTile;
        }

        // Spawn tiles in a grid like pattern
        void GenerateTiles()
        {
            // Create a new 2D array of size width x height
            tiles = new Tile[width, height];
            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width * 0.5f,
                                                   height * 0.5f);

                    // Pivot tiles around grid
                    Vector2 pos = new Vector2((x - halfSize.x) + .5f,
                                              (y - halfSize.y) + .5f);
                  //  pos += new Vector2(0.5f, 0.5f);
                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile using spawn funciton made earlier
                    Tile tile = SpawnTile(pos);
                    //Attach newly spawned tile to self (transform)
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    //Store tile in array at those coordiantes
                    tiles[x, y] = tile;
                }
            }
        }

        void Start()
        {
            GenerateTiles();
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            // Set count to 0
            int count = 0;
            // Loop through all adjacent tiles on the X
            for (int x = -1; x <= 1; x++)
            {
                // Loopthrough all adjacent tiles on the Y
                for (int y = -1; y <= 1; y++)
                {
                    // Calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    // Select current tile
                    Tile currentTile = tiles[desiredX, desiredY];
                    //Check if that tile is a mine
                    if (currentTile.isMine)
                    {
                        // Increment count by 1
                        count++;
                    }
                }
            }

            // Remember to return the count!
            return count;
        }

        // Update is called once per frame
        void Update()
        {
          // LET mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition)
          // LET hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction)
          // IF hit.collider != null
          // LET hitTile = hit.collider.GetComponent<Tile>()
          // IF hitTile != null
          // LET adjacentMines = GetAdjacentMineCountAt(hitTile)
          // CALL hitTile.Reveal(adjacentMines)
        }
    }
}