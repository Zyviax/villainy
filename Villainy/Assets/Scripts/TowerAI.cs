using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    public Tower tower;
    public List<Transform> enemies;

    public Transform target;

    private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) < tower.Range)
        {
            if (fireCooldown > 0)
            {
                fireCooldown -= Time.deltaTime;
            }
            else
            {
                if (tower.Targeting == 1)
                {
                    FindFirstTarget();
                }
                else if (tower.Targeting == 2)
                {
                    FindClosestTarget();
                }
                else if (tower.Targeting == 3)
                {
                    FindLastTarget();
                }

                if (tower.AoE)
                {
                    ShootProjectile();
                    fireCooldown = tower.FireCooldown;
                }
                else
                {
                    ShootProjectile();
                    fireCooldown = tower.FireCooldown;
                }
            }
        }
        else
        {
            if(tower.Targeting == 1)
            {
                FindFirstTarget();
            }
            else if(tower.Targeting == 2)
            {
                FindClosestTarget();
            }
            else if(tower.Targeting == 3)
            {
                FindLastTarget();
            }        
        }
    }

    void FindClosestTarget()
    {
        //Find easy way to convert gameobject list into transform
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && distanceToEnemy <= tower.Range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void FindFirstTarget()
    {
        //Find easy way to convert gameobject list into transform
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float longest = 0;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            float distanceTravelled = enemy.GetComponent<EnemyAI>().distanceTravelled;
            if (distanceTravelled > longest && distanceToEnemy < tower.Range)
            {
                longest = distanceTravelled;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void FindLastTarget()
    {
        //Find easy way to convert gameobject list into transform
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortest = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            float distanceTravelled = enemy.GetComponent<EnemyAI>().distanceTravelled;
            if (distanceTravelled < shortest && distanceToEnemy < tower.Range)
            {
                shortest = distanceTravelled;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void ShootProjectile()
    {
        Transform projectile = Instantiate(tower.Projectile, transform.position, Quaternion.identity).transform;
        Projectiles proj = projectile.GetComponent<Projectiles>();

        proj.target = target;
        proj.damage = tower.Damage;
        proj.aoe = tower.AoE;
        proj.aoeRadius = tower.AoERadius;
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target.position);
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, tower.Range);
    }
}
