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
    private void Update()
    {
        MoveClouds();
    }
    private void MoveClouds()
    {
        for (int i = 0; i < sky.Length; i++)
        {
            if (sky[i].transform.localPosition.x > xPosition)
            {
                sky[i].transform.position = Vector3.MoveTowards(sky[i].transform.position, new Vector3(xPosition, sky[i].transform.position.y, sky[i].transform.position.z), speed);
            }
            else
            {
                sky[i].transform.localPosition = new Vector3(0, sky[i].transform.position.y, sky[i].transform.position.z);
            }
        }
    }
}
