using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Queue<GameObject> enemiesToSpawn;
    

    public float delay;
    public BasicNodePath nodePath;

    private Transform enemy;

    public List<GameObject> enemies;

    public void Start()
    {
        enemiesToSpawn = new Queue<GameObject>();
        nodePath = GameObject.FindGameObjectWithTag("NodeManager").GetComponent<BasicNodePath>();
    }

    public void AddToQueue(int enemy)
    {     
        enemiesToSpawn.Enqueue(enemies[enemy]);
    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnQueued");
    }

    IEnumerator SpawnQueued()
    {
        while(enemiesToSpawn.Count > 0)
        {
            enemy = Instantiate(enemiesToSpawn.Dequeue(), nodePath.startNode.transform.position, Quaternion.identity).transform;
            GameyManager.spawnedEnemies.Add(enemy);

            EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
            enemyScript.Target = nodePath.startNode.GetComponent<Node>().nextNode;
            enemyScript.nodePath = this.nodePath;

            yield return new WaitForSeconds(delay);
        }
    }
}
