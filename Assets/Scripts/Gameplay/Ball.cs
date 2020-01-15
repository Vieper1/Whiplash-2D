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
	private TrailRenderer _trailRenderer;
	private float _trailFallRate;


	void Start()
	{
		_initialRadius = Radius;
		_currentSpeed = Speed;
		_targetSpeed = Speed;
		_trailRenderer = GetComponent<TrailRenderer>();
		_trailFallRate = Player.instance.TrailFallRate;
	}

	void Update()
    {
		_time += Time.deltaTime * _currentSpeed;

		// Position
		_currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, Time.deltaTime);
		transform.position = new Vector3(
			Center.x + Mathf.Cos(_time) * Radius,
			Center.y + Mathf.Sin(_time) * Radius);


		// Trail
		float _newTrailTime = _trailRenderer.time - _trailFallRate * Time.deltaTime;
		if (_newTrailTime > 0) _trailRenderer.time = _newTrailTime;
		if (!_isTrailActive && _time > 0.2f)
		{
			_isTrailActive = true;
			_trailRenderer.enabled = true;
		}
	}

	public TrailRenderer GetTrailRenderer()
	{
		return _trailRenderer;
	}

	public void SetCenter(Vector3 newCenter, float newRadius)
	{
		Center = newCenter;
		List<Vector3> _positions = Player.instance.GetPositions();

		Radius = newRadius;

		_targetSpeed = _initialRadius / Radius * Speed;
	}

	public float GetInitialRadius()
	{
		return _initialRadius;
	}
}
