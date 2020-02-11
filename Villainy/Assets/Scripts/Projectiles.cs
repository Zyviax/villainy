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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position + Vector3.up * 0.4f, step);

            //this code is supposed to make each projectile rotate towards the target
            //but i guess it doesn't work
            Vector3 direction = target.transform.position + Vector3.up * 1.5f - transform.position;
            if(Mathf.Abs(direction.x)>0.5)
            {
                //flip the sprite
                this.GetComponent<SpriteRenderer>().flipX = transform.position.x >= target.transform.position.x;
            }

            
            

            if (transform.position == target.position + Vector3.up * 0.4f)
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
                        GameyManager.damageTaken += (int)(enemy.enemy.Health * damage);

                        target = null;
                    }
                    else
                    {
                        enemy.currentHealth -= damage;
                        GameyManager.damageTaken += (int)damage;
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
