using UnityEngine;

public class BGAudioController : BaseAudioController
{
    private void Start()
    {
        ChangeBGMTrack(Constants.LEVEL1_BGM);
    }

    public void ChangeBGMTrack(string clipName)
    {
        Audio bgmClip = FindSoundByClipName(clipName);
        SetAudioSourceSettings(bgmClip);
        SetAudioSourceClip(bgmClip.clip);
    }

    public void PlayBGM()
    {
        Play();
    }

    public void StopBGM()
    {
        Stop();
    }
}
