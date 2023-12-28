using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject nodePrefab; // Assign in inspector
    public GameObject pathPrefab; // Assign in inspector
    public GameObject waypointPrefab; // Assign in inspector

    public static GameObject gNodePrefab; // Assign in inspector
    public static GameObject gPathPrefab; // Assign in inspector
    public static GameObject gWaypointPrefab; // Assign in inspector
    private static int n, m; // Dimensions of the board
    public static Node[,] grid; // 2D array of nodes
    
    private static int startX=0;
    private static int startZ=0;
    private static int width=16;
    private static int height=16;
    private static int tileWidth=5;
    private static int tileHeight=5;
    private static Transform gTransform;

    void Start(){
        gNodePrefab = nodePrefab;
        gPathPrefab = pathPrefab;
        gTransform = transform;
        gWaypointPrefab = waypointPrefab;
         // Call this function to generate the level
         GenerateLevel(4);
     }

    // Call this function to generate the level
    public static void GenerateLevel(int numberOfTurns)
    {
        Vector2Int startPoint = new Vector2Int(14, 1);
        Vector2Int endPoint = new Vector2Int(1, 14);

        SetBoardSize(width, height);
        grid = new Node[n, m];

        // Create the grid
        Debug.Log("GenerateLevel() grid of " + n + "x" + m + " nodes");
        for (int x = 0; x < n; x++)
        {
            for (int z = 0; z < m; z++)
            {
                Vector3 position = new Vector3(
                    startX + x*tileWidth, 
                    0,
                    startZ - z*tileHeight); // Adjust for your grid spacing
                //Debug.Log("GenerateLevel() (x,z)=(" + x +"," + z + "), position = " + position);
                GameObject node = Instantiate(gNodePrefab, position, Quaternion.identity, gTransform);
                grid[x,z] = node.GetComponent<Node>();
                //Debug.Log("GenerateLevel() grid[" + x + "," + z + "] = " + grid[x,z]);
            }
        }

        // Generate the path
        CreatePath(startPoint, endPoint, numberOfTurns);
    }

    // given 2 points, generate a leg between them
    private static Vector2Int[] GenerateLeg(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        
        // Start from the starting point
        Vector2Int currentPoint = start;
        path.Add(currentPoint);

        // Move horizontally until aligned with the end point's X
        while (currentPoint.x != end.x)
        {
            currentPoint.x += (currentPoint.x < end.x) ? 1 : -1;
            path.Add(currentPoint);
        }

        // Move vertically until aligned with the end point's Y
        while (currentPoint.y != end.y)
        {
            currentPoint.y += (currentPoint.y < end.y) ? 1 : -1;
            path.Add(currentPoint);
        }

        return path.ToArray();
    }

    private static Vector2Int[] CreateWaypoints(Vector2Int start, Vector2Int end, int maxTurns) {
        Vector2Int[] waypoint = new Vector2Int[7];
        waypoint[0] = start; 
        
        waypoint[1] = new Vector2Int(waypoint[0][0] - Random.Range(2, 6), waypoint[0][1]);
        waypoint[2] = new Vector2Int(waypoint[1][0], waypoint[1][1] + Random.Range(3, 6));

        waypoint[3] = new Vector2Int(waypoint[2][0] - Random.Range(2, 6), waypoint[2][1]);
        waypoint[4] = new Vector2Int(waypoint[3][0], waypoint[3][1] + Random.Range(3, 6));

        waypoint[5] = new Vector2Int(end[0], waypoint[4][1]);
        waypoint[6] = new Vector2Int(end[0], end[1]);

        return waypoint;
    }

    private static void CreatePath(Vector2Int start, Vector2Int end, int maxTurns)
    {
        // generate the "turning points" of the path
        // Vector2Int[] waypoint = new Vector2Int[5];
        // waypoint[0] = start;
        // waypoint[1] = new Vector2Int(10, 1);
        // waypoint[2] = new Vector2Int(10, 10);
        // waypoint[3] = new Vector2Int(1, 10);
        // waypoint[4] = new Vector2Int(1, 14);
        Vector2Int[] waypoint = CreateWaypoints(start, end, maxTurns);

        // generate the path between the turning points
        for (int i = 1; i < waypoint.Length; i++)
        {
            Vector2Int[] nextPath = GenerateLeg(waypoint[i-1], waypoint[i]);

            for (int j = 0; j < nextPath.Length; j++)
            {
                //Debug.Log("CreatePath() pathPoint = " + nextPath[i]);
                // first destroy the node at the path point
                if (grid[nextPath[j][0], nextPath[j][1]] != null) {
                    Destroy(grid[nextPath[j][0], nextPath[j][1]].gameObject);
                    grid[nextPath[j][0], nextPath[j][1]] = null;
                }

                // After calculating the path, instantiate the Path prefabs
                Vector3 pathPosition = new Vector3(startX + nextPath[j][0]*tileWidth, 0, startZ - nextPath[j][1]*tileHeight);
                //Debug.Log("CreatePath() pathPosition = " + pathPosition);
                Instantiate(gPathPrefab, pathPosition, Quaternion.identity, gTransform);
            }
        }
        // Clear the existing waypoints before generation new ones
        //Waypoints.ClearWaypoints();

        // Generate the waypoints that the enemies will follow
        for(int i = 0; i < waypoint.Length; i++)
        {
            Vector3 waypointPosition = new Vector3(startX + waypoint[i][0]*tileWidth, 2.41f, startZ - waypoint[i][1]*tileHeight);
            //Debug.Log("CreatePath() waypointPosition = " + waypointPosition);
            Instantiate(gWaypointPrefab, waypointPosition, Quaternion.identity, Waypoints.gTransform);
        }

        Waypoints.Generate();
    }
    // Function to set board dimensions
    public static void SetBoardSize(int width, int height)
    {
        n = width;
        m = height;
    }
}
