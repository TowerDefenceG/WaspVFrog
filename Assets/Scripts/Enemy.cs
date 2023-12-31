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

    [SerializeField] ParticleSystem impactParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] GameObject deathParticlesPrefab;
    [SerializeField] private AudioClip deathSound;

    void Start(){
        speed = startSpeed * ModeSelector.GetDifficulty().enemySpeedFactor;
        // Debug.Log("Enemy.Start() speed=" + speed);
    }

    void Awake(){
        //Debug.Log("moveEnemy.Awake()");
    }

    public void TakeDamage(float amount){
        health -= amount;
        impactParticle.Play();
        if(health <= 0){
            Die();
        }
    }

    public void Slow(float pct){
        // takes in slowness percentage
        impactParticle.Play();
        speed = startSpeed * (1f - pct) * ModeSelector.GetDifficulty().enemySpeedFactor;
    }
    
    void Die(){
        AudioManager.Instance.PlaySound(deathSound);
        
        // Debug.Log("animation");
        // StartCoroutine(PlayDeathParticleAndDestroy());
        // deathParticle.Play();
        Destroy(gameObject);
        PlayerStats.Money += worth;
        WaveSpawner.EnemiesAlive--; 
    }

    void OnDestroy(){
        if (deathParticlesPrefab != null){
            // Instantiate the DeathParticles object at the same position as the original object
            GameObject deathParticles = Instantiate(deathParticlesPrefab, transform.position, transform.rotation);

            // Start the particle system
            deathParticles.GetComponent<ParticleSystem>().Play();
        }
    }

    // IEnumerator PlayDeathParticleAndDestroy(){
    //     // Delay for a short period before playing the impact particle
        
    //     // yield return new WaitForSeconds(0.1f);
        
    //     Transform waspTransform = transform.Find("wasp"); // Replace "Wasp" with the actual name of the child object
    //     if (waspTransform != null){
    //         waspTransform.gameObject.SetActive(false);
    //     }
    //     // yield return new WaitForSeconds(0.1f);
        
    //     // Additional delay if needed
    //     yield return new WaitForSeconds(0.1f);

    //     // Destroy the enemy after playing the particle
    //     Destroy(gameObject);
        
    //     // Decrement the count of enemies alive
    //     WaveSpawner.EnemiesAlive--; 
    // }

    
}



