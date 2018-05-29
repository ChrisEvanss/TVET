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
                    // Check if the desired x & y is outside bounds
                    if(desiredX < 0 || desiredX >= width ||
                       desiredY < 0 || desiredY >= height)
                    {
                        // Continue to next element in loop
                        continue;
                    }
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

        void Update()
        {
            // Is mouse button down?
            if (Input.GetMouseButtonDown(0))
            {
                // Ray cast from the camera using the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Did the raycast hit something?
                if (hit.collider != null)
                {
                    // Is the thing we hit a 'Tile'?
                    Tile hitTile = hit.collider.GetComponent<Tile>();
                    if (hitTile != null)
                    {
                        // Perform game logic with selected tile
                        SelectTile(hitTile);
                    }
                }
            }
        }

        void FFuncover(int x, int y, bool[,] visited)
        {
            // Is x and y within bounds of the grid?
            if (x >= 0 && y >= 0 &&
                x < width && y < height)
            {
                // Has this coordinate been visited
                if (visited[x, y])
                    return;
                // Reveal tile in that x and y coordinate
                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);

                // If there were no adjacent mines around that tile
                if (adjacentMines == 0)
                {
                    // This tile has been visited
                    visited[x, y] = true;
                    // Visit all other tiles around this tile
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);
                }
            }
        }

        // Uncovers all mines in the grid
        void UncoverMines(int mineState = 0)
        {
            // Loop througth 2D array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    // Check if tile is a mine
                    if (tile.isMine)
                    {
                        // Reveal that tile
                        int adjacentMines = GetAdjacentMineCount(tile);
                        tile.Reveal(adjacentMines, mineState);
                    }
                }
            }
        }

        // Scans the grid to check if there are no more empty tiles
        bool NoMoreEmptyTiles()
        {
            // Set empty tile count to zero
            int emptyTileCount = 0;
            // Loop through 2D array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    // If tile is NOT revealed AND NOT a mine
                    if (!tile.isRevealed &&
                       !tile.isMine)
                    {
                        // We found an empty tile!
                        emptyTileCount += 1;
                    }
                }
            }
            // If there are empty tiles - return true
            // If there are no empty tiles - return false
            return emptyTileCount == 0;
        }

        // Uncovers a selected tile
        void SelectTile(Tile selected)
        {
            int adjacentMines = GetAdjacentMineCount(selected);
            selected.Reveal(adjacentMines);
            
            // Is the selected tile a mine?
            if (selected.isMine)
            {
                // Uncover all mines - with default loss state '0'
                UncoverMines();
                // Lose
            }
            // Otherwise, are there no mines around this tile?
            else if (adjacentMines == 0)
            {
                int x = selected.x;
                int y = selected.y;
                // Then use flood fill to uncover all adjacent mines
                FFuncover(x, y, new bool[width, height]);
            }
            // Are there no more empty tiles in the game at this point?
            if(NoMoreEmptyTiles())
            {
                // Uncover all mines - with the win state '1'
                UncoverMines(1);
                // Win
            }
        }
    }
}