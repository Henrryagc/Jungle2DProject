using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeRemaining = 75;

    void Start()
    {
        timeText.text = timeRemaining.ToString();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining <= 0) {
            // vuelve a cargar el juego
            SceneManager.LoadScene("Main");

            //Disminuye un corazon
            PlayerHeartScore.playerHeartScore -= 1;
        }
    }
}
