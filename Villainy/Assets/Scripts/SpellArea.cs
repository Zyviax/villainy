using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArea : MonoBehaviour
{
    public int spell;
    private int healGain = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void activateCircle()
    {
        CircleCollider2D spellCollider = GetComponentInParent<CircleCollider2D>();
        float spellRange = spellCollider.radius;
        spellRange = spellRange * GetComponentInParent<Transform>().localScale.x;


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        if(spell==2 || spell==3)
        {
            foreach (GameObject enemy in enemies)
            {
                Vector3 enemyPos = enemy.transform.position;
                enemyPos.z = 0;
                float distanceToEnemy = Vector3.Distance(transform.position, enemyPos);
                //print(spellRange);
                //print(distanceToEnemy);

                if (distanceToEnemy <= spellRange)
                {
                    EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
                    if (spell == 2) //Heal
                    {
                        if (enemyScript.currentHealth > (enemyScript.enemy.Health - healGain))
                        {
                            enemyScript.currentHealth = enemyScript.enemy.Health;
                        }
                        else
                        {
                            enemyScript.currentHealth += 5;
                        }
                    }
                    else if (spell == 3) //Speed
                    {
                        enemyScript.speedBuff = true;
                    }
                }
            }
        } else if(spell==1)
        {
            foreach (GameObject tower in towers)
            {
                Vector3 towerPos = tower.transform.position;
                towerPos.z = 0;
                float distanceToTower = Vector3.Distance(transform.position, towerPos);

                if (distanceToTower <= spellRange)
                {
                    TowerAI towerScript = tower.GetComponent<TowerAI>();
                    if (spell == 1)//Stun
                    {
                        towerScript.stun = true;
                    }
                }
            }
        }
        
        Destroy(this.gameObject);
    }

    public void endCircle()
    {
        Destroy(this.gameObject);
    }
}
