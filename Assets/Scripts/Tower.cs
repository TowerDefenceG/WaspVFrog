using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //the waypoint of the target
    public Transform target;
    //range of the tower
    public float range = 15f;
    //creates the tag for enemies
    public string enemyTag = "Enemy";
    //attack speed
    public float attackSpeed = 1f;
    //fixed attack update
    private float attackCountdown = 0f;

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
        } else
        {
            target = null;
        }
    }
    
    void Update()
    {
        if (target == null)
        return;

        if(attackCountdown <= 0f)
        {
            Attack();
            attackCountdown = 1f/attackSpeed;
        }
        //counter for the attack countdown
        attackCountdown -= Time.deltaTime;
    }

    void Attack()
    {
        Debug.Log("SHOOT");
    }

    void OnDrawGizmosSelected()
    {
        //creates red range sphere in the scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
