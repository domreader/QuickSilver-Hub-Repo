using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    GameObject currentCollision;
    bool inCollider;

   public GameObject animCanvas;
    // Start is called before the first frame update
    void Start()
    {
        currentCollision = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider == true) // In collider
        {
            if (currentCollision.name == "TownToRestaurant" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(66.52f, -32.53f);

                GetComponent<Animator>().SetBool("isTeleporting", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isTeleporting", false);

            }

            if (currentCollision.name == "RestaurantToTown" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(16.76f, -0.85f);

            }

            if (currentCollision.name == "RestaurantUpstairs" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(80.04f, 33.41f);

            }

            if (currentCollision.name == "RestaurantDownstairs" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(70.28f, -23.68f);

            }

            if (currentCollision.name == "WarehouseEnterance" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(-97.73f, 27.08f);

            }

            if (currentCollision.name == "WarehouseExit" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(-12.02f, 19.99f);

            }

            if (currentCollision.name == "OfficeBuildingEnterance" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(82.95f, 43.9f);

            }

            if (currentCollision.name == "OfficeBuildingExit" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(7.6f, 19.95f);

            }

            if (currentCollision.name == "OfficeEnterance" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(4.04f, 49.57f);

            }

            if (currentCollision.name == "OfficeExit" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(81.1f, 61.33f);

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Teleport"))
        {

            currentCollision = collision.gameObject;
            Debug.Log(currentCollision);

            inCollider = true;
           

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
    }



}
