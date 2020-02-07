using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public float health;

    private float maxHealth;

    public Image HP;

    //public GameObject PauseEnd;
    private GameObject UI, GameEnd;

    // Start is called before the first frame update
    void Start()
    {
        if(GameyManager.gameState != GameyManager.GameState.Menu)
        {
            maxHealth = health;
            UI = GameObject.FindWithTag("MainUI");
            //PauseEnd = GameObject.FindWithTag("PauseUI");
            GameEnd = GameObject.FindWithTag("EndUI");
            GameEnd.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameyManager.gameState != GameyManager.GameState.Menu)
        {
            HP.fillAmount = health / maxHealth;

            if (health <= 0)
            {
                GameyManager.gameState = GameyManager.GameState.End;
                UI.SetActive(false);
                GameEnd.SetActive(true);
                Text endText = GameEnd.GetComponentInChildren<Text>();
                endText.text = "Congratulations!";
                Debug.Log(GameyManager.levelsCompleted);
                GameyManager.levelsCompleted += 1;
                Debug.Log(GameyManager.levelsCompleted);
                //enable fire effect... or some animation of a house burning down
                Destroy(this.gameObject);
            }
        }
    }
}
