using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    float spawnInterval = 3;
    float currentSpawnTime = 0;

    float bigCountdown = 120;
    float currentBigTime = 0;

    float xPos;
    float zPos;


    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        currentBigTime += Time.deltaTime;

        if(currentSpawnTime >= spawnInterval)
        {
            Spawn();
            currentSpawnTime = 0;
        }

        if(spawnInterval >= 1.5f)
        {
            if (currentBigTime >= bigCountdown)
            {
                spawnInterval -= .1f;
                currentBigTime = 0;
            }
        }
        
        
    }

    private void Spawn()
    {
        xPos = Random.Range(-26f, 18f);
        zPos = Random.Range(-15f, 17f);
        Instantiate(enemyPrefab, new Vector3(xPos, 0f, zPos), Quaternion.identity);
    }

}
