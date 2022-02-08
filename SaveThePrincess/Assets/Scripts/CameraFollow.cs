
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
    private Vector3 velocity = Vector3.zero;


    public Transform player;
    [SerializeField]
    private Transform background;

    private void Start()
    {
        GameObject ch = GameObject.FindGameObjectWithTag("Character");
        player = ch.transform;
        
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
    private void LateUpdate()
    {
        BackgroundFollow();
    }


    private void TrackPlayer()
    {
        float targetX = player.position.x;
        float targetY = transform.position.y;
        float targetZ = transform.position.z;

        Vector3 newPos = new Vector3(targetX, targetY, targetZ);

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, xSmooth);
    }

    private void BackgroundFollow()
    {
        float x = transform.position.x;
        float y = background.position.y;
        float z = background.position.z;

        background.position = new Vector3(x,y,z);
    }
        
}
    
