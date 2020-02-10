using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameyManager;

public class LevelManager : MonoBehaviour
{
    public int levelResources;
    public int levelMana;
    public float manaRestoreRate;

    public bool isTutorial;

    public Text resources;
    public Text mana;

    public static bool tutorialDone = false;

    void Start()
    {
        GameyManager.gameState = isTutorial == true ? GameState.Tutorial : GameState.Queue;
        if(tutorialDone) {
            GameyManager.gameState = GameState.Queue;
        }

        GameyManager.levelMana = this.levelMana;
        GameyManager.levelResources = this.levelResources;
        GameyManager.manaMax = this.levelMana;
        GameyManager.resourcesMax = this.levelResources;
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
    }
}
