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

	void Start()
	{
		_initialRadius = Radius;
		_currentSpeed = Speed;
	}

	void Update()
    {
		_time += Time.deltaTime;

		// Position
		_currentSpeed = Mathf.Lerp(_currentSpeed, Speed, Time.deltaTime);
		transform.position = new Vector3(
			Center.x + Mathf.Cos(_time * _currentSpeed) * Radius,
			Center.y + Mathf.Sin(_time * _currentSpeed) * Radius);


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
		//float _distance = 0;
		//for (int i = positionStartIndex; i < positionEndIndex; i++)
		//{
		//	_distance += (_positions[i + 1] - _positions[i]).magnitude;
		//}
		//Radius = _distance;

		Radius = newRadius;

		//Speed *= _initialRadius / Radius;
	}
}
