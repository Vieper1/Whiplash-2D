using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance;

	[Header("References")]
	public Ball Ball;
	public Decoy Decoy;
	public GameObject ThumbIndicatorPrefab;

	[Header("Game")]
	public int ThumbLimit = 3;

	[Header("Lines")]
	public float LineWidth = 1f;
	public Color LineColor = Color.white;
	public Material LineMaterial;

	[Header("Decoy")]
	public float MoveSpeed = 1f;

	private List<Vector3> _positions = new List<Vector3>();
	private List<GameObject> _thumbIndicators = new List<GameObject>();
	private int _score = 0;

    void Start()
    {
		if (instance != this)
		{
			Destroy(instance);
			instance = this;
		}

		_positions.Add(transform.position);
		_positions.Add(Vector3.zero);

		// Aspect Ratio Size Control

	}
	
    void Update()
    {
		_positions[_positions.Count - 1] = Ball.transform.position;
		PollInput();
	}




	// Pickups
	public void OnPickupHit()
	{
		_score += _positions.Count - 1;
	}

	public int GetScore()
	{
		return _score;
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

			GameObject thumb = Instantiate(ThumbIndicatorPrefab, thumbPosition, Quaternion.identity);
			thumb.transform.localScale = new Vector3(0.025f, 0.025f, 1f);
			_thumbIndicators.Add(thumb);
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

			int _removeAtIndex = _thumbIndicators.Count - 1;
			GameObject _thumb = _thumbIndicators[_removeAtIndex];
			_thumbIndicators.RemoveAt(_removeAtIndex);
			Destroy(_thumb);
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







	// Input Mapping
	void PollInput()
	{
		if (Input.GetKey(KeyCode.RightArrow))
			Input_Up();
		if (Input.GetKey(KeyCode.LeftArrow))
			Input_Down();
		if (Input.GetKeyDown(KeyCode.Space))
			Input_AddThumb();
		if (Input.GetKeyDown(KeyCode.LeftControl))
			Input_RemoveThumb();
	}

	public void Input_Up()
	{
		Decoy.IncrementRatio();
	}

	public void Input_Down()
	{
		Decoy.DecrementRatio();
	}

	public void Input_AddThumb()
	{
		AddThumb(Decoy.transform.position);
		Decoy._thumbRatio = Decoy.ThumbRatioDeadzone;
	}

	public void Input_RemoveThumb()
	{
		PopThumb();
	}
}
