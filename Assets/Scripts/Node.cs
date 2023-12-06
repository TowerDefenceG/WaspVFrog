// tutorial from Brackeys: https://youtu.be/t7GuWvP_IEQ?si=l5Wqj5UE3-Dmn8Lb

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections;


public class Node : MonoBehaviour{

    public Color hoverColor;
    public Color startColor;
    public Vector3 positionOffset;


    [HideInInspector] //hides public variable in unity
	public GameObject turret; //current turret on tile (null if empty)
	[HideInInspector] //hides public variable in unity
	public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    private Renderer rend;
    //private Color startColor;
    public float environmentLevel = 0.8f;

    BuildManager buildManager;
	
    private void Start() {
        rend = GetComponent<Renderer>();
        // rend.material.color = startColor;
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
		turretBlueprint = buildManager.GetTurretToBuild();

        //create random barriers
        if (Random.Range(0f, 1f) > environmentLevel){
            SpawnEnvironmentPrefab();
        }
    }

    //swan random barriers
    private void SpawnEnvironmentPrefab(){
        GameObject environmentPrefab = GetRandomPrefab();
        Instantiate(environmentPrefab, GetBuildPosition(), Quaternion.identity);
    }
    private GameObject GetRandomPrefab(){
        GameObject[] environmentPrefabs = GameObject.FindGameObjectsWithTag("barriers");
        if(environmentPrefabs.Length > 0){
            int randomIndex = Random.Range(0, environmentPrefabs.Length);
            return environmentPrefabs[randomIndex];
        }else{
            Debug.LogError("No barrier prefabs found");
            return null;
        }
    }

    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset; // position to build turret
    }

    private void OnMouseDown() { //click on tile
		// Debug.Log("Node clicked");
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
            }

        if (turret != null){ //no turret already build on this tile 
            Debug.Log("Can't build there! - Todo: display on screen");
			buildManager.selectNode(this); 
            return;
        }
        if (HasBarriers()){ //barriers built on environment prefabs
            Debug.Log("Can't build there! Node has barriers.");
            return;
        }
		if (!buildManager.CanBuild){
            return;
        }
        Debug.Log("Node.OnMouseDown() Build turret");
		turretBlueprint = buildManager.GetTurretToBuild();
        BuildTurret (turretBlueprint);
    }
    //detect if there's barriers prefabs on the node
    private bool HasBarriers(){
        float radius = transform.localScale.z; 
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders){
            if (collider.CompareTag("barriers")){
                return true;
            }
        }
        return false;
    }

// a method to sell a turret on a node and return the money to the player
	public void SellTurret(){
		Debug.Log("Node.SellTurret()");
		PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        turret = null;
        buildManager.DeselectNode();
    }

    void OnMouseOver (){
        // called once every frame mouse is over collider of object
        if (EventSystem.current.IsPointerOverGameObject()){ // stop accidental clickthrough if UI button is over a tile
            return;
        }

        if (!buildManager.CanBuild){ //only highlight tiles if we have a turret to build
            return;
        }

        rend.material.color = hoverColor; //gets material colour from object

}

	void BuildTurret(TurretBlueprint blueprint){
        
        if (PlayerStats.Money < blueprint.cost){
                // EditorUtility.DisplayDialog("Not Enough Money",
                //     "You only have " + PlayerStats.Money
                //     + " while this turret costs "+ blueprint.cost, "OK");
                // Debug.Log("not enough money to build that");
                return;
            }

            PlayerStats.Money -= blueprint.cost; //subtract turret cost

            if(!HasBarriers()){
                GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
                turret = _turret;
                turretBlueprint = blueprint;

                Debug.Log("turret built!");
            }else{
                Debug.Log("turret cannot be built.");
            }

	}

public void UpgradeTurret ()
{
    if (PlayerStats.Money < turretBlueprint.upgradeCost)
    {
        Debug.Log("Not enough money to upgrade that!");
        return;
    }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of old turret
        Destroy(turret);

        //build a new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;


        isUpgraded = true;

        Debug.Log("turret upgraded!");
}
    void OnMouseEnter (){
        // called once every time mouse enters collider of object
        if (EventSystem.current.IsPointerOverGameObject()){ // stop accidental clickthrough if UI button is over a tile
            return;
        }

        if (!buildManager.CanBuild){ //only highlight tiles if we have a turret to build
            return;
        }

        rend.material.color = hoverColor; //gets material colour from object
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }
}
