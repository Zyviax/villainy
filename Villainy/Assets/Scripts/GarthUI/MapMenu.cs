using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public void Tutorial(int value)
    {
        SceneManager.LoadScene("Tutorial_"+value);
    }

    public void Level(int value)
    {
        SceneManager.LoadScene("Level_"+value);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
