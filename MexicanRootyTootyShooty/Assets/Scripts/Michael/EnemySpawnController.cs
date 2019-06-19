using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public float minSpawnTime;
    public float maxSpawnTime;

    public int enemyKillCounter = 0;
    public int enemySpawnCounter = 0;
    public int waveCounter = 1;

    public int enemiesPerWave = 5;

    public float roundTimer = 30;

    public float rounderTimerIncreaser = 15;

    public float waveCountdown;
    public float killCountdown = 0;
    public float killRoundTimer = 5;

    public float[] t;


    public GameObject enemyPrefab;

    public Vector3[] enemySpawnerPosition;

    public Transform[] enemySpawnerList;
    public bool isKillTimerUp = true;
    public bool waveIsActive = true;
    public bool timerUp;

    void Start() {

        for (int i = 0; i < enemySpawnerList.Length; i++)
        {
            enemySpawnerPosition[i] = enemySpawnerList[i].position;

            //SpawnInstance(i);

            SetRandomTime(i);
        }


    }

    void Update()
    {


        for (int i = 0; i < enemySpawnerList.Length; i++)
        {
            t[i] -= Time.deltaTime;

            if (t[i] <= 0 && waveIsActive)
            {
                SpawnInstance(i);
                SetRandomTime(i);
            }
        }

        //this will start a new wave when all enemies are killed even if the other timer is running
        if (enemyKillCounter >= enemiesPerWave)
        {
            if (isKillTimerUp) { killCountdown = killRoundTimer; }
            isKillTimerUp = false;
            waveIsActive = false;

            killCountdown -= Time.deltaTime;

            waveCountdown = 5;
            if (killCountdown <= 0) { EndOfWave(); }
        }

        //this will start a new wave automatically if the player doesn't kill all the enemies
        if (enemySpawnCounter >= enemiesPerWave)
        {
            if (waveIsActive) { waveCountdown = roundTimer; }

            waveIsActive = false;
            
            waveCountdown -= Time.deltaTime;

            if (waveCountdown <= 0) { EndOfWave(); }
        }

        if ((waveCounter == 10 && timerUp) || (waveCounter == 20 && timerUp))
        {
            roundTimer += rounderTimerIncreaser;
            timerUp = false;
        }
        if (waveCounter == 11) { timerUp = true; }

    }

    void SetRandomTime(int i)
    {
        t[i] = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnInstance(int i)
    {
        enemySpawnCounter++;
        Instantiate(enemyPrefab, enemySpawnerPosition[i], Quaternion.identity);
    }

    private IEnumerator WaitAndStartNewWave(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
    void EndOfWave()
    {
        for (int i = 0; i < enemySpawnerList.Length; i++)
        {
            SetRandomTime(i);
        }
        waveIsActive = true;

        waveCounter++;

        enemyKillCounter = 0;
        enemySpawnCounter = 0;

        enemiesPerWave += 5;
        isKillTimerUp = true;
    }


}

