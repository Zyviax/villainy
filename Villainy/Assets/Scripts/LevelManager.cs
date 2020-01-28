using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelResources;

    public Text resources;

    void Start()
    {
        GameyManager.levelResources = this.levelResources;    
    }

    private void Update()
    {
        resources.text = GameyManager.levelResources.ToString();
        EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();

        enemyScript.Target = nodePath.startNode.GetComponent<Node>().nextNode;
        enemyScript.nodePath = this.nodePath;
    }
}
