using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPicker : MonoBehaviour
{
    public AudioClip NewMusic;
    public float volume;

    void Awake()
    {
        AudioSource go = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
        if(go != null)
        {
            go.volume = this.volume;
            if(go.clip != NewMusic)
            {
                go.clip = NewMusic; //Replaces the old audio with the new one set in the inspector.
                go.Play(); //Plays the audio.
            }
        }
        
    }
}
