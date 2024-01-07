// tutorial from Brackeys: https://youtu.be/pZ0QyngaQv4?si=8p7v54hAiPu2_egk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//no monobehaviour because its not a component
[System.Serializable]
public class TurretBlueprint 
{
    public GameObject prefab;
    public string frogName;
    public string upgradeName;
    public string upgradeName2;
    public int cost;
    public int sellCost;
    public int sellCost2;
    public int sellCost3;
    public GameObject upgradedPrefab;
    public GameObject upgradedPrefab2;
    public int upgradeCost;
    public int upgradeCost2;
    private void OnMouseDown() { //click on tile
        Debug.Log("TurretBlueprint clicked");
    }
    
    public int GetSellAmount(){
        return cost/2;
    }
    public int GetUpgradeSellAmount(){
        return (cost+upgradeCost)/2;
    }
    public int GetUpgrade2SellAmount(){
        return (cost+upgradeCost+upgradeCost2)/2;
    }
}