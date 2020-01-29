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
                float health = enemy.GetComponent<EnemyAI>().currentHealth;
                float maxHealth = enemy.GetComponent<EnemyAI>().enemy.Health;

                if (health > 0 && health < maxHealth)
                {
                    enemy.GetComponent<EnemyAI>().currentHealth = Mathf.Clamp(health -= damage, 0, maxHealth);
                }
            }
        }
    }
}
