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

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        sellCost.text = "$" + target.turretBlueprint.sellCost;
        ui.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hide()
    {
        ui.SetActive(false);
    }

        public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        Debug.Log("NodeUI.Sell()");
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
