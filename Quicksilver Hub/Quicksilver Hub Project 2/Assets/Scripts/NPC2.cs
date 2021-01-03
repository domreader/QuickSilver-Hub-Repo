using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2 : MonoBehaviour
{


    bool inRange;
    bool isDetected;
    bool gameOver;


    float textTimer;


    public GameObject uiTextBox;

    public Text text;

    
    private void Update()
    {
        if (inRange)
        {
            textTimer += Time.deltaTime;


            if (textTimer > 5)
            {
                text.text = "Don't tell anyone but I got it from a bunch of crazy pirates who are going to rob the city tonight. I gave them something good. They gave me the wine";
            }

            if (textTimer > 10)
            {
                text.text = "I may have to go get some myself! Where are they now?";
            }

            if (textTimer > 15)
            {
                text.text = "From what I heard they are in the restaurant so I would be quick!";
            }

           
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("I can hear important things");

            inRange = true;

            textTimer = 0;

            Debug.Log("is in range = " + inRange);

            uiTextBox.GetComponent<Canvas>().enabled = true;




            text.text = "Hey, that wine is really good. Where did you get it?";

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiTextBox.GetComponent<Canvas>().enabled = false;

        text.text = "";
    }

}