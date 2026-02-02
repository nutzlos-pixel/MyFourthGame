using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] enemyPrefab;
    public GameObject powerUp;
    private float startDelay = 2.0f;
    private float spawnInterval = 3.0f;
    private float spawnRangeX = 5.0f;
    private float spawnRangeZ = 7.0f;
    private int enemyCount;
    private int waveNumber;

    void Start()
    {
        SpawnEnemy(waveNumber);
    }
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            SpawnEnemy(waveNumber);
            waveNumber++;
            if (waveNumber > 1)
            { SpawnPowerUp(); }
        }
    }

    private void SpawnEnemy(int enemiesToSpawn)
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
            
        }
        
    }
    private void SpawnPowerUp()
    {
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

}
