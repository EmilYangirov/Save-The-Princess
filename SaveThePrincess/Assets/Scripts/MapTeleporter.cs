using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleporter : MonoBehaviour
{
    private BoxCollider2D camcol;
    public List<Transform> characters;
    public float minx;
    public float maxx;
    public float center;    
    public float teleportRange;
    private bool ok = false;
    private void Start()
    {
        camcol = gameObject.GetComponent<BoxCollider2D>();      
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;
        camcol.size = new Vector2(width, height);
        teleportRange = maxx - minx;
    }
    void Update()
    {
       
            if (Camera.main.transform.position.x < minx)
            {              
                Camera.main.transform.position = new Vector3(maxx, Camera.main.transform.position.y, Camera.main.transform.position.z);
               
            }
            if (Camera.main.transform.position.x > maxx)
            {               
                Camera.main.transform.position = new Vector3(minx, Camera.main.transform.position.y, Camera.main.transform.position.z);
             }
            if (Camera.main.transform.position.x > center && !ok)
            {
                DeleteEmpty();
                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].position = new Vector3(characters[i].position.x + teleportRange, characters[i].position.y, characters[i].transform.position.z);
                }
                transform.position = new Vector3(maxx, transform.position.y, transform.position.z);
                ok = true;
            }
            if (Camera.main.transform.position.x < center && ok)
            {
                DeleteEmpty();
                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].position = new Vector3(characters[i].position.x - teleportRange, characters[i].position.y, characters[i].transform.position.z);
                }
                transform.position = new Vector3(minx, transform.position.y, transform.position.z);
                ok = false;
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddNew(collision.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.position.x < minx)
        {
            collision.transform.position = new Vector3(collision.transform.position.x + teleportRange, collision.transform.position.y, collision.transform.position.z);
        }
        if (collision.transform.position.x > maxx)
        {
            collision.transform.position = new Vector3(collision.transform.position.x - teleportRange, collision.transform.position.y, collision.transform.position.z);
        }
        for (int i = 0; i < characters.Count; i++)
        {
            if (collision.transform == characters[i])
            {
                characters.RemoveAt(i);
                break;
            }
        }
    }
    void AddNew(Transform tr)
    {
        if (tr.transform.tag == "Character" || tr.transform.tag == "neutral" || tr.transform.tag == "enemy" || tr.transform.tag == "AppleTree")
        {
            bool ok = false;
            for (int i = 0; i < characters.Count; i++)
            {
                if (tr.transform == characters[i])
                {
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                characters.Add(tr.transform);
            }
        }
    }
    void DeleteEmpty()
    {
        for(int i = 0; i<characters.Count; i++)
        {
            if (characters[i] == null)
            {
                characters.RemoveAt(i);
            }
        }
    }
   
}
