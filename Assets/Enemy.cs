using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public GameObject deathEffect;

	public float health = 4f;

	public static int EnemiesAlive = 0;

	void Start()
	{
		EnemiesAlive++;
	}

	void FixedUpdate()
	{
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
		{
			// Object is out of camera view
			Die();
		}
	}

	void OnCollisionEnter2D(Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--;
		if (EnemiesAlive <= 0)
			Debug.Log("LEVEL WON!");

		Destroy(gameObject);
	}

}
