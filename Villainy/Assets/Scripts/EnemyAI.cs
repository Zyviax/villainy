using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public BasicNodePath nodePath;
    public Enemy enemy;

    public bool speedBuff = false;

    public float currentHealth, speed, distanceTravelled = 0;

    public bool disabled, isHealer;

    public Image HP;
    public Text name;

    [SerializeField]
    private Transform target;
    private float attackCooldown = 0, healCooldown = 0, healRadii, healAmount, disabledTimer = 0;

    public Transform Target { get { return target; } set { target = value; } }

    // Start is called before the first frame update
    void Start()
    {
        nodePath = GameObject.Find("/NodeManager").GetComponent<BasicNodePath>();
        target = nodePath.startNode;

        currentHealth = enemy.Health;
        speed = enemy.Speed;
        name.text = enemy.enemyName;
        isHealer = enemy.IsHealer;
        healCooldown = enemy.HealCooldown;
        healRadii = enemy.HealRadii;
        healAmount = enemy.HealAmount;
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
            GameyManager.spawnedEnemies.Remove(transform);
            Destroy(this.gameObject);
        }

        if (transform.position != target.transform.position)
        {
            float step = speed * Time.deltaTime;
            distanceTravelled += step;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            if (target == nodePath.endNode)
            { 
                nodePath.endNode.GetComponent<Objective>().health -= enemy.Damage;
                GameyManager.spawnedEnemies.Remove(transform);
                Destroy(this.gameObject);
            }
            else
            {
                target = target.GetComponent<Node>().nextNode;
            }
        }

        if (disabled)
        {
            if(disabledTimer <= 0)
            {
                disabled = false;
            }
            else
            {
                disabledTimer -= Time.deltaTime;
            }
        }

        if (isHealer && !disabled)
        {
            if (healCooldown <= 0)
            {
                Utility.DamageAllEnemiesWithinRange(transform.position, healRadii, healAmount);
            }
            else
            {
                healCooldown -= Time.deltaTime;
            }
        }
    }
}
