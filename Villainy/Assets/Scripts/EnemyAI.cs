using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public BasicNodePath nodePath;
    public Enemy enemy;

    public float currentHealth;
    public float speed;

    public Image HP;
    public Text name;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nodePath = GameObject.Find("/NodeManager").GetComponent<BasicNodePath>();
        target = nodePath.startNode.GetComponent<Node>().transform;

        currentHealth = enemy.Health;
        speed = enemy.Speed;
        name.text = enemy.enemyName;
    }

    // Update is called once per frame
    void Update()
    {
        HP.fillAmount = currentHealth / enemy.Health;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (transform.position != target.transform.position)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            if (target == nodePath.endNode)
            {
                //endNode.GetComponent<Objective>
            }
            else
            {
                target = target.GetComponent<Node>().nextNode;
            }
        }
    }


}
