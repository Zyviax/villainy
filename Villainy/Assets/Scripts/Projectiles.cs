using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Transform target;

    public float damage, aoeRadius, disable;
    public bool aoe, isPercentage;
    public Transform bloodPrefab;

    void Update()
    {
        if (target != null) { 
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            if (transform.position == target.position)
            {
                //print(disable);
                if (aoe)
                {
                    Utility.DamageAllEnemiesWithinRange(transform.position, aoeRadius, damage, bloodPrefab);
                    target = null;
                }
                else
                {
                    Transform bloodSplat = Instantiate(bloodPrefab, target);
                    EnemyAI enemy = target.GetComponent<EnemyAI>();
                    if(disable > 0)
                    {
                        enemy.disabled = true;
                        enemy.setDisabledTimer(disable);
                    }

                    if (isPercentage)
                    {
                        enemy.currentHealth -= enemy.enemy.Health * damage;
                        target = null;
                    }
                    else
                    {
                        enemy.currentHealth -= damage;
                        target = null;
                    }
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
