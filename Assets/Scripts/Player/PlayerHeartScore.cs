using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartScore : MonoBehaviour
{
    public static int playerHeartScore = 3;
    TextMeshProUGUI textHeart;
    void Start()
    {
        textHeart = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textHeart.text = playerHeartScore.ToString();
    }
}
