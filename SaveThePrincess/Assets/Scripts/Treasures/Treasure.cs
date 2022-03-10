using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Treasure : MonoBehaviour
{
    public float giveme;
    protected Transform player;
    public GameObject scorePrefab;
    public float livetime;
    private bool picked;

    [SerializeField]
    private AudioClip[] pickupAudio;

    private SoundPlayer soundPlayer;
    private void Start()
    {
        soundPlayer = new SoundPlayer(gameObject);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        int a = Random.Range(-750, 750);
        rb.AddForce(Vector2.right * a);
        rb.AddForce(Vector2.up * 500);
        StartCoroutine(Life());
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character" && !picked)
        {
            picked = true;
            player = collision.transform;
            Debug.Log(player.name);
            Instantiate(scorePrefab, transform.position, Quaternion.identity);            
            GiveStats();
            StartCoroutine(DeathCoroutine());
            soundPlayer.PlaySound(pickupAudio);
        }       
    }
    IEnumerator Life()
    {
        yield return new WaitForSeconds(livetime);
        StartCoroutine(DeathCoroutine());
    }
    private IEnumerator DeathCoroutine()
    {
        float time = 0;
        while (time < 1f)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(0, 0), 8 * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    public abstract void GiveStats();

}
