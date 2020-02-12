using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemiesToSpawn;
    

    public float delay;
    public BasicNodePath nodePath;

    private int queueSize = 40;

    private Transform enemy;

    public List<GameObject> enemies;
    public List<Button> unitButtons;

    public List<Transform> queueUnits;

    public Transform queueItem;
    public Transform wholeQueue;
    private Vector3 coords;

    private GameObject GameEnd;
    private Objective objective;

    public BarScript bar;

    public PlayerController playerController;

    public void Start()
    {
        enemiesToSpawn = new List<GameObject>();
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

                GameyManager.retries += 1;
            }
        }
    }

    public void AddToQueue(int enemy)
    {     
        if(GameyManager.gameState != GameyManager.GameState.Play)
        {
            if(enemies[enemy].GetComponent<EnemyAI>().enemy.UnitCost <= GameyManager.levelResources)
            {
                enemiesToSpawn.Add(enemies[enemy]);
                Transform unit = Instantiate(queueItem);
                unit.SetParent(wholeQueue);
                coords.y -= queueSize;
                unit.transform.localPosition = coords;
                Image imageComponent = unit.GetComponent<Image>();
                imageComponent.sprite = enemies[enemy].GetComponent<SpriteRenderer>().sprite;
                GameyManager.levelResources -= enemies[enemy].GetComponent<EnemyAI>().enemy.UnitCost;

                queueUnits.Add(unit);

                bar.UpdateImage();
            }

            for(int i=0; i<enemies.Count; i++)
            {
                if(enemies[i].GetComponent<EnemyAI>().enemy.UnitCost > GameyManager.levelResources)
                {
                    unitButtons[i].interactable = false;
                }
            }
        }
    }

    public void StartSpawning()
    {
        // if(Time.timeScale != PlayPauseFastforward.normalMax) Time.timeScale = PlayPauseFastforward.normalMax;
        //stops the player from spawning multiple waves.
        if(GameyManager.gameState == GameyManager.GameState.Play || enemiesToSpawn.Count == 0)
        {
            return;
        } else {
            GameyManager.gameState = GameyManager.GameState.Play;
            StartCoroutine("SpawnQueued");
            playerController.EnableSpells();
        }
        
    }

    IEnumerator SpawnQueued()
    {
        while(enemiesToSpawn.Count > 0)
        {
            enemy = Instantiate(enemiesToSpawn[0], nodePath.startNode.transform.position, Quaternion.identity).transform;

            switch (enemy.GetComponent<EnemyAI>().enemy.enemyName)
            {
                case "Imp":
                    GameyManager.enemiesSpawned[0] += 1;
                    GameyManager.resourcesSpent += enemy.GetComponent<EnemyAI>().enemy.UnitCost;
                    break;
                case "Priest":
                    GameyManager.enemiesSpawned[1] += 1;
                    GameyManager.resourcesSpent += enemy.GetComponent<EnemyAI>().enemy.UnitCost;
                    break;
                case "Turtle":
                    GameyManager.enemiesSpawned[2] += 1;
                    GameyManager.resourcesSpent += enemy.GetComponent<EnemyAI>().enemy.UnitCost;
                    break;
                case "Valkyrie":
                    GameyManager.enemiesSpawned[3] += 1;
                    GameyManager.resourcesSpent += enemy.GetComponent<EnemyAI>().enemy.UnitCost;
                    break;
                case "Work Master":
                    GameyManager.enemiesSpawned[4] += 1;
                    GameyManager.resourcesSpent += enemy.GetComponent<EnemyAI>().enemy.UnitCost;
                    break;
            }
            
            enemiesToSpawn.RemoveAt(0);

            wholeQueue.localPosition += Vector3.up * queueSize;
            GameyManager.spawnedEnemies.Add(enemy);

            EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
            enemyScript.Target = nodePath.startNode.GetComponent<Node>().nextNode;
            enemyScript.nodePath = this.nodePath;

            yield return new WaitForSeconds(delay);
        }
    }

    public void UndoQueue()
    {
        if(enemiesToSpawn.Count == 0) return;
        
        GameyManager.levelResources += enemiesToSpawn[enemiesToSpawn.Count - 1].GetComponent<EnemyAI>().enemy.UnitCost;

        Destroy(queueUnits[queueUnits.Count - 1].gameObject);
            
        queueUnits.RemoveAt(queueUnits.Count - 1);
        enemiesToSpawn.RemoveAt(enemiesToSpawn.Count - 1);

        coords.y += queueSize;

        bar.UpdateImage();

        for(int i=0; i<enemies.Count; i++)
        {
            if(enemies[i].GetComponent<EnemyAI>().enemy.UnitCost <= GameyManager.levelResources)
            {
                if(unitButtons[i].name != "disabled") 
                {
                    unitButtons[i].interactable = true;
                }
            }
        }
    }

    public void ResetQueue()
    {
        GameyManager.levelResources = GameyManager.resourcesMax;

        coords.y += queueUnits.Count * queueSize;

        foreach(Transform unit in queueUnits)
        {
            Destroy(unit.gameObject);
        }

        queueUnits.Clear(); 
        enemiesToSpawn.Clear(); 

        bar.UpdateImage();
    }
}
