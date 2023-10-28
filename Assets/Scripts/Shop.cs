using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurrret(){
        // called from UI element
        // communicates with buildManager and currency amount
        Debug.Log("Standard Turret selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurrret(){
        // called from UI element
        // communicates with buildManager and currency amount
        Debug.Log("Another Turret selected");
                buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);

    }
}
