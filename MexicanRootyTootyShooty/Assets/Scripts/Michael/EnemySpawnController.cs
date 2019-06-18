using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public float minSpawnTime;
    public float maxSpawnTime;

    public int enemyKillCounter = 0;
    public int enemySpawnCounter = 0;
    public int waveCounter = 0;

    public int enemiesPerWave = 5;

    public float roundTimer = 30;

    public float rounderTimerIncreaser = 15;

    public float countdown;

    public float[] t;


    public GameObject enemyPrefab;

    public Vector3[] enemySpawnerPosition;

    public Transform[] enemySpawnerList;
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

        //this will start a new wave when all enemies are killed even if the other 
        if (enemyKillCounter >= enemiesPerWave)
        {
            waveIsActive = false;
            StartCoroutine(WaitAndStartNewWave(5));

            waveIsActive = true;

            waveCounter++;

            enemySpawnCounter = 0;
            enemiesPerWave += 5;
        }

        //this will start a new wave automatically if the player doesnt kill all the enemies
        if (enemySpawnCounter >= enemiesPerWave)
        {
            if (waveIsActive) { countdown = roundTimer; }

            waveIsActive = false;

            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                StartCoroutine(WaitAndStartNewWave(0));
                for (int i = 0; i < enemySpawnerList.Length; i++)
                {
                    SetRandomTime(i);
                }
                waveIsActive = true;

                waveCounter++;

                enemySpawnCounter = 0;
                enemiesPerWave += 5;
            }
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
            print("WaitAndPrint " + Time.time);



        }
    }


}

