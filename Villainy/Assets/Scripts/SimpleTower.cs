using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : MonoBehaviour
{
    public Transform shotPrefab;
    public float shotCooldown;
    private float shotCooldownLeft = 0;
    private Queue<Transform> targets = new Queue<Transform>();
    public bool useEstimate;

    void OnTriggerEnter2D(Collider2D other)
    {
        Transform enemy = other.GetComponent<Transform>();
        targets.Enqueue(enemy);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        targets.Dequeue();
    }

    void Update()
    {
        shotCooldownLeft -= Time.deltaTime;
        if(targets.Count>1 && targets.Peek() == null)
        {
            targets.Dequeue();
        }
        if(targets.Count>0 && shotCooldownLeft<=0)
        {
            shotCooldownLeft = shotCooldown;
            Transform currentTarget = targets.Peek();

            Vector3 direction = currentTarget.position - this.transform.position;
            direction = Vector3.Normalize(direction);

            Transform shot = Instantiate(shotPrefab);
            shot.position = transform.position;

            Projectile projectile = shot.GetComponent<Projectile>();
            projectile.direction = direction;
            projectile.speed = 30;
            projectile.hitSize = 0;
        }
        
    }
}
