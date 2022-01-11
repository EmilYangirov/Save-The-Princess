
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float xMargin = 1.0f;       
    public float yMargin = 1.0f;       
    public float xSmooth = 8.0f;       
    public float ySmooth = 8.0f;       
    public Vector2 maxXAndY;       
    public Vector2 minXAndY;       
    public Transform player;       

    void Start()
    {
        GameObject ch = GameObject.FindGameObjectWithTag("Character");
        player = ch.transform;
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }


    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (Mathf.Abs(transform.position.x - player.position.x) > xMargin)           
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
                
        if (Mathf.Abs(transform.position.y - player.position.y) > yMargin)
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
    
