
public enum Soundeffects
{
    Jump = 0,
    Landing,
    LeftFoot,
    RightFoot,
    Teleport
}

public class PlayerSoundEffectsController : BaseAudioController
{
    public void PlaySoundEffect(Soundeffects soundEffect)
    {
        Audio soundEffectClip = FindSoundByClipIndex((int)soundEffect);

        if(soundEffectClip != null)
        {
            SetAudioSourceSettings(soundEffectClip);
            PlayOneShot(soundEffectClip.clip);
        }
    }
}
