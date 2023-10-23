using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake(){
        Debug.Log("wayPoints.Awake");
        // Get all the points in the path
        points=new Transform[transform.childCount];
        // Store all the points in the array
        for(int i=0;i<points.Length;i++){
            points[i]=transform.GetChild(i);
        }
    }
}
