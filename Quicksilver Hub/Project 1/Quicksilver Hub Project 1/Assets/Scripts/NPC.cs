using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    bool characterClose;
    
    public bool gamePaused;
    Collider collider;
    public List<Collider2D> enemyHead;
    Collision collision;

    int enemiesKilled;

    public GameObject[] NPCArray;

    public Canvas canvas;
    public Canvas messageCanvas;
    public Text messageText;
    public Text npcText2;
    public Text npcText3;
    public Text npcText4;
    public Text npcText5;
    public Text npcText6;
    public Text npcText7;
    public Text npcText8;

    public Canvas npcBox2;
    public Canvas npcBox3;
    public Canvas npcBox4;
    public Canvas npcBox5;
    public Canvas npcBox6;
    public Canvas npcBox7;
    public Canvas npcBox8;

    public Image card1;
    public Image card2;
    public Image card3;
    public Image card4;
    public Image card5;
    public Image card6;
    public Image card7;
    public Image card8;
    public Image card9;
    public Image card10;
    public Image card11;
    public Image card12;

    bool evilDecision;
    bool goodDecision;
    int goodCounter;
    int evilCounter;
    bool canvasEnabled;
    
    bool introNPC;
    bool npc1;
    bool npc2;
    bool npc3;
    bool npc4;
    bool npc5;
    bool npc6;
    bool npc7;

    float timer;
    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {

        gamePaused = false;
        messageCanvas.enabled = false;
        npcBox2.enabled = false;
        npcBox3.enabled = false;
        npcBox4.enabled = false;
        npcBox5.enabled = false;
        npcBox6.enabled = false;
        npcBox7.enabled = false;
        npcBox8.enabled = false;


        messageText.text = "";

        enemyHead = new List<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        decisionTree();
        pauseGame();
        goodLine();
        evilLine();
        gameTimer();

        if (introNPC == true && canvasEnabled == true)
        {
            messageCanvas.enabled = true;
        }
        else
        {
            messageCanvas.enabled = false;
            messageText.text = "";
        }

        if (npc1 == true && canvasEnabled == true)
        {
            npcBox2.enabled = true;
        }
        else
        {
            npcBox2.enabled = false;
        }

        if (npc2 == true && canvasEnabled == true)
        {
            npcBox3.enabled = true;
        }
        else
        {
            npcBox3.enabled = false;
        }

        if (npc3 == true && canvasEnabled == true)
        {
            npcBox4.enabled = true;
        }
        else
        {
            npcBox4.enabled = false;
        }

        if (npc4 == true && canvasEnabled == true)
        {
            npcBox5.enabled = true;
        }
        else
        {
            npcBox5.enabled = false;
        }

        if (npc5 == true && canvasEnabled == true)
        {
            npcBox6.enabled = true;
        }
        else
        {
            npcBox6.enabled = false;
        }

        if (npc6 == true && canvasEnabled == true)
        {
            npcBox7.enabled = true;
        }
        else
        {
            npcBox7.enabled = false;
        }

        if (npc7 == true && canvasEnabled == true)
        {
            npcBox8.enabled = true;
        }
        else
        {
            npcBox8.enabled = false;

        }

        

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.name == ("Intro NPC"))
        {
            canvasEnabled = true;

            introNPC = true;

            messageText.text = "Who am I? I hardly know myself? \n" +
                "1 = You are yourself \n" +
                "2 = You are nothing";

            
        }


        if (collider.name == ("NPC 1"))
        {
            npcText2.text = "";

            canvasEnabled = true;

            npc1 = true;

            npcText2.text = "I am the embodiment of truth, don't you think so? \n" +
                "1 = Stop dreaming! \n" +
                "2 = Yes, you are";

        }
      

        if (collider.name == ("NPC 2"))
        {
            canvasEnabled = true;

            npc2 = true; 


            npcText3.text = "I am a successful manager, don't you think so? \n " +
                "1 = I admit your strength \n" +
                "2 = You don't deserve to be a manager!";
        }

        if (collider.name == ("NPC 3"))
        {
            canvasEnabled = true;

            npc3 = true;

            npcText4.text = "Oh, traveler, do you know what justice is? \n" +
                "1 = The justice of the world \n" +
                "2 = It's our own justice";

        }

  
        if (collider.name == ("NPC 4"))
        {
            canvasEnabled = true;

            npc4 = true;

            npcText5.text = "Hello brother, \n" +
                "Would you consider having a drink with me? \n" +
                "1 = Yes, why not \n" +
                "2 = I refuse, you drunkard";
        }

        if (collider.name == ("NPC 5"))
        {
            canvasEnabled = true;

            npc5 = true;

            npcText6.text = "Have you ever experienced failure? \n" +
                " What would you do if you failed? \n" +
                "1 = Never give up \n " +
                "2 = I would give up";
            

        }

        if (collider.name == ("NPC 6"))
        {
            canvasEnabled = true;

            npc6 = true;

            npcText7.text = "Young man, what is mankinds most powerful weapon? \n " +
                "Is it reason, or wisdom? \n" +
                "1 = Reason \n" +
                "2 = Wisdom \n" +
                "3 = Equally Important";
        }

        if (collider.name == ("NPC 7"))
        {
            canvasEnabled = true;

            npc7 = true;
            introNPC = false;

            npcText8.text = "Traveler, may I ask you a question? \n" +
                "Is smooth sailing better than twists and turns in life? \n" +
                "1 = Twists and turns \n" +
                "2 = Smooth sailing";
        }


        if (collider.name == ("Enemy 1"))
        {
            Destroy(GameObject.Find("Enemy 1"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);
        }

        if (collider.name == ("Enemy 2"))
        {
            Destroy(GameObject.Find("Enemy 2"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);
        }

        if (collider.name == ("Enemy 3"))
        {
            Destroy(GameObject.Find("Enemy 3"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);
        }

        if (collider.name == ("Enemy 4"))
        {
            Destroy(GameObject.Find("Enemy 4"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);
        }

        if (collider.name == ("Enemy 5"))
        {
            Destroy(GameObject.Find("Enemy 5"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);
        }

        if (collider.name == ("Enemy 6"))
        {
            Destroy(GameObject.Find("Enemy 6"));

            enemiesKilled++;

            Debug.Log(enemiesKilled);

        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        canvasEnabled = false;
        introNPC = false;
        npc1 = false;
        npc2 = false;
        npc3 = false;
        npc4 = false;
        npc5 = false;
        npc6 = false;
        npc7 = false;
        evilDecision = false;
        goodDecision = false;

        Debug.Log("Exited Collider");
        messageText.text = "";
    }

    void pauseGame()
    {

        if (Input.GetKeyUp(KeyCode.Escape) && gamePaused == false)
        {

            Debug.Log("Game Paused");

            gamePaused = true;

            Time.timeScale = 0;

            Debug.Log("Press Escape To Resume");

            

            return;

        }


        if (Input.GetKeyUp(KeyCode.Escape) && gamePaused == true)
        {

            gamePaused = false;

            Debug.Log("Resuming Game");

            Time.timeScale = 1;

        }

    }


    void decisionTree()
    {

        if (introNPC == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 1;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 1;

                messageText.text = "";
            }

        }
        if (npc1 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 2;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 2;

                messageText.text = "";
            }

        }
        if (npc2 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 3;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 3;

                messageText.text = "";
            }

        }
        if (npc3 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 4;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 4;

                messageText.text = "";
            }

        }
        if (npc4 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 5;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 5;

                messageText.text = "";
            }

        }
        if (npc5 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 6;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 6;

                messageText.text = "";
            }

        }
        if (npc6 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 7;

                messageText.text = "";

            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 7;

                messageText.text = "";
            }

            if (Input.GetKey(KeyCode.Alpha3))
            {
                evilDecision = true;
                evilCounter = 8;
            }
            
        }
        if (npc7 == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                goodDecision = true;
                goodCounter = 8;
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                evilDecision = true;
                evilCounter = 9;
            }
        }
      
    }
    void evilLine()
    {

        if (evilCounter == 1)
        {
            messageText.text = "That's it! \n Goodbye";
        }

        if (evilCounter == 2)
        {
            npcText2.text = "Ha ha, very good! \n " +
                "Yield to my arrangement, fool.";
        }

        if (evilCounter == 3)
        {
            npcText3.text = "Oh? So you're confident?";
        }

        if (evilCounter == 4)
        {
            npcText4.text = "Well, you are the enemy of justice!";
        }

        if (evilCounter == 5)
        {
            npcText5.text = "Oh, so heartless!";
        }

        if (evilCounter == 6)
        {
            npcText6.text = "How spineless of you!";
        }

        if (evilCounter == 7)
        {
            npcText7.text = "It seems you are not wise yet!";
        }

        if (evilCounter == 8)
        {
            npcText7.text = "It seems you are not wise yet!";
        }

        if (evilCounter == 9)
        {
            npcText8.text = "Well, clearly born with the world on a silver platter";
        }

    }

    void goodLine()
    {

        if (goodCounter == 1)
        {
            messageText.text = "Yes, I remember. \n" +
                     " I am you, you are me. \n" +
                     "I am the source of strength in your heart";

            card4.enabled = true;          
        }

        if (goodCounter == 2)
        {
            npcText2.text = " I remember, I come from you. \n" +
                "I am you, I am the embodiment of truth";
            card6.enabled = true;

        }

        if (goodCounter == 3)
        {
            npcText3.text = "Ha ha, yes, I remember, I am you, you are me. \n" +
                " I am the embodiment of management and business";

            card9.enabled = true;

        }

        if (goodCounter == 4)
        {
            npcText4.text = "Yes, I come from the world, in everyone's heart. \n " +
                "I am the most just belief in everyone's heart";

            card8.enabled = true;

        }

        if (goodCounter == 5)
        {
            npcText5.text = "Ha ha, you are really wise. \n" +
                " I remember that I am a part of everyone. \n " +
                "Everyone likes my existence. \n" +
                " I am the embodiment of hedonism and immortality";

            card3.enabled = true;

        }

        if (goodCounter == 6)
        {
            npcText6.text = "This is just decent. \n" +
                " Wait, I remember, I hide in everyone's heart. \n" +
                " Everyone is strong because of me. \n" +
                " I am the embodiment of strength and struggle";

            card5.enabled = true;

        }

        if (goodCounter == 7)
        {
            npcText7.text = "Yes, the real wisdom is to accept myself. \n " +
                "I am the unawakened power of everyone. \n " +
                "Everyone is a part of me. \n " +
                "I am the embodiment of reason and wisdom";

            card12.enabled = true;

        }

        if (goodCounter == 8)
        {
            npcText8.text = "Yes, it's the momentum. \n" +
                "I'm the best mentor in everyone's life. \n" +
                "Everyone grows up because of me. \n" +
                "I'm the embodiment of difficulty and danger.";

            card11.enabled = true;

        }

    }

    void gameTimer()
    {
        if (startTimer == true)
        {
            timer += Time.deltaTime;
        }
        else if (startTimer == false)
        {
            timer = 0f;
        }
    }

}
