// tutorial from Brackeys: https://youtu.be/n2DXF1ifUbU?si=9yLMmIlGPwWC5Vzh 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves; 

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f; //cooldown
    private float countdown =2f; //takes 2 seconds to spawn first wave

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveNumberText;

    private int waveIndex = 1; 

    private void Update() {
        if (!GameManager.gameIsOver){
            if (EnemiesAlive > 0){
                // dont spawn next wave until all enemies dead
                return;
            }

            //manage time
            if (countdown <= 0f) //countdown reaches 0
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves; //reset countdown on wave spawn
                return;
            }

            countdown -= Time.deltaTime; // decrase countdown constantly
            waveCountdownText.text = Mathf.Round(countdown).ToString();
        }
    }

    //coroutine 
    IEnumerator SpawnWave() {
        
        PlayerStats.Rounds++;  
        Debug.Log(PlayerStats.Rounds);
         
        waveNumberText.text = (waveIndex.ToString());

        Wave wave = waves[waveIndex];

        for (int i=0; i< wave.count; i++){
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); //time between enemies in a wave
        }
        waveIndex ++; // next wave

        if (waveIndex == waves.Length){ //last wave
            this.enabled = false; 
        }
    }

	//spawn enemy at spawnpoint
    void SpawnEnemy(GameObject enemy){

		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive ++; 
		
    }
}
