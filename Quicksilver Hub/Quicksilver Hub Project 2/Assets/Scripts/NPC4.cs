using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC4 : MonoBehaviour
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
                text.text = "Yes, it's delicious, having such a good meal after such a long voyage really settles the stomach";
            }

            if(textTimer > 10)
            {
                text.text = "Thanks to the leader, we got in here.Remember the signal tonight. The first shot is the start of the plan.";
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




            text.text = "The food here is definitely delicious!";

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiTextBox.GetComponent<Canvas>().enabled = false;

        text.text = "";
    }
}
