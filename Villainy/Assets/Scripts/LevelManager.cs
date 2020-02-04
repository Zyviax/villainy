using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelResources;
    public int levelMana;
    public float manaRestoreRate;

    public Text resources;
    public Text mana;

    void Start()
    {
        GameyManager.levelMana = this.levelMana;
        GameyManager.levelResources = this.levelResources;    
    }

    private void Update()
    {
        if (resources != null)
        {
            resources.text = GameyManager.levelResources.ToString();
        }

        if(mana != null)
        {
            mana.text = GameyManager.levelMana.ToString();
        }

        //todo: while game running: check if base destroyed or no units left
    }
}
