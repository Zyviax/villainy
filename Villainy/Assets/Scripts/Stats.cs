using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Stats : MonoBehaviour
{
    public Text resource, retires, dead, spawned, end, damage, spells;

    void Start()
    {
        resource.text = "Resources Spent: " + GameyManager.resourcesSpent;
        retires.text = "Retries: " + GameyManager.retries;
        
        damage.text = "Damage Taken: " + GameyManager.damageTaken;
        spells.text = "Spells Cast: " + GameyManager.spellsCast;

        dead.text = "Units Dead - " +
            "\n Imp: " + GameyManager.enemiesDead[0] +
            "\n Priest: " + GameyManager.enemiesDead[1] +
            "\n Turtle: " + GameyManager.enemiesDead[2] +
            "\n Valkyrie: " + GameyManager.enemiesDead[3] +
            "\n Work Master: " + GameyManager.enemiesDead[4];

        spawned.text = "Units Spawned - " +
            "\n Imp: " + GameyManager.enemiesSpawned[0] +
            "\n Priest: " + GameyManager.enemiesSpawned[1] +
            "\n Turtle: " + GameyManager.enemiesSpawned[2] +
            "\n Valkyrie: " + GameyManager.enemiesSpawned[3] +
            "\n Work Master: " + GameyManager.enemiesSpawned[4];

        end.text = "Units Reached End - " +
            "\n Imp: " + GameyManager.enemiesReachedEnd[0] +
            "\n Priest: " + GameyManager.enemiesReachedEnd[1] +
            "\n Turtle: " + GameyManager.enemiesReachedEnd[2] +
            "\n Valkyrie: " + GameyManager.enemiesReachedEnd[3] +
            "\n Work Master: " + GameyManager.enemiesReachedEnd[4];
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
