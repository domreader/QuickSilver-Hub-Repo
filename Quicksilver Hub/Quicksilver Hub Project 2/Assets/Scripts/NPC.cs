using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
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
                text.text = "I've heard from the guards that a group of outlaws have infiltrated here, my God. I hope they don't take away my goods in the warehouse. ";
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



            
            text.text = "It's said that a group of pirates have infiltrated here. Is it true or not? ";

        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiTextBox.GetComponent<Canvas>().enabled = false;
        text.text = "";
    }

}
