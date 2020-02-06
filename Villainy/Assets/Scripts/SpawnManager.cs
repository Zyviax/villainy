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

    public Transform queueItem;
    public Transform wholeQueue;
    private Vector3 coords;

    public void Start()
    {
        enemiesToSpawn = new Queue<GameObject>();
        nodePath = GameObject.FindGameObjectWithTag("NodeManager").GetComponent<BasicNodePath>();

        coords = new Vector3(0, 290,0);
    }

    public void AddToQueue(int enemy)
    {     
        if(enemies[enemy].GetComponent<EnemyAI>().enemy.UnitCost <= GameyManager.levelResources)
        {
            enemiesToSpawn.Enqueue(enemies[enemy]);
            Transform unit = Instantiate(queueItem);
            unit.SetParent(wholeQueue);
            coords.y -= 40;
            unit.transform.localPosition = coords;
            Image imageComponent = unit.GetComponent<Image>();
            imageComponent.sprite = enemies[enemy].GetComponent<SpriteRenderer>().sprite;
            GameyManager.levelResources -= enemies[enemy].GetComponent<EnemyAI>().enemy.UnitCost;
        }
    }

    public void StartSpawning()
    {
        GameyManager.gameState = GameyManager.GameState.Play;
        StartCoroutine("SpawnQueued");
    }

    IEnumerator SpawnQueued()
    {
        while(enemiesToSpawn.Count > 0)
        {
            enemy = Instantiate(enemiesToSpawn.Dequeue(), nodePath.startNode.transform.position, Quaternion.identity).transform;
            wholeQueue.position += Vector3.up * 40f;
            GameyManager.spawnedEnemies.Add(enemy);

            EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
            enemyScript.Target = nodePath.startNode.GetComponent<Node>().nextNode;
            enemyScript.nodePath = this.nodePath;

            yield return new WaitForSeconds(delay);
        }
    }
}
