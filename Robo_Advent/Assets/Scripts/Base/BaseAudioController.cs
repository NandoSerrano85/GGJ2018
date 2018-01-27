using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class BaseAudioController : MonoBehaviour
{
    [SerializeField] private Audio[] sounds;
    private AudioSource source;
    private bool paused;

    protected virtual void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    protected void SetAudioSourceClip(AudioClip audioClip)
    {
        source.clip = audioClip;
    }

    protected void SetAudioSourceSettings(Audio sound)
    {
        source.pitch = sound.pitch;
        source.volume = sound.volume;
        source.playOnAwake = sound.playOnAwake;
        source.loop = sound.loop;
        source.spatialBlend = sound.SpatialBlend;
        source.outputAudioMixerGroup = sound.audioMixerGroup;
    }

    protected Audio FindSoundByClipName(string clipName)
    {
        return Array.Find(sounds, sound => sound.clipName == clipName);
    }

    protected Audio FindSoundByClipIndex(int clipIndex)
    {
        if (InRange(clipIndex))
            return sounds[clipIndex];

        return null;
    }

    public bool InRange(int clipIndex)
    {
        return clipIndex >= 0 && clipIndex < sounds.Length;
    }

    protected virtual void Play()
    {
        source.Play();
    }

    protected virtual void PlayOneShot(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    protected virtual void Stop()
    {
        if(source.isPlaying || paused)
            source.Stop();
    }

    protected virtual void Pause()
    {
        if (source.isPlaying)
        {
            source.Pause();
            paused = true;
        }
    }

    protected virtual void Resume()
    {
        if (paused)
        {
            source.UnPause();
            paused = false;
        }
    }

    protected bool isAudioPaused()
    {
        return paused;
    }

    protected bool isAudioPlaying()
    {
        return source.isPlaying;
    }
}
