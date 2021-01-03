using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playerTarget;

    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, transform.position.z);    
    }
}
