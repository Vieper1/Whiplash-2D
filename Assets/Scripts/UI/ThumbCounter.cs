using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbCounter : MonoBehaviour
{
	[Header("References")]
	public Player _player;

	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
    {
		text.text = _player.GetThumbCount() + "/" + _player.ThumbLimit;
    }
}
