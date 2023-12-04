using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    // The speed of the enemy

    [HideInInspector] //hides speed variable in inspector as it shouldnt be edited
    public float speed; 

    // The health of the enemy
    public float health = 100;
    public int worth = 50;

    void Start(){
        speed = startSpeed;
    }

    void Awake(){
        //Debug.Log("moveEnemy.Awake()");
    }

    public void TakeDamage(float amount){
        health -= amount;
        if(health <= 0){
            Die();
        }
    }

    public void Slow(float pct){
        // takes in slowness percentage
        speed = startSpeed * (1f - pct);
    }
    
    void Die(){
        PlayerStats.Money += worth;
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--; 
    }

    
}



