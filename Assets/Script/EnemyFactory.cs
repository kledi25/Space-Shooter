using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
	public GameObject zombiePrefab;
	public GameObject robotPrefab;
	
	public IEnemy SpawnEnemy (string enemyType)
	{
		GameObject enemyObj = null;
		switch(enemyType)
		{
 			case "Zombie":
                enemyObj = Instantiate(zombiePrefab, transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 6.0f, 0), Quaternion.identity);
                break; 
            case "Robot": 
                enemyObj = Instantiate(robotPrefab, transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 6.0f, 0), Quaternion.identity); 
                break; 
            default: 
                Debug.LogError("Unbekannter Gegnertyp: " + enemyType); 
                return null; 
		}
		return enemyObj.GetComponent<IEnemy>();
	}

	void Update()
	{
		
	}
}
