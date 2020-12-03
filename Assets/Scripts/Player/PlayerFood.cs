using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    public static int playerFoodStrawberry = 5;
    public static int playerFoodOrange = 10;

    private void OnTriggerEnter2D(Collider2D collision) {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, .5f);
    }
}
