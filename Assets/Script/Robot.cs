using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IEnemy
{
    public float lowerBoundry = -5.5f;
    public float upperBoundry = 5.5f;

    public float speed = 2.0f;

    public GameObject explosionAnimation;
    public GameObject robotLaser;
    public Collider2D playerLaser;

    void Start()
    {
        Attack();
    }

    void Update() 
    {
        Move();
    }

    public void Attack()
    {
        StartCoroutine(shootRobotLaser());
    }

    public void Explode()
    {
        Instantiate(explosionAnimation, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void Move()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));

        if (transform.position.y < lowerBoundry) 
        {
            transform.position = new Vector2(transform.position.x, upperBoundry);
        }
    }

    IEnumerator shootRobotLaser()
    {
        while(true)
        {
            createRobotLaser();
            yield return new WaitForSeconds(1.5f);
        }
    }

    void createRobotLaser()
    {
        if (transform.position.y < 4.5f) {
            Instantiate(robotLaser, transform.position + new Vector3(0, -0.8f, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Laser")) { 
            Explode();
        }
    }
}
