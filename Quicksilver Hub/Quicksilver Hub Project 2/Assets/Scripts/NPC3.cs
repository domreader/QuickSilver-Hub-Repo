using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC3 : MonoBehaviour
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
                text.text = "Don't worry about them, my lady. They exist to show your excellence";
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




            text.text = "Those people over there look as if they haven't had a meal in their life!";

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiTextBox.GetComponent<Canvas>().enabled = false;

        text.text = "";
    }
}
