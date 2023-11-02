using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret; 
    public TurretBlueprint anotherTurret; 

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log("Standard Turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log("Another Turret selected");
                buildManager.SelectTurretToBuild(anotherTurret);

    }
}
