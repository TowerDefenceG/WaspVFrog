// tutorial from Brackeys: https://youtu.be/t7GuWvP_IEQ?si=l5Wqj5UE3-Dmn8Lb

using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //access without class, static so its shared. stores a reference to itself
    public NodeUI nodeUI;
    void Awake (){
        //called before Start()
		
        if (instance != null){
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this; // this build manager (created before start) is stored in instance variable

    }

    private TurretBlueprint turretToBuild; 
	//selected turret 
	private Node selectedNode; 

    public bool CanBuild { get { return turretToBuild != null; } } //a property (like a small function) checks condition each time its used

    
	
	public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

	public void selectNode(Node node){
	    if (selectedNode == node){
            Debug.Log("deselecting node");
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret; 
		DeselectNode();
    }
    
    public TurretBlueprint GetTurretToBuild(){
        return turretToBuild;
    }
}
