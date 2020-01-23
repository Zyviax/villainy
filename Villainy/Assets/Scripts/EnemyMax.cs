using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMax : MonoBehaviour
{
    public float speed;
    public int health;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        /*Projectile projectile = other.GetComponent<Projectile>();
        if(projectile != null)
        {
            Destroy(other.gameObject);
            health -= 1;
            if(health==0)
            {
                Destroy(this.gameObject);
            }
        }*/
    }
}
