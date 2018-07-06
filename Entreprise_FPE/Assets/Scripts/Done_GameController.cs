using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace;

public class Done_GameController : MonoBehaviour {
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int maxWaves;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public bool twoPlayers;

    private bool gameOver;
    private bool restart;
    private int score;

    [Header("Boss")]
    public bool HasBoss;
    public GameObject boss;
    public Vector3 spawnValuesBoss;

    private bool IsSpawning = true;

    void Start() {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();

        if (twoPlayers) {

            hazardCount *= 2;
            spawnWait *= 0.5f;
        }

        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);


        while (IsSpawning) {

            int waveCount = 0;

            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            waveCount++;
            Debug.Log("waveCount: " + waveCount);
            Debug.Log("maxWaves: " + maxWaves);

            if (waveCount >= maxWaves) {

                IsSpawning = false;

                if (HasBoss)
                    SpawnBoss();
            }


            yield return new WaitForSeconds(waveWait); //Time before the next wave -> Determine the length of the game.

            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void SpawnBoss() {

        SoundManagerFPE.m_Instance.PlayMusic(1);

        Vector3 spawnPosition = new Vector3(spawnValuesBoss.x, spawnValuesBoss.y, spawnValuesBoss.z);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(boss, spawnPosition, spawnRotation);

    }
}