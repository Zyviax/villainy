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
        if (resources != null)
        {
            resources.text = GameyManager.levelResources.ToString();
        }

        //while game running: check if base destroyed or no units left
    }
}
