using UnityEngine;
using System.Collections.Generic;

/**
    PCG Level Generator!
**/
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
    private static int gLevel=1;
    // translate from level number to number of turns
    private static int[] level2turns = {0,5,4,3};

    void Start(){
        gNodePrefab = nodePrefab;
        gPathPrefab = pathPrefab;
        gTransform = transform;
        gWaypointPrefab = waypointPrefab;
         // Call this function to generate the level
         GeneratePCGLevel(gLevel);
     }

     public static void SetLevel(int level){
        gLevel=level;
     }

    // Call this function to generate the level
    public static void GeneratePCGLevel(int level)
    {
        Vector2Int startPoint = new Vector2Int(14, 1);
        Vector2Int endPoint = new Vector2Int(1, 14);

        SetBoardSize(width, height);
        grid = new Node[n, m];

        // Create the grid
        Debug.Log("GeneratePCGLevel() grid of " + n + "x" + m + " nodes");
        for (int x = 0; x < n; x++)
        {
            for (int z = 0; z < m; z++)
            {
                Vector3 position = new Vector3(
                    startX + x*tileWidth, 
                    0,
                    startZ - z*tileHeight); // Adjust for your grid spacing
                //Debug.Log("GeneratePCGLevel() (x,z)=(" + x +"," + z + "), position = " + position);
                GameObject node = Instantiate(gNodePrefab, position, Quaternion.identity, gTransform);
                grid[x,z] = node.GetComponent<Node>();
                //Debug.Log("GeneratePCGLevel() grid[" + x + "," + z + "] = " + grid[x,z]);
            }
        }

        // Generate the path
        CreatePath(startPoint, endPoint, level2turns[level]);
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
        // Assumption: we can have 5, 4, or 3 turns

        Vector2Int[] waypoint = new Vector2Int[maxTurns+2];
        int wp = 0;

        waypoint[wp] = start; 
        wp++;

        if (maxTurns == 5) {
            Debug.Log("CreateWaypoints() debug 5");
            waypoint[wp] = new Vector2Int(waypoint[wp-1][0] - Random.Range(2, 6), waypoint[wp-1][1]);
            wp ++;
        }
        if (maxTurns >= 4) {
            waypoint[wp] = new Vector2Int(waypoint[wp-1][0], waypoint[wp-1][1] + Random.Range(3, 6));
            wp ++;
        }

        waypoint[wp] = new Vector2Int(waypoint[wp-1][0] - Random.Range(2, 6), waypoint[wp-1][1]);
        wp ++;
        waypoint[wp] = new Vector2Int(waypoint[wp-1][0], waypoint[wp-1][1] + Random.Range(3, 6));
        wp ++;

        waypoint[wp] = new Vector2Int(end[0], waypoint[wp-1][1]);
        wp ++;
        waypoint[wp] = new Vector2Int(end[0], end[1]);
        wp ++;

        Debug.Log("CreateWaypoints() waypoint = " + waypoint);
        return waypoint;
    }

    private static void CreatePath(Vector2Int start, Vector2Int end, int maxTurns)
    {
        Debug.Log("CreatePath() maxTurns = " + maxTurns);

        // generate the turning points
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
