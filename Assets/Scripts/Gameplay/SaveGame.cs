using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static void SaveScore(int i_score)
	{
		int savedScore = PlayerPrefs.GetInt("Score", -1);
		if (i_score > savedScore)
		{
			PlayerPrefs.SetInt("Score", savedScore);
		}
	}

	public static int LoadScore()
	{
		return PlayerPrefs.GetInt("Score", 0);
	}
}
