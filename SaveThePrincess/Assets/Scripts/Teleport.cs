using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject cameraGO;
    public float xfactor;
    
    private void Awake()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.transform.tag == "Character")
        {
            collision.transform.position = new Vector3(collision.transform.position.x - xfactor, collision.transform.position.y, 0);
            cameraGO.transform.position = new Vector3(cameraGO.transform.position.x - xfactor, cameraGO.transform.position.y, cameraGO.transform.position.z);
        }
    }
}
