using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArea : MonoBehaviour
{
    public int spell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void activateCircle()
    {
        CircleCollider2D spellCollider = GetComponentInParent<CircleCollider2D>();
        float spellRange = spellCollider.radius;
        spellRange = spellRange * GetComponentInParent<Transform>().localScale.x;


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= spellRange)
            {
                enemy.GetComponent<Turtle>().Hit(1);
            }
        }
        Destroy(this.gameObject);
    }
}
