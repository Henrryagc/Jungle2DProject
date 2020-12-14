using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
   public Button btnRestart;
    public Button btnQuit;

	void Start () {
		btnRestart.onClick.AddListener(TaskOnClick);
        btnQuit.onClick.AddListener(QuitGame);
    }	
	
	void TaskOnClick(){
        PlayerHeartScore.playerHeartScore = 3;
		SceneManager.LoadScene("Main");
	}

    void QuitGame()
    {
        Application.Quit();
    }
}
