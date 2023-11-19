using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //the waypoint of the target
    public Transform target;
    public Enemy targetEnemy;

    [Header("General")]
    //range of the tower
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject attackPrefab;
    //attack speed
    public float attackSpeed = 1f;
    //fixed attack update
    private float attackCountdown = 0f;

    // Laser properties
    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30; //dps
    public float slowPct = .5f; // slow percentage
    public LineRenderer lineRenderer; 

    [Header("Setup")]
    //creates the tag for enemies
    public string enemyTag = "Enemy";
    public Transform attackPoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //finds objects assigned with enemy tag and store in array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // finds the enemy with the shortest distance to the tower
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //loops through the objects tagged enemy in the enemies array
        foreach (GameObject enemy in enemies)
        {
            //returns distance from tower to each enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //if the enemy has the shortest distance to the tower it is now the nearest 
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //set the nearest enemy as a target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }
    
    void Update()
    {
        if (target == null){
            if(useLaser){
                if(lineRenderer.enabled){
                    lineRenderer.enabled = false;
                }
            }
            return;

        }
        transform.LookAt(target); //rotate to look at enemy

        if (useLaser){
            Laser();
        }else{ // not laser
            if(attackCountdown <= 0f)
            {
                Attack();
                attackCountdown = 1f / attackSpeed;
            }
            //counter for the attack countdown
            attackCountdown -= Time.deltaTime;
        }

        
    }

    void Laser(){
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct); // take in val 0-1 
        
        if(!lineRenderer.enabled){
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, attackPoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Attack()
    {
        GameObject attackGO = (GameObject)Instantiate (attackPrefab, attackPoint.position, attackPoint.rotation);
    Attack attack = attackGO.GetComponent<Attack>();

    if (attack != null)
        attack.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        //creates red range sphere in the scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
