using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public float enemySpeed;
    public float rayDist;
    private bool movingRight;
    public Transform groundDetect;
    public static float EnemyDamage = .2f;
    // Update is called once per frame
    internal Collider2D _collider;

    public Transform playerTransform;


    void Awake(){
        _collider = GetComponent<Collider2D>();
    }


    void Update()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        if (groundCheck == false){
            if (movingRight)
            {
                movingRight = false;
                transform.eulerAngles = new Vector3(0, 180, 0);
            } 
            else
            {
                movingRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Objeto con tag 
        switch (collision.gameObject.tag){
            case "Player":
            // Si Enemy.y es menor a Player.y en la colision
            bool isTrue = transform.position.y <= playerTransform.position.y;
            if (isTrue){
                GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject, 1f);
            }
            break;
        }
    }
}
