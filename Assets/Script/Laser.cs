using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 7.0f;
    public float yLimit = 5.5f;

    public Collider2D enemyObject;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));

        if(transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
