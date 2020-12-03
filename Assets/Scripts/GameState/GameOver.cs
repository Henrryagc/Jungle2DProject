using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
   public Button btnRestart;

	void Start () {
		btnRestart.onClick.AddListener(TaskOnClick);
	}	
	
	void TaskOnClick(){
        PlayerHeartScore.playerHeartScore = 3;
		SceneManager.LoadScene("Main");
	}
}
