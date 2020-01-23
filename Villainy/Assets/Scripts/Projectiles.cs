using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Transform target;

    public float damage;
    public float aoeRadius;
    public bool aoe;

    void Update()
    {
        if (target != null) { 
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (transform.position == target.position)
            {
                if (aoe)
                {
                    DamageAllEnemiesWithinRange(transform.position);
                    target = null;
                }
                else
                {
                    target.GetComponent<EnemyAI>().currentHealth -= damage;
                    target = null;
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void DamageAllEnemiesWithinRange(Vector3 pos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(pos, enemy.transform.position);
            if (distanceToEnemy < aoeRadius)
            {
                enemy.GetComponent<EnemyAI>().currentHealth -= damage;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
