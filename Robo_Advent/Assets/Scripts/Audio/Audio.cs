using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Audio
{
    public AudioMixerGroup audioMixerGroup;

    public string clipName;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float SpatialBlend;

    public bool loop = false;
    public bool playOnAwake = false;
}
