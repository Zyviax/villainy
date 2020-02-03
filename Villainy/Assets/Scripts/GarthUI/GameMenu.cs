using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pauseActive;

    public GameObject GameEnd;
    public GameObject mainUI;

    void Start()
    {
        pauseActive = false;
        pauseMenu.SetActive(pauseActive);
    }

    void Update()
    {
        //todo make the button change on GUI for paused/play
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = !pauseActive;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            pauseMenu.SetActive(pauseActive);
        }
    }

    public void MapMenu()
    {
        SceneManager.LoadScene("MapMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        pauseActive = !pauseActive;
        pauseMenu.SetActive(pauseActive);
        Time.timeScale = 1;
    }

    public void Settings()
    {
        //todo
    }

}
