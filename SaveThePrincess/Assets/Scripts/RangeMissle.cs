using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMissle : MonoBehaviour
{
    public LayerMask enemyLayers;
    public float damage, attackRadius, lifeTime;

    void Update()
    {
        HitEnemy();
        StartCoroutine(DeathCoroutine());
    }
    private void HitEnemy()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(transform.position, attackRadius, enemyLayers);
        if (hitEnemies != null)
        {
            Character hitChar = hitEnemies.gameObject.GetComponent<Character>();
            hitChar.Hit(damage, 0, 0);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display attack radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
