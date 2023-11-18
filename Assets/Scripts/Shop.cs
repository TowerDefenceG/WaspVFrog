// tutorial from Brackeys: https://youtu.be/uv1zp7aOoOs?si=rYyHKg3-To6t7pFv
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret; 
    public TurretBlueprint missileTurret; 

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

    public void SelectMissileTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log("missile Turret selected");
                buildManager.SelectTurretToBuild(missileTurret);

    }
}
