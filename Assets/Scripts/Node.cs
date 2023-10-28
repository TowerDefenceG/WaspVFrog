using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret; //current turret on tile (null if empty)

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown() { //click on tile
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (buildManager.GetTurretToBuild() == null){
            return;
        }

        if (turret != null){ //no turret already build on this tile 
            Debug.Log("Can't build there! - Todo: display on screen"); 
            return;
        }
        // Debug.Log("Build turret");

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild(); //gets turret type 
        turret = (GameObject)Instantiate(turretToBuild, transform.position +positionOffset, transform.rotation); //cast to GameObject, assign to turret

    }

    void OnMouseEnter (){
        // called once every time mouse enters collider of object
        if (EventSystem.current.IsPointerOverGameObject()){ // stop accidental clickthrough if UI button is over a tile
            return;
        }

        if (buildManager.GetTurretToBuild() == null){ //only highlight tiles if we have a turret to build
            return;
        }

        rend.material.color = hoverColor; //gets material colour from object
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }
}
