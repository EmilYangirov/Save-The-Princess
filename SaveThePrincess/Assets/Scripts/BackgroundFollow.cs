using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    private GameObject CamGO;
    private void Awake()
    {
        CamGO = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(CamGO.transform.position.x, CamGO.transform.position.y, gameObject.transform.position.z);
    }
}
