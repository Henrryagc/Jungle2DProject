using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float rayDist;
    private bool movingRight;
    public Transform groundDetect;
    public static float EnemyDamage = .2f;


    // Update is called once per frame

    public Transform playerTransform;


    // TextMEssage
    public GameObject textMessageObject;


    void Update()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        if (groundCheck == false)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Objeto con tag 
        switch (collision.gameObject.tag)
        {
            case "Player":
                // Si Enemy.y es menor a Player.y en la colision
                bool isTrue = transform.position.y + .5f <= playerTransform.position.y;
                if (isTrue)
                {
                    // Deshabilitar componentes
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<Collider2D>().enabled = false;
                    //Destruir objeto
                    Destroy(this);
                    if (textMessageObject)
                    {
                        ShowTextMessage();
                    }
                }
                break;
        }
    }

    public void ShowTextMessage()
    {
        // Instanciar el objeto
        GameObject text = Instantiate(textMessageObject);
        // Posición en la que se va a mostrar
        text.transform.position = new Vector3(gameObject.transform.position.x,
                                              gameObject.transform.position.y + 2f,
                                              gameObject.transform.position.z);
        // Transforma el texto de forma aleatoria
        text.transform.Rotate(Random.Range(-20f, 20f),
                              Random.Range(-20f, 20f),
                              Random.Range(-20f, 20f),
                              Space.Self);

        text.transform.SetParent(transform);
    }
}
