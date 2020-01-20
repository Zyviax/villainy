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
                target.GetComponent<EnemyAI>().currentHealth -= tower.Damage;
                fireCooldown = tower.Firerate;
            }

        }
        else
        {
            FindNewTarget();
        }
    }

    // Update is called once per frame
    void FindNewTarget()
    {
        //Find easy way to convery gameobject list into transform
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= tower.Range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
