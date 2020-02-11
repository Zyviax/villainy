using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    public static float Distance(Vector3 a, Vector3 b)
    {
        //todo: make this work, possibly change the logic to portions of squares away instead... this would make it better i think

        //x = 1 then y = x * 4.98/8.64

        //Debug.Log(Mathf.Pow((b.x-a.x),2)/Mathf.Sqrt(8.64f) + Mathf.Pow((b.x-a.x),2)/Mathf.Sqrt(4.98f));
        
        //return (Mathf.Pow((b.x-a.x),2)/Mathf.Sqrt(8.64f) + Mathf.Pow((b.y-a.y),2)/Mathf.Sqrt(4.98f));
        //Debug.Log(Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2) / (4.98f / 8.64f));
        //return (Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2) / (4.98f / 8.64f));


        a.z = 0;
        b.z = 0;

        //a.y *= 1.69f;
        //b.y *= 1.69f;
        return Vector3.Distance(a, b);

        //return Vector3.Distance(a, b);
    }

    //todo make the range visible
    public static void DamageAllEnemiesWithinRange(Vector3 pos, float aoeRadius, float damage, Transform bloodPrefab)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Distance(pos, enemy.transform.position);
            if (distanceToEnemy < aoeRadius)
            {
                Transform bloodSplat = Instantiate(bloodPrefab, enemy.transform);
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
