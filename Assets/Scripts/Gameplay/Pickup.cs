using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	private CircleCollider2D _collider;
	private bool _isInactive = false;
	private float _inactivityTime = 0.8f;
	private float _timer = 0f;

    void Start()
    {
		_collider = GetComponent<CircleCollider2D>();
    }

	void Update()
	{
		// Scaling
		if (_isInactive)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 8f);
			_timer += Time.deltaTime;
			if (_timer > _inactivityTime)
				Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Collision with player
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.instance.OnPickupHit();
			_isInactive = true;
		}
	}
}
