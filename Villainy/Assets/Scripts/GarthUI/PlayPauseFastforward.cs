using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseFastforward : MonoBehaviour
{
    private float currentMax;
    
    public Text play;
    public Text fast;

    void Start()
    {
        currentMax = 1;
        Time.timeScale = 0;
        play.text = "Play";
    }

    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? currentMax : 0;
        if(play.text == "Play")
        {
            play.text = ">";
            return;
        }
        play.text = play.text == ">" ? "||" : ">";
    }

    public void ToggleFast()
    {
        currentMax = currentMax == 1 ? 3 : 1;
        Time.timeScale = Time.timeScale == 0 ? 0 : currentMax;
        fast.text = fast.text == ">>" ? "[>>]" : ">>";
    }
}
