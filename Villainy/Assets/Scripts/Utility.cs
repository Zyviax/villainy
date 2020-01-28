using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static void DamageAllEnemiesWithinRange(Vector3 pos, float aoeRadius, float damage)
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
}
