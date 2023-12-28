using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy))]
public class moveEnemy : MonoBehaviour{
    
    private Transform target; // The target waypoint
    private int wavepointIndex = 0; // The index of the waypoint that the enemy is currently targeting
    
    private Enemy enemy;

    void Start(){
        enemy = GetComponent<Enemy>();
        // Set the target to the first waypoint
        target = Waypoints.points?[0];
    }

    void Update(){
        if (target == null) {
            target = Waypoints.points?[0];
        } else {
            if (!GameManager.gameIsOver){
                // Move the enemy towards the waypoint
                Vector3 dir = target.position - transform.position;
                // Move the enemy towards the waypoint
                transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

                // look in direction it is moving
                Vector3 relativePos = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                transform.rotation = rotation;

                // If the enemy reaches the waypoint, get the next waypoint
                if (Vector3.Distance(transform.position, target.position) <= 0.4f)
                {
                    GetNextWaypoint();
                }
            }

            enemy.speed = enemy.startSpeed;
        }
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
        PlayerStats playerStatsInstance = new PlayerStats();
        PlayerStats.decreaseLives();
                // PlayerStats.decreaseLives();
        //log lives
        // Debug.Log("Lives: " + PlayerStats.Lives);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}