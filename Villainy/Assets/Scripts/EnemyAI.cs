using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public BasicNodePath nodePath;
    public Enemy enemy;

    public bool speedBuff = false;
    private float speedBuffTimer = 0;
    private float speedBuffCooldown = 3;

    public float currentHealth, speed, distanceTravelled = 0;

    public bool disabled, isHealer, isSpeeder;

    public Image HP;
    public Text name;

    [SerializeField]
    private Transform target;
    private float healCooldown = 0, healRadii, healAmount, disabledTimer = 0, speedAmount, checkCooldown = 0;
    private List<GameObject> enemies;
    private List<GameObject> firstFourEnemies;

    public Transform Target { get { return target; } set { target = value; } }

    // Start is called before the first frame update
    void Start()
    {
        nodePath = GameObject.FindGameObjectWithTag("NodeManager").GetComponent<BasicNodePath>();
        target = nodePath.startNode;
        enemies = new List<GameObject>();
        firstFourEnemies = new List<GameObject>();

        currentHealth = enemy.Health;
        speed = enemy.Speed;
        name.text = enemy.enemyName;
        isHealer = enemy.IsHealer;
        isSpeeder = enemy.IsSpeeder;
        healCooldown = enemy.HealCooldown;
        healRadii = enemy.HealRadii;
        healAmount = enemy.HealAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedBuff == true)
        {
            speedBuffTimer = speedBuffCooldown;
            speedBuff = false;
            speed = enemy.Speed * 2;
        }
        if (speedBuffTimer > 0)
        {
            speedBuffTimer -= Time.deltaTime;
            if(speedBuffTimer<=0)
            {
                speed = enemy.Speed;
            }
        }
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

        if (speedBuff)
        {
            speed = enemy.Speed * 1.2f;
        }
        else
        {
            speed = enemy.Speed;
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
            if (disabledTimer <= 0)
            {
                disabled = false;
            }
            else
            {
                disabledTimer -= Time.deltaTime;
            }
        }
        else if (isHealer)
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
        else if (isSpeeder)
        {
            if (checkCooldown <= 0)
            {
                enemies.Clear();
                enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
                enemies.Remove(this.gameObject);
                enemies = enemies.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();

                foreach (GameObject e in enemies.Take(Mathf.Min(enemies.Count, 4)))
                {
                    Debug.Log("Test");
                    e.GetComponent<EnemyAI>().speedBuff = true;
                }

                foreach (GameObject e in enemies.Skip(4))
                {
                    e.GetComponent<EnemyAI>().speedBuff = false;
                }

                checkCooldown = 1;
            }
            else
            {
                checkCooldown -= Time.deltaTime;
            }
        }
    }
}
