using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPicker : MonoBehaviour
{
    public AudioClip NewMusic;

    void Awake()
        {
        AudioSource go = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
        go.clip = NewMusic; //Replaces the old audio with the new one set in the inspector.
        go.Play(); //Plays the audio.
    }
}
