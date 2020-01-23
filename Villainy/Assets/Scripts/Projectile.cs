using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float hitSize;
    public Transform aoePrefab;
    private bool aoeMade = false;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyMax enemy = other.GetComponent<EnemyMax>();
        if(enemy!=null)
        {
            if(hitSize>0 && !aoeMade)
            {
                Transform aoe = Instantiate(aoePrefab);
                aoe.position = transform.position;
                aoeMade = true;
                CircleCollider2D aoeCircle = aoe.GetComponent<CircleCollider2D>();
                aoeCircle.radius = hitSize;
                Destroy(this.gameObject);
                return;
            }

            enemy.health--;
            Transform enemyTransform = other.GetComponent<Transform>();
            enemyTransform.localScale *= .6f;
            if (enemy.health==0)
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
