using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject HighScoreText;

	int highestScore = 0;

    void Start()
    {
		highestScore = SaveGame.LoadScore();
		if (highestScore == 0)
		{
			HighScoreText.SetActive(false);
		}
    }

    void Update()
    {
        
    }

	public void PlayGame()
	{
		SceneManager.LoadSceneAsync("Gameplay");
	}
}
