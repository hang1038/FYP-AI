﻿using UnityEngine;

[System.Serializable]
public class Sound {

    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;

    public string name;

    [Range(0f, 1f)]
    public float volume;

    public bool playOnAwake;
    public bool loop;
}
