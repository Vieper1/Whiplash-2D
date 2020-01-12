using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public float Lifetime = 10f;

	private float _time = 0f;
	private Vector3 _initialScale;
	private CircleCollider2D _collider;
	private bool _isInactive = false;
	private float _inactivityDuration = 0.8f;
	private float _inactivityTime = 0f;

    void Start()
    {
		_collider = GetComponent<CircleCollider2D>();
		_initialScale = transform.localScale;
		transform.localScale = Vector3.zero;
    }

	void Update()
	{
		_time += Time.deltaTime;

		// Scaling
		if (_isInactive || _time > Lifetime)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 8f);
			_inactivityTime += Time.deltaTime;
			if (_inactivityTime > _inactivityDuration)
				Destroy(gameObject);
		}
		else
		{
			transform.localScale = Vector3.Lerp(transform.localScale, _initialScale, Time.deltaTime * 8f);
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
