using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Text HighScoreText;

	int highestScore = 0;

    void Start()
    {
		highestScore = SaveGame.LoadScore();
		HighScoreText.text = highestScore.ToString();
    }

	public void PlayGame()
	{
		SceneManager.LoadSceneAsync("Gameplay");
	}
}
