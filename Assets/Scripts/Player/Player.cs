using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Creando variables globales
    public float MovementSpeed;
    public float JumpForce;
    public Animator animator;
    public new Rigidbody2D rigidbody;
    
    public Collider2D collider2d;
    
    private Transform transformHealth;
    [SerializeField] private PlayerHealth healthBar;
    private float playerHealth = 1f;

    public TextMeshProUGUI textStrawberry, textOrange, textAllFruit;

    private int playerFoodStrawberry, playerFoodOrange, totalFood;
    // Menu
    public GameObject myPanel;
    public Button btnResume;
    // Enemy
    public Transform enemyTransform;
    
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        transformHealth = GameObject.FindGameObjectWithTag("PlayerHealth").transform;
        btnResume.onClick.AddListener(menuGameState);
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        // Girar, si movimiento no esta en cero
        if (!Mathf.Approximately(0, movement))
        {
            // Hacer que el jugador gire su cuerpo (Derecha o izquierda)
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        // Se preciona la espaciadora del teclado y que no salte en el aire.
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.01f)
        {
            // Hacer que el jugador salte
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
		    Time.timeScale = 0;
            myPanel.SetActive(true);
        }	

        if (Input.GetKeyDown(KeyCode.R)){
            Time.timeScale = 1;
            myPanel.SetActive(false);
        }
    }

    // Evento para reiniciar el juego "Muerte"
    private void OnTriggerEnter2D(Collider2D collision) {
        //
        switch (collision.gameObject.tag)
        {
            // Si cae muere
            case "killZone":
                SceneManager.LoadScene("Main");
                // Se reinicia las manzanas recogidas por el jugador
                PlayerHeartScore.playerHeartScore -= 1;
                break;

            // Si tropieza con el enemigo
            case "touchEnemy":

            bool isTrue = enemyTransform.position.y <= transform.position.y;
            if (!isTrue){                
                 // Disminuir la vida del jugador
                playerHealth -= Enemy.EnemyDamage;                                
                // Si la vida es menor a 0.1f, termina el juego
                if (playerHealth < 0.1f)
                {
                    SceneManager.LoadScene("Main");

                    PlayerHeartScore.playerHeartScore -= 1;
                }
                // Enviar el daño a la barra de vida
                healthBar.setScaleSize(playerHealth);
            }               
                break;
            case "heart":
                //playerHeart += 1;
                PlayerHeartScore.playerHeartScore += 1;
                //textHeart.text = playerHeart.ToString();
                break;
            case "strawberry":
                playerFoodStrawberry += PlayerFood.playerFoodStrawberry;
                textStrawberry.text = playerFoodStrawberry.ToString();
                //
                totalFood += PlayerFood.playerFoodStrawberry;
                break;
            case "orange":
                playerFoodOrange += PlayerFood.playerFoodOrange;
                textOrange.text = playerFoodOrange.ToString();
                //
                totalFood += PlayerFood.playerFoodOrange;
                break;
            default:
                break;
        }

        // Número de frutas en la canasta
        textAllFruit.text = (playerFoodStrawberry + playerFoodOrange).ToString();

        if (totalFood >= 50)
        {
            totalFood = 0;
            playerHealth += 0.2f;

            if (playerHealth > 1.0f)
            {
                playerHealth = 1.0f;
            }

            // Enviar el daño a la barra de vida
            healthBar.setScaleSize(playerHealth);
        }

        // Cantidad de juegos "Corazones" = 0
        if (PlayerHeartScore.playerHeartScore == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    private void menuGameState(){

            // Reanudar el juego
            Time.timeScale = 1;

    }
}
