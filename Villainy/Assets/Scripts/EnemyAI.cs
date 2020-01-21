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

    [SerializeField]
    private Transform target;
    private float attackCooldown = 0;

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

        if(nodePath.endNode == null)
        {
            return;
        }

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
                if (attackCooldown <= 0)
                {
                    nodePath.endNode.GetComponent<Objective>().health -= enemy.Damage;
                    Debug.Log("Test");
                }
                else
                {
                    attackCooldown -= Time.deltaTime;
                }
            }
            else
            {
                target = target.GetComponent<Node>().nextNode;
            }
        }
    }


}
