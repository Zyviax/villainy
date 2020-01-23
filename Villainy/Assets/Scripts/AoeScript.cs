using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeScript : MonoBehaviour
{
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyMax enemy = other.GetComponent<EnemyMax>();
        if (enemy != null)
        {
            enemy.health--;
            Transform enemyTransform = other.GetComponent<Transform>();
            enemyTransform.localScale *= .6f;
            if (enemy.health == 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            Destroy(this.gameObject);
        }
        isDead = true;
    }
}
