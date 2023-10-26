using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //access without class, static so its shared. stores a reference to itself

    void Awake (){
        //called before Start()

        if (instance != null){
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this; // this build manager (created before start) is stored in instance variable

    }

    public GameObject standardTurretPrefab; 

    void Start(){
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild; 

    public GameObject GetTurretToBuild(){ //will be called from other scripts
        return turretToBuild;
    }
}
