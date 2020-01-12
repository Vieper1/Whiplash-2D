using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{
	public float ThumbRatioDeadzone = 0.1f;
	public float _thumbRatio;

	private Vector3 _initialScale;

	void Start()
	{
		_initialScale = transform.localScale;
		_thumbRatio = ThumbRatioDeadzone;
	}

	void Update()
    {
		// Scale
		if (Player.instance.GetPositions().Count == Player.instance.ThumbLimit + 2)
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 4f);
		else
			transform.localScale = Vector3.Lerp(transform.localScale, _initialScale, Time.deltaTime * 4f);


		// Update Position
		List<Vector3> _positions = Player.instance.GetPositions();
		if (_positions.Count > 1)
		{
			Vector3 _lastThumbPosition = _positions[_positions.Count - 2];
			Vector3 _ballPosition = _positions[_positions.Count - 1];
			
			transform.position = _lastThumbPosition + (_ballPosition - _lastThumbPosition) * _thumbRatio;
		}
	}


	public void IncrementRatio()
	{
		float _newRatio = _thumbRatio + Time.deltaTime * Player.instance.MoveSpeed;
		if (_newRatio < 1f - ThumbRatioDeadzone)
			_thumbRatio = _newRatio;
	}

	public void DecrementRatio()
	{
		float _newRatio = _thumbRatio - Time.deltaTime * Player.instance.MoveSpeed;
		if (_newRatio > ThumbRatioDeadzone)
			_thumbRatio = _newRatio;
	}
}
