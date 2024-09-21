using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerShip;
    public GameObject Laser;

    public GameObject explosionAnimation;
    public Collider2D enemyLaser;

    public float fireRate = 0.5f;
    public float nextFireTime = 1.0f;

	Vector2 direction;

	[SerializeField] private float speed = 5.0f;
	public float minX = -14f, maxX = 14f, minY = -4.5f, maxY = 4.5f;
 
	void Update()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0);

		Vector3 moveDirection = Vector3.zero;
		//Move up
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			moveDirection += transform.up;
		}
		//Move down
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			moveDirection += -transform.up;
		}
 
		//Move right
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			moveDirection += transform.right;
		}
 
		//Move left
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			moveDirection += -transform.right;
		}
		if(moveDirection.magnitude > 0)
		{
			transform.Translate(moveDirection.normalized * (speed * Time.deltaTime));
		}

		if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time >= nextFireTime) {
                ShootLaser();
                nextFireTime += Time.time - nextFireTime + fireRate;
            }
        }

	}
	void ShootLaser()
    {
        Instantiate(Laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LaserEnemy") || other.CompareTag("Enemy"))
        {
            Instantiate(explosionAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}