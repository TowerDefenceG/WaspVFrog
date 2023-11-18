// tutorial from Brackeys: https://youtu.be/t7GuWvP_IEQ?si=l5Wqj5UE3-Dmn8Lb

using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Color startColor;
    public Vector3 positionOffset;

    [Header("Optional")] //optional parameter in unity
    public GameObject turret; //current turret on tile (null if empty)

    private Renderer rend;
    //private Color startColor;

    BuildManager buildManager;

    private void Start() {
        rend = GetComponent<Renderer>();
        rend.material.color = startColor;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset; // position to build turret
    }

    private void OnMouseDown() { //click on tile
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (!buildManager.CanBuild){
            return;
        }

        if (turret != null){ //no turret already build on this tile 
            Debug.Log("Can't build there! - Todo: display on screen"); 
            return;
        }
        // Debug.Log("Build turret");

        buildManager.BuildTurretOn (this);
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
