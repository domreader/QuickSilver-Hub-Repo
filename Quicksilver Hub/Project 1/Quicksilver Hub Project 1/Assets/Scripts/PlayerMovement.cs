using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    Animator animator;

    public GameObject player;
    static bool isMoving;
    static bool isDead;
    int health;
    public float movementSpeed;
    int damage;
    int damageModifier;
    public float speed = 5.0f;
    public float jumpStrength;

    bool worldStatus = true;

    Animator anim;

    public Scene scene1;
    public Scene scene2;

    public Collider2D groundCollider;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    bool isNearLadder = false;
    public Transform isLadderPresent;
    public float checkLadderRadius;
    public LayerMask Ladder;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    float verticalMovement;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public GameObject lightNPC;
    public GameObject darkNPC;

    public GameObject lightBackground;
    public GameObject darkBackground;

    public Canvas backpackCanvas;
    bool isBackpackOpen = false;

    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        jumpStrength = 15;

    }
    void Update()
    {
        CheckIfGrounded();
        ladderCheck();
        BetterJump();
        Backpack();


        float x = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        rigidbody2D.velocity = new Vector2(x, verticalMovement) * speed;
        rigidbody2D.angularVelocity = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0);

            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);

        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.rotation = Quaternion.Euler(0, 180f, 0);

            GetComponent<Animator>().SetBool("isMoving", true);


        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        } else
        {
            speed = 2;
        }

        if (Input.GetKey(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpStrength);


        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalMovement = 1;

            Debug.Log(isNearLadder);

            rigidbody2D.velocity = new Vector2(x, verticalMovement + 1) * speed;

        }

        if (worldStatus == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                lightNPC.SetActive(false);
                darkNPC.SetActive(true);
                darkBackground.SetActive(true);
                lightBackground.SetActive(false);
                Debug.Log("You have gone to the dark");

                worldStatus = false;



            }
        }
        else if (worldStatus == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                lightNPC.SetActive(true);
                darkNPC.SetActive(false);
                darkBackground.SetActive(false);
                lightBackground.SetActive(true);
                Debug.Log("You have gone to the light");

                worldStatus = true;


            }
        }


    }
    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void ladderCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(isLadderPresent.position, checkLadderRadius, Ladder);
        if (collider != null)
        {
            isNearLadder = true;
        }
        else
        {
            isNearLadder = false;
        }
    }

    void BetterJump()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Backpack()
    {
        if (isBackpackOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {

                Time.timeScale = 0;
                isBackpackOpen = true;

                Debug.Log("Backpack is open");

                backpackCanvas.enabled = true;
            }
        }
        else if (isBackpackOpen == true)
        {

            if (Input.GetKeyDown(KeyCode.B))
            {

                Time.timeScale = 1;
                isBackpackOpen = false;

                backpackCanvas.enabled = false;

                Debug.Log("Backpack is closed");
            }
        }
    
    } 


}

