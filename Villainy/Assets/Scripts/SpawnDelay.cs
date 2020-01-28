using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDelay : MonoBehaviour
{
    public Queue<GameObject> enemiesToSpawn;

    public float delay;
    public BasicNodePath nodePath;

    private Transform enemy;

    public List<GameObject> enemies;

    public void addEnemy()
    {
        enemiesToSpawn.Enqueue(enemies[0]);
    }

    IEnumerator spawnQueued()
    {
        while(enemiesToSpawn.Count > 0)
        {
            enemy = Instantiate(enemiesToSpawn.Dequeue(), nodePath.startNode.transform.position, Quaternion.identity).transform;

            EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
            enemyScript.Target = nodePath.startNode.GetComponent<Node>().nextNode;
            enemyScript.nodePath = this.nodePath;

            yield return new WaitForSeconds(delay);
        }
    }
}
