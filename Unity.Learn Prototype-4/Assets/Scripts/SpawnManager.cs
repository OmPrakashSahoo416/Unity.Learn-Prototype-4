using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnPos = 9f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    public GameObject firePowerPrefab,focalPoint;
    private PlayerController playerControllerScript;
    private Enemy enemy;
    public Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            Instantiate(firePowerPrefab, GenerateSpawnPosition(), firePowerPrefab.transform.rotation);
            bulletRb.AddForce(focalPoint.transform.forward*1000);
        }
       
    }
    void SpawnEnemyWave(int enemyToSpawn)
    { 
        for(int i=0;i<enemyToSpawn;i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float randomPosX = Random.Range(-spawnPos, spawnPos);
        float randomPosZ = Random.Range(-spawnPos, spawnPos);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomPos;
    }
}
