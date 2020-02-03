using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour { 

    public static float Distance(Vector3 a, Vector3 b)
    {
        a.z = 0;
        b.z = 0;
        //return (Mathf.Sqrt((a.x-b.x) + Mathf.Pow((4.98f/ 8.64f) *(a.y-b.y),2)));
        return Vector3.Distance(a, b);
    }
    public static void DamageAllEnemiesWithinRange(Vector3 pos, float aoeRadius, float damage)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Distance(pos, enemy.transform.position);
            if (distanceToEnemy < aoeRadius)
            {
                float health = enemy.GetComponent<EnemyAI>().currentHealth;
                float maxHealth = enemy.GetComponent<EnemyAI>().enemy.Health;

                if (health > 0 && health <= maxHealth)
                {
                    enemy.GetComponent<EnemyAI>().currentHealth = Mathf.Clamp(health -= damage, 0, maxHealth);
                }
            }
        }
    }
}
