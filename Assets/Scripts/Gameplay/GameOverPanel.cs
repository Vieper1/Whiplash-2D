using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
	[Header("References")]
	public Text MyScoreText;
	public Text HighScoreText;

	public void RefreshStats(int _currentScore, int _highScore)
	{
		MyScoreText.text = _currentScore.ToString();
		HighScoreText.text = _highScore.ToString();
	}

	public void BackToHome()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
