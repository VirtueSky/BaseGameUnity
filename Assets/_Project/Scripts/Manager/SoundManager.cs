using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VirtueSky.Core;

public class SoundManager : BaseMono
{
    [FoldoutGroup("AudioSource")] public AudioSource backgroundAudio;
    [FoldoutGroup("AudioSource")] public AudioSource fxAudio;

    [FoldoutGroup("AudioClip")] [SerializeField]
    private AudioClip soundClickButton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Initialize()
    {
        base.Initialize();
        Setup();
    }

    public void OnMusicChanged()
    {
        backgroundAudio.mute = !Data.BgSoundState;
    }

    public void OnSoundChanged()
    {
        fxAudio.mute = !Data.FxSoundState;
    }

    public void Setup()
    {
        OnMusicChanged();
        OnSoundChanged();
    }

    public void PlaySoundFx(AudioClip _audioClip)
    {
        fxAudio.PlayOneShot(_audioClip);
    }

    public void PlayBackgroundMusic(AudioClip _audioClip)
    {
        backgroundAudio.clip = _audioClip;
        backgroundAudio.Play();
    }

    public void PauseBackground()
    {
        if (backgroundAudio)
        {
            backgroundAudio.Pause();
        }
    }

    public void ClickButton()
    {
        PlaySoundFx(soundClickButton);
    }
}