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

    void Start(){
        Debug.Log("WaveSpawner.Start() spawnPoint="+spawnPoint+"-------------------------");
        PlayerStats.Rounds = 0;
    }

    private void Update() {
        if (!GameManager.gameIsOver){
            if (EnemiesAlive > 0){
                // dont spawn next wave until all enemies dead
                return;
            }

            //manage time
            if (countdown <= 0f) //countdown reaches 0
            {
                Debug.Log("WaveSpawner() countdown reached 0 SPAWN WAVE @@@@@@@@");
                StartCoroutine(SpawnWave());
                //reset countdown on wave spawn
                countdown = timeBetweenWaves * ModeSelector.GetDifficulty().timeBetweenWavesFactor ; 
                Debug.Log("WaveSpawner() countdown reset to " + countdown + " for the next round");
                return;
            }

            countdown -= Time.deltaTime; // decrase countdown constantly
            waveCountdownText.text = Mathf.Round(countdown).ToString();
        }
    }

    //coroutine 
    IEnumerator SpawnWave() {
        
        PlayerStats.Rounds++;  
        Debug.Log("SpawnWave() Rounds=" + PlayerStats.Rounds + " waveIndex=" + waveIndex);
        Wave wave = waves[PlayerStats.Rounds-1];
         
        if (PlayerStats.Rounds == waves.Length || wave.enemy == null){ //last wave
            Debug.Log("SpawnWave() All Level Complete!!!!!!!!!!!!!!");
            this.enabled = false; 
        }
        else {
            waveNumberText.text = PlayerStats.Rounds.ToString();


            // increase wave size based on difficulty
            wave.count = (int) (wave.count * ModeSelector.GetDifficulty().waveSizeFactor);
            Debug.Log("SpawnWave() wave.count=" + wave.count);

            for (int i=0; i< wave.count; i++){
                Debug.Log("SpawnWave() wave.enemy=" + wave.enemy);
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate); //time between enemies in a wave
            }
            waveIndex ++; // next wave

            Debug.Log("SpawnWave() waveIndex=" + waveIndex + "Rounds=" + PlayerStats.Rounds + " END <<<<<<<<<<<<<<<<<<<<");
        }
    }

	//spawn enemy at spawnpoint
    void SpawnEnemy(GameObject enemy){
        Debug.Log("SpawnEnemy() enemy=" + enemy + " spawnPoint=" + spawnPoint );
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive ++; 
		
    }
}
