using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Transform target;

    public float damage, aoeRadius, disable;
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
                    Utility.DamageAllEnemiesWithinRange(transform.position, aoeRadius, damage);
                    target = null;
                }
                else
                {
                    EnemyAI enemy = target.GetComponent<EnemyAI>();
                    if(disable <= 0)
                    {
                        enemy.disabled = true;
                    }

                    enemy.currentHealth -= damage;
                    target = null;
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
