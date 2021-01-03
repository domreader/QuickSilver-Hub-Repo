using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool isGrounded;
    bool isWalking;
    bool isPaused = false;

    GameObject player;

    BoxCollider2D restaurantDoor;

    [SerializeField]
    int movementSpeed;
    
    int jumpPower;

    float x;
    float y;

    Rigidbody2D rb2D;
    Animator anim;

    public Collider2D[] colliders;
    public GameObject pauseMenu;

    public int conversationListener;

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        player = this.gameObject;

        conversationListener = 0;
        
    }

    void Update()
    {
        playerWalking();
        playerTeleport();
        playerInteractions();

      
    }


    void playerWalking()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rb2D.velocity = new Vector2(x, y) * movementSpeed;

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {

            GetComponent<Animator>().SetBool("isWalking", true);
            transform.rotation = Quaternion.Euler(0, 180f, 0);


        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);

        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {

            GetComponent<Animator>().SetBool("isWalking", true);
            transform.rotation = Quaternion.Euler(0, 0f, 0);


        }

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }




    }

    void playerInteractions()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Debug.Log("Pause Game");

            Time.timeScale = 0f;

            isPaused = true;

            pauseMenu.GetComponent<Canvas>().enabled = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == !false)
        {
            Debug.Log("Resume Game");

            Time.timeScale = 1f;

            isPaused = false;

            pauseMenu.GetComponent<Canvas>().enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Stealing Item");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Opening Backpack");
        }
    }

    void playerTeleport()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(3.96f, 52.09f);
        }

       

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = new Vector3(-113.08f, 41.44f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            transform.position = new Vector3(65.06f, -19.16f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            transform.position = new Vector3(80.04f, 33.41f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            transform.position = new Vector3(-113.08f, 41.44f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            transform.position = new Vector3(-113.08f, 41.44f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            transform.position = new Vector3(-113.08f, 41.44f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("To restaurant");
        }

    }


    void progressManager()
    {

        if (conversationListener == 1)
        {
            Debug.Log("1st conversation witnessed");
        }

        if(conversationListener == 2)
        {
            Debug.Log("2nd conversation witnessed");
        }


    }

}

