using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TMP_Text upgradeCost;
    public TMP_Text upgradeCost2;  
    public TMP_Text sellCost;
    public TMP_Text sellCost2;
    public TMP_Text sellCost3;
    public TMP_Text frogName;
    public TMP_Text upgradeName;
    public TMP_Text upgradeName2;
    public Transform rangeIndicator;
    public Transform rangeIndicator2;
    public Button upgradeBtn;
    public Button upgradeBtn2;


    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        upgradeCost2.text = "$" + target.turretBlueprint.upgradeCost2;
        sellCost.text = "$" + target.turretBlueprint.sellCost;
        sellCost2.text = "$" + target.turretBlueprint.sellCost2;
        sellCost3.text = "$" + target.turretBlueprint.sellCost3;
        ShowRangeIndicator();

        if (target.upgrade == 0)
		{
			upgradeBtn.interactable = true;
            upgradeBtn2.interactable = false;
            sellCost.enabled = true;
            sellCost2.enabled = false;
            sellCost3.enabled = false;
		}if (target.upgrade == 1)
		{
			upgradeBtn.interactable = false;
            upgradeBtn2.interactable = true;
            sellCost.enabled = false;
            sellCost2.enabled = true;
            sellCost3.enabled = false;
		}if (target.upgrade == 2)
		{
			upgradeBtn.interactable = false;
            upgradeBtn2.interactable = false;
            sellCost.enabled = false;
            sellCost2.enabled = false;
            sellCost3.enabled = true;
		}

        frogName.text = target.turretBlueprint.frogName;
        upgradeName.text = target.turretBlueprint.upgradeName;
        upgradeName2.text = target.turretBlueprint.upgradeName2;

        if (target.turretBlueprint.frogName == "Laser Frog" && target.upgrade == 1){
            ShowRangeIndicator2();
            HideRangeIndicator();
        }
        if (target.turretBlueprint.frogName == "Frog" && target.upgrade == 2){
            HideRangeIndicator();
            ShowRangeIndicator2();
        }
        ui.SetActive(true);
    }

    void Start()
    {  
        Hide();
    }

    public void Hide()
    {
        ui.SetActive(false);
        rangeIndicator?.gameObject.SetActive(false);
        HideRangeIndicator();
    }

    void ShowRangeIndicator()
    {
        if (target != null && rangeIndicator != null)
        {
        // Accessing the Tower component to get the range
        float towerRange = target.turretBlueprint.prefab.GetComponent<Tower>().range;
        Debug.Log(towerRange);

        Vector3 position = target.GetBuildPosition();
        position.y = 1f; // Set the y-coordinate to 1

        rangeIndicator.position = position;

        // Scale the rangeIndicator based on the tower's range
        float indicatorScale = (towerRange) / rangeIndicator.localScale.x; // Multiply by 2 to get diameter
        rangeIndicator.localScale = new Vector3(indicatorScale, 0.5f, indicatorScale);

        rangeIndicator.gameObject.SetActive(true);
        }
    }

    void ShowRangeIndicator2()
    {
        if (target != null && rangeIndicator2 != null)
        {
        // Accessing the Tower component to get the range
        float towerRange2 = target.turretBlueprint.upgradedPrefab.GetComponent<Tower>().range;
        Debug.Log(towerRange2);

        Vector3 position = target.GetBuildPosition();
        position.y = 1f; // Set the y-coordinate to 1

        rangeIndicator2.position = position;

        // Scale the rangeIndicator based on the tower's range
        float indicatorScale2 = (towerRange2) / rangeIndicator2.localScale.x; // Multiply by 2 to get diameter
        rangeIndicator2.localScale = new Vector3(indicatorScale2, 0.5f, indicatorScale2);

        rangeIndicator2.gameObject.SetActive(true);
        }
    }

    void HideRangeIndicator()
    {
        if (rangeIndicator != null)
        {
            rangeIndicator?.gameObject.SetActive(false);
        }
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();

    }

        public void Upgrade2()
    {
        target.UpgradeTurret2();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        // Debug.Log("NodeUI.Sell()");
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
