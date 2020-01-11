﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{
	public float ThumbRatioDeadzone = 0.1f;

	private float _thumbRatio;
	private Vector3 _initialScale;

	void Start()
	{
		_initialScale = transform.localScale;
		_thumbRatio = ThumbRatioDeadzone;
	}

	void Update()
    {
		// Input
		if (Input.GetKey(KeyCode.RightArrow))
			IncrementRatio();

		if (Input.GetKey(KeyCode.LeftArrow))
			DecrementRatio();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Player.instance.AddThumb(transform.position);
			_thumbRatio = ThumbRatioDeadzone;
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
			Player.instance.PopThumb();


		// Scale
		if (Player.instance.GetPositions().Count == Player.instance.ThumbLimit + 2)
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
		else
			transform.localScale = Vector3.Lerp(transform.localScale, _initialScale, Time.deltaTime);


		// Update Position
		List<Vector3> _positions = Player.instance.GetPositions();
		if (_positions.Count > 1)
		{
			Vector3 _lastThumbPosition = _positions[_positions.Count - 2];
			Vector3 _ballPosition = _positions[_positions.Count - 1];
			
			transform.position = _lastThumbPosition + (_ballPosition - _lastThumbPosition) * _thumbRatio;
		}
	}


	void IncrementRatio()
	{
		float _newRatio = _thumbRatio + Time.deltaTime * Player.instance.MoveSpeed;
		if (_newRatio < 1f - ThumbRatioDeadzone)
			_thumbRatio = _newRatio;
	}

	void DecrementRatio()
	{
		float _newRatio = _thumbRatio - Time.deltaTime * Player.instance.MoveSpeed;
		if (_newRatio > ThumbRatioDeadzone)
			_thumbRatio = _newRatio;
	}
}