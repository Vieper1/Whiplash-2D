using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
	private bool _isUpButtonHeld;
	private bool _isDownButtonHeld;

    void Update()
    {
        if (_isUpButtonHeld)
		{
			Player.instance.Input_Up();
		}

		if (_isDownButtonHeld)
		{
			Player.instance.Input_Down();
		}
    }

	public void UpButtonHold(bool value)
	{
		_isUpButtonHeld = value;
	}

	public void DownButtonHold(bool value)
	{
		_isDownButtonHeld = value;
	}
}
