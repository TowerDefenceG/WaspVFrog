using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TMP_Text upgradeCost; 
    public TMP_Text sellCost;

    
    public Transform rangeIndicator;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        sellCost.text = "$" + target.turretBlueprint.sellCost;
        ui.SetActive(true);
        ShowRangeIndicator();
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
        rangeIndicator.localScale = new Vector3(indicatorScale, 0.1f, indicatorScale);

        rangeIndicator.gameObject.SetActive(true);
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

    public void Sell()
    {
        // Debug.Log("NodeUI.Sell()");
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
