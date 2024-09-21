using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public float spawnSpeed = 5.0f;
    public float spawnSpeedIncrease = 25.0f;

    void Start()
    {
        StartCoroutine(createEnemyObjects());
    }

    void SpawnEnemies()
    {
        IEnemy robot = enemyFactory.SpawnEnemy("Robot");
    }
    
    IEnumerator createEnemyObjects()
    {
        while (true)
        {
            if (Time.time >= spawnSpeedIncrease)
            {
                if (spawnSpeed > 1.0f)
                {
                    spawnSpeed -= 1.0f;
                    spawnSpeedIncrease += 10.0f;
                }
                else
                {
                    spawnSpeed = 1.0f;
                }
            }

            SpawnEnemies();
            yield return new WaitForSeconds(spawnSpeed);           
        }
    }
}
