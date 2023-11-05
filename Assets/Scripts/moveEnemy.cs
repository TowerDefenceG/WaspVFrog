using UnityEngine;
using System.Collections;


public class moveEnemy : MonoBehaviour
{
    // The speed of the enemy
    public float speed=10f;
    // The target waypoint
    private Transform target;
    // The index of the waypoint that the enemy is currently targeting
    private int wavepointIndex=0;
    // The health of the enemy
    public int health = 100;
    public int value = 50;

    void Awake(){
        //Debug.Log("moveEnemy.Awake()");
    }

    void Start(){
        //Debug.Log("moveEnemy.start()");
        // Set the target to the first waypoint
        target=Waypoints.points[0];
    }

    void Update()
    {
        if (!GameManager.gameIsOver){
            //Debug.Log("moveEnemy.update()");
            // Move the enemy towards the waypoint
            Vector3 dir = target.position - transform.position;
            // Move the enemy towards the waypoint
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            // If the enemy reaches the waypoint, get the next waypoint
            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
    }
    
    public void TakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            Die();
            
        }
    }
    
    void Die(){
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    // Get the next waypoint
    void GetNextWaypoint(){
        // If the enemy reaches the last waypoint, destroy it
        if(wavepointIndex >= Waypoints.points.Length-1){
           EndPath();
           // Destroy(gameObject);
           return;
        }
        // Get the next waypoint
        wavepointIndex++;
        target=Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.decreaseLives();
        //log lives
        Debug.Log("Lives: " + PlayerStats.Lives);

        Destroy(gameObject);
    }
}



