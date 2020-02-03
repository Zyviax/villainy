using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void MapMenu()
    {
        SceneManager.LoadScene("MapMenu");
    }


    //either add a controls menu or settings menu :)
    // public void Controls()
    // {
    //     SceneManager.LoadScene("Controls");
    // }


    public void Quit()
    {
        Application.Quit();
    }
}
