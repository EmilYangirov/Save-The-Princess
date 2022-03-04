using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    private GameObject[] sky;
    public float speed = 0.005f;
    public float xPosition = -64;

    private void Start()
    {
        sky = GameObject.FindGameObjectsWithTag("Sky");
    }
    private void FixedUpdate()
    {
        MoveClouds();
    }
    private void MoveClouds()
    {
        for (int i = 0; i < sky.Length; i++)
        {
            float y = sky[i].transform.localPosition.y;
            float z = sky[i].transform.localPosition.z;

            if (sky[i].transform.localPosition.x > xPosition)
            {            

                sky[i].transform.localPosition = Vector3.MoveTowards(sky[i].transform.localPosition, new Vector3(xPosition,y,z), speed);
            }
            else
            {
                sky[i].transform.localPosition = new Vector3(0, y, z);
            }
        }
    }
}
