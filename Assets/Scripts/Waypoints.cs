using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform gTransform;

    public static Transform[] points;

    void Awake() {
        Debug.Log("wayPoints.Awake");
        gTransform = transform;
        Generate();
    }

    public static void ClearWaypoints(){
        //delete all child objects
        for (int i = gTransform.childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(gTransform.GetChild(i).gameObject);
        }
        points=null;
    }

    public static void Generate(){
        Debug.Log("wayPoints.Generate " + gTransform.childCount + " waypoints");
        // Get all the points in the path
        if (gTransform.childCount > 0){
            Transform[] localPoints = new Transform[gTransform.childCount];
            // Store all the points in the array
            for(int i=0; i < localPoints.Length; i++){
                localPoints[i] = gTransform.GetChild(i);
            }
            points = localPoints;
        }
    }
}
