using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	private CircleCollider2D _collider;

    void Start()
    {
		_collider = GetComponent<CircleCollider2D>();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.instance.OnPickupHit();
		}
	}
}
