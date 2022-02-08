using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportElements : MonoBehaviour
{
    public List<Transform> objectsToTeleport;
    private Transform backgroundTransform;
    private Transform camera;

    private float minX = -50, maxX = 150;
    private float modifyX; 
    private int teleportBackgroundX, dist;
  

    private void Start()
    {
        modifyX = maxX - minX;
        teleportBackgroundX = (int)(modifyX / 2);
        camera = Camera.main.transform;
        backgroundTransform = GameObject.FindGameObjectWithTag("TeleportableBackGround").transform;
        objectsToTeleport.Add(backgroundTransform);
    }
    private void FixedUpdate()
    {
        dist = (int)Vector2.Distance(camera.position, backgroundTransform.position);

        bool checkCamera = CheckCameraPosition();

        if (dist > teleportBackgroundX || checkCamera)
            TeleportAll();

        if (checkCamera)
            TeleportObject(camera);
    }

    private void TeleportObject(Transform objectTransform)
    {
        float x = objectTransform.position.x;
        float y = objectTransform.position.y;
        float z = objectTransform.position.z;

        if (objectTransform.position.x < 0)
            x += modifyX;
        else if (objectTransform.position.x > 0)
            x -= modifyX;

        objectTransform.position = new Vector3(x, y, z);
    }

    private void TeleportAll()
    {
        objectsToTeleport.RemoveAll(x => x == null);

        foreach (Transform tr in objectsToTeleport)
        {
            TeleportObject(tr);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform otherTransform = other.transform;
        objectsToTeleport.Add(otherTransform);

        float distBetweenTransforms = Vector2.Distance(otherTransform.position, backgroundTransform.position);
        if (distBetweenTransforms > modifyX / 2)
            TeleportObject(otherTransform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Transform otherTransform = other.transform;
        objectsToTeleport.Remove(otherTransform);

        if(otherTransform.position.x < minX || otherTransform.position.x > maxX)
            TeleportObject(otherTransform);
    }
    
    private bool CheckCameraPosition()
    {
        if (camera.position.x <= minX || camera.position.x >= maxX)
            return true; 
        else
            return false;
    }
}
