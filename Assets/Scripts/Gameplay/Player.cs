using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance;

	[Header("References")]
	public Ball Ball;
	public Decoy Decoy;
	public GameObject KinkIndicatorPrefab;

	[Header("Game")]
	public int ThumbLimit = 3;

	[Header("Lines")]
	public float LineWidth = 1f;
	public Color LineColor = Color.white;
	public Material LineMaterial;

	[Header("Decoy")]
	public float MoveSpeed = 1f;

	private List<Vector3> _positions = new List<Vector3>();

    void Start()
    {
		if (instance != this)
		{
			Destroy(instance);
			instance = this;
		}

		_positions.Add(transform.position);
		_positions.Add(Vector3.zero);
	}
	
    void Update()
    {
		_positions[_positions.Count - 1] = Ball.transform.position;
		Debug.LogError(_positions.Count);
	}






	// Thumb controls
	public void AddThumb(Vector3 thumbPosition)
	{
		if (_positions.Count < ThumbLimit + 2)
		{
			_positions.Add(Ball.transform.position);
			_positions[_positions.Count - 2] = thumbPosition;

			float _distance = 0;
			for (int i = _positions.Count - 2; i < _positions.Count - 1; i++)
				_distance += (_positions[i + 1] - _positions[i]).magnitude;
			Ball.SetCenter(thumbPosition, _distance);
		}
	}

	public void PopThumb()
	{
		if (_positions.Count > 2)
		{
			float _distance = 0;
			for (int i = _positions.Count - 3; i < _positions.Count - 1; i++)
				_distance += (_positions[i + 1] - _positions[i]).magnitude;
			_positions.RemoveAt(_positions.Count - 2);
			Ball.SetCenter(_positions[_positions.Count - 2], _distance);
		}
	}

	public List<Vector3> GetPositions()
	{
		return _positions;
	}

	public int GetThumbCount()
	{
		return _positions.Count - 2;
	}
}
