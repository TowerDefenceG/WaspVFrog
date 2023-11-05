using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f; //cooldown
    private float countdown =2f; //takes 2 seconds to spawn first wave

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveNumberText;

    private int waveIndex = 1; 

    private void Update() {
        if (!GameManager.gameIsOver){
            //manage time
            if (countdown <= 0f) //countdown reaches 0
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves; //reset countdown on wave spawn
            }

            countdown -= Time.deltaTime; // decrase countdown constantly
        
            waveCountdownText.text = Mathf.Round(countdown).ToString();
        }
    }

    //coroutine 
    IEnumerator SpawnWave() {
        
        waveNumberText.text = ("Wave: " + waveIndex.ToString());

        // Debug.Log("(wave) Wave Incoming:" + waveIndex);
        for (int i=0; i< waveIndex; i++){
			// Debug.Log("(wave) Spawning Enemy");
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //time between enemies in a wave

        }
        waveIndex ++; // next wave
        PlayerStats.Rounds++;

    }

	//spawn enemy at spawnpoint
    void SpawnEnemy(){
		// Debug.Log("(wave) Spawned Enemy");
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
		
    }
}
