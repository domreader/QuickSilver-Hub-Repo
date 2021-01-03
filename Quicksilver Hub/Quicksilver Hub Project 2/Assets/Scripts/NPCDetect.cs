using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDetect : MonoBehaviour
{

    bool inRange;
    bool isDetected;
    bool gameOver;

    float detectionTimer;

    public GameObject detectionUI;

    int formattedTimer;

    public Text uiText;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Stop Thief");

            isDetected = true;

            Debug.Log(isDetected);

            detectionTimer = 6f;

            detectionUI.GetComponent<Canvas>().enabled = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDetected = false;
        detectionTimer = 6f;

        detectionUI.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
       

        if (isDetected == true)
        {
            detectionTimer -= Time.deltaTime;
            Debug.Log(detectionTimer);

            formattedTimer = Mathf.FloorToInt(detectionTimer % 60);

            uiText.text = "You will be detected in " + formattedTimer + " seconds";

            if (formattedTimer == 0)
            {
                Time.timeScale = 0f;
                SceneManager.LoadScene("GameOver");
                Debug.Log("You have failed the game");
            }
        }
        
    }

}
