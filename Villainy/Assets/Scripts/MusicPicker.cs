using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPicker : MonoBehaviour
{
    public AudioClip NewMusic;
    public float volume;

    private AudioSource go;

    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("MusicManager");
        if (obj != null)
        {
            go = obj.GetComponent<AudioSource>();
            if (go != null)
            {
                go.volume = this.volume;
                if (go.clip != NewMusic)
                {
                    go.clip = NewMusic; //Replaces the old audio with the new one set in the inspector.
                    go.Play(); //Plays the audio.
                }

            }
        }
    }
}
