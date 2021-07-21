using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnPos = 9f;
    // Start is called before the first frame update
    void Start()
    {
       
        Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private Vector3 GenerateSpawnPosition()
    {
        float randomPosX = Random.Range(-spawnPos, spawnPos);
        float randomPosZ = Random.Range(-spawnPos, spawnPos);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomPos;
    }
}
