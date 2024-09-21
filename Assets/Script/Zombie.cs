using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IEnemy
{
    public void Attack()
    {
        Debug.Log("Zombie attack!");
    }

    public void Explode()
    {
        Debug.Log("Zombie explode!");
    }

    public void Move()
    {
        Debug.Log("Zombie move!");
    }
}
