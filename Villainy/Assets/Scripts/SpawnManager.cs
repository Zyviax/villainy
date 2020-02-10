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

    private GameObject GameEnd;
    private Objective objective;

    public BarScript bar;

    public void Start()
    {
        enemiesToSpawn = new Queue<GameObject>();
        nodePath = GameObject.FindGameObjectWithTag("NodeManager").GetComponent<BasicNodePath>();

        coords = new Vector3(0, 290,0);

        GameEnd = GameObject.FindWithTag("EndUI");
        Transform child = GameEnd.GetComponentsInChildren<Transform>(true)[1];
        child.gameObject.SetActive(false);

        GameObject objectiveGO = GameObject.FindGameObjectWithTag("Objective");
        objective = objectiveGO.GetComponent<Objective>();
    }

    void Update()
    {
        //Checks if all enemies are dead.
        if(GameyManager.gameState == GameyManager.GameState.Play)
        {
            if(enemiesToSpawn.Count == 0 && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                GameyManager.gameState = GameyManager.GameState.End;
                GameObject UI = GameObject.FindWithTag("MainUI");
                UI.SetActive(false);
                
                GameEnd = GameObject.FindWithTag("EndUI");
                Transform child = GameEnd.GetComponentsInChildren<Transform>(true)[1];
                child.gameObject.SetActive(true);
                Text endText = GameEnd.GetComponentInChildren<Text>();
                endText.text = "Rats! \n I needed " + objective.health + " more damage";
            }
        }
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

            bar.UpdateImage();
        }
    }

    public void StartSpawning()
    {
        //stops the player from spawning multiple waves.
        if(GameyManager.gameState == GameyManager.GameState.Play)
        {
            return;
        } else {
            GameyManager.gameState = GameyManager.GameState.Play;
            StartCoroutine("SpawnQueued");
        }
        
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
