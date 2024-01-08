// tutorial from Brackeys: https://youtu.be/uv1zp7aOoOs?si=rYyHKg3-To6t7pFv
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret; 
    public TurretBlueprint missileTurret; 
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log($"Standard Turret selected. cost={standardTurret.cost}");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log($"missile Turret selected. cost={missileTurret.cost}");
                buildManager.SelectTurretToBuild(missileTurret);

    }

    public void SelectLaserTurret(){
        // called from UI element
        // communicates with buildManager and currency amount

        Debug.Log($"Laser Turret selected. cost={laserBeamer.cost}");
                buildManager.SelectTurretToBuild(laserBeamer);

    }
}
