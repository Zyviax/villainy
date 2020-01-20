using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    public static bool playing;   
    public Button myBtn;   
    public Sprite Play;
    public Sprite Pause;
    public KeyCode playControl;

    public static bool fastForward;
    public Button ffBtn;
    public Sprite FastFowardOff;
    public Sprite FastForwardOn;
    public KeyCode ffControl;

    public void PlayClick()
    {
        ChangePlayState();
    }

    public void ChangePlayState()
    {
        playing = !playing;
        if(playing)
        {
            myBtn.image.sprite = Pause;
        }
        else
        {
            myBtn.image.sprite = Play;
        }
    }

    public void FfClick()
    {
        ChangeFfState();
    }

    public void ChangeFfState()
    {
        fastForward = !fastForward;
        if (fastForward)
        {
            ffBtn.image.sprite = FastForwardOn;
            Time.timeScale = 2;
        }
        else
        {
            ffBtn.image.sprite = FastFowardOff;
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(playControl))
        {
            ChangePlayState();
        }

        if(Input.GetKeyUp(ffControl))
        {
            ChangeFfState();
        }
    }
}
