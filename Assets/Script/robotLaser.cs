using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotLaser : MonoBehaviour
{
    public float speed = 7.0f;
    public float yLimit = -5.5f;

    void Start()
    {
        transform.Rotate(0.0f, 0.0f, 180.0f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));

        if (transform.position.y < yLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
