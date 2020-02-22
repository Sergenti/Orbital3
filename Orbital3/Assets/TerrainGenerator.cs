using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Terrain Generation Parameters")]
    [SerializeField] private int portionWidth = 5;
    private int portionLength = 0; // generated in fx of screen width
    [SerializeField] private int laneWidth = 1; // number of regular ground tiles between 2 lane markers
    [SerializeField] private int detectionDistance = 5;

    [Space]
    [Header("Obstacles Generation Parameters")]
    [SerializeField] [Range(0, 1)] private float bushChance = .5f;
    [SerializeField] private int maxBushSize = 3;
    [SerializeField] [Range(0, 1)] private float holeChance = .5f;
    [SerializeField] private int maxHoleSize = 3;
    [SerializeField] private int maxObstacles = 3;
    [SerializeField] private int maxPlacementTries = 5;

    [Space]
    [Header("Tiles")]
    [SerializeField] private RuleTile hole;
    [SerializeField] private RuleTile bush;
    [SerializeField] private Tile regularGroundTile;
    [SerializeField] private Tile laneTile;

    [Space]
    [Header("Tilemaps")]
    [SerializeField] private Tilemap terrainMap;
    [SerializeField] private Tilemap obstaclesMap;

    private int lastStartX = 0;
    private float screenWidthInUnits = 0;
    private Camera camera;

    public int portionsCreated = 0;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        float screenWidthInUnits = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0) - camera.ScreenToWorldPoint(Vector3.zero)).x;
        portionLength = Mathf.CeilToInt(screenWidthInUnits * 2);

        int startX = Mathf.FloorToInt(camera.ScreenToWorldPoint(Vector3.zero).x);
        GeneratePortion(startX);

        lastStartX = startX;
    }

    void Update()
    {
        int nextStartX = lastStartX + portionLength;
        float cameraRightBorderX = gameObject.GetComponent<Grid>().WorldToCell(camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0))).x;

        // if camera max x is close to next border
        if (cameraRightBorderX >= nextStartX - detectionDistance)
        {
            // generate another portion, remove the very last one
            GeneratePortion(nextStartX);
            RemovePortion(lastStartX - portionLength * 2);

            lastStartX = nextStartX;
        }
    }

    private void GeneratePortion(int startX)
    {
        // generate ground
        int startY = -Mathf.RoundToInt(portionWidth / 2);
        for (int x = 0; x < portionLength; x++)
        {
            int currentX = startX + x;
            int laneCounter = 0;

            for (int y = 0; y < portionWidth; y++)
            {
                int currentY = startY + y;

                Tile tileToPlace = laneCounter >= laneWidth ? laneTile : regularGroundTile;

                if (laneCounter >= laneWidth)
                {
                    tileToPlace = laneTile;
                    laneCounter = 0;
                }
                else
                {
                    tileToPlace = regularGroundTile;
                    laneCounter++;
                }

                terrainMap.SetTile(new Vector3Int(currentX, currentY, 0), tileToPlace);
            }
        }

        // generate obstacles
        for (int i = 0; i < maxObstacles; i++)
        {
            // decide if there is going to be an obstacle or not
            // we will only have one of each max per portion
            bool hasHole = Random.Range(0, 101) >= holeChance * 100;
            bool hasBush = Random.Range(0, 101) >= bushChance * 100;

            Debug.Log("bush: " + hasBush + " hole: " + hasHole);

            // if they exist
            if (hasHole)
            {
                // decide its size
                int holeSize = Random.Range(2, maxHoleSize + 1);

                // decide where to place it
                int maxY = startY + portionWidth - holeSize;
                int maxX = startX + portionLength - holeSize;

                bool abort = false;
                int tries = 0;
                Vector3Int pos = Vector3Int.zero;

                while (true)
                {
                    pos = new Vector3Int(
                        Random.Range(startX, maxX),
                        Random.Range(startY, maxY),
                        0
                    );

                    if (CanBuildHole(pos, holeSize)) break;

                    tries++;
                    if (tries > maxPlacementTries)
                    {
                        abort = true;
                        break;
                    }
                }

                // place it as a square
                for (int x = 0; x < holeSize; x++)
                {
                    for (int y = 0; y < holeSize; y++)
                    {
                        var currentPos = new Vector3Int(
                            pos.x + x,
                            pos.y + y,
                            0
                        );

                        obstaclesMap.SetTile(currentPos, hole);
                    }
                }
            }

            if (hasBush)
            {
                // decide its size
                int bushSize = Random.Range(2, maxBushSize + 1);

                // decide where to place it
                int maxY = startY + portionWidth - bushSize;
                int maxX = startX + portionLength;

                bool abort = false;
                int tries = 0;
                Vector3Int pos = Vector3Int.zero;

                while (true)
                {
                    pos = new Vector3Int(
                    Random.Range(startX, maxX),
                    Random.Range(startY, maxY),
                    0
                    );

                    if (CanBuildBush(pos, bushSize)) break;

                    tries++;
                    if (tries > maxPlacementTries)
                    {
                        abort = true;
                        break;
                    }
                }

                if (!abort)
                {
                    // place it, only in a row
                    for (int y = 0; y < bushSize; y++)
                    {
                        var currentPos = new Vector3Int(
                            pos.x,
                            pos.y + y,
                            0
                        );

                        obstaclesMap.SetTile(currentPos, bush);
                    }
                }
            }

            portionsCreated++;
            //Debug.Log("Road chunks created: " + portionsCreated);
        }
    }

    private void RemovePortion(int startX)
    {
        int startY = -Mathf.RoundToInt(portionWidth / 2);

        for (int x = 0; x < portionLength; x++)
        {
            int currentX = startX + x;

            for (int y = 0; y < portionWidth; y++)
            {
                int currentY = startY + y;
                Vector3Int currentPos = new Vector3Int(currentX, currentY, 0);

                if (terrainMap.HasTile(currentPos))
                {
                    terrainMap.SetTile(currentPos, null);
                }
                if (obstaclesMap.HasTile(currentPos))
                {
                    obstaclesMap.SetTile(currentPos, null);
                }

            }
        }
    }

    private bool CanBuildHole(Vector3Int pos, int size)
    {
        // returns false if there is something where this would be placed
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                var newPos = new Vector3Int(
                    pos.x + x,
                    pos.y + y,
                    0
                );

                if (obstaclesMap.HasTile(pos)) return false;
            }
        }

        return true;
    }

    private bool CanBuildBush(Vector3Int pos, int size)
    {
        for (int y = 0; y < size; y++)
        {
            var newPos = new Vector3Int(
                pos.x,
                pos.y + y,
                0
            );

            if (obstaclesMap.HasTile(pos)) return false;
        }

        return true;
    }
}