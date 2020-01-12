using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Vector3 Center;
	public float Radius = 10f;
	public float Speed = 1f;
	
	private float _time = 0f;

	private bool _isTrailActive;
	private float _initialRadius;
	private float _currentSpeed;
	private float _targetSpeed;


	void Start()
	{
		_initialRadius = Radius;
		_currentSpeed = Speed;
		_targetSpeed = Speed;
	}

	void Update()
    {
		_time += Time.deltaTime * _currentSpeed;
		//_time += Time.deltaTime;													// Replace to see weird effect

		// Position
		_currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, Time.deltaTime);
		transform.position = new Vector3(
			Center.x + Mathf.Cos(_time/* * _currentSpeed*/) * Radius,	//			// Replace to see weird effect
			Center.y + Mathf.Sin(_time/* * _currentSpeed*/) * Radius);


		// Trail
		if (!_isTrailActive && _time > 0.2f)
		{
			_isTrailActive = true;
			GetComponent<TrailRenderer>().enabled = true;
		}
	}

	public void SetCenter(Vector3 newCenter, float newRadius)
	{
		Center = newCenter;
		List<Vector3> _positions = Player.instance.GetPositions();

		Radius = newRadius;

		//_targetSpeed *= _initialRadius / Radius;						//			// Replace to see weird effect
		_targetSpeed = _initialRadius / Radius * Speed;
	}

	public float GetInitialRadius()
	{
		return _initialRadius;
	}
}
