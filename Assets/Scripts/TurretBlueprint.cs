// tutorial from Brackeys: https://youtu.be/pZ0QyngaQv4?si=8p7v54hAiPu2_egk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//no monobehaviour because its not a component
[System.Serializable]
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    private void OnMouseDown() { //click on tile
        Debug.Log("TurretBlueprint clicked");
    }
    
    public int GetSellAmount(){
        return cost/2;
    }

}
