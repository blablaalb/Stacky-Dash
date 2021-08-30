using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using Common;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : Singleton<AudioPlayer>
{
    private AudioSource _audSource;

    override protected void Awake()
    {
        base.Awake();
        _audSource = GetComponent<AudioSource>();
    }

    public void PlayAudioCLip(AudioClip clip)
    {
        _audSource.PlayOneShot(clip);
    }

    public void PlayRandomAudioClip(AudioClip[] audioClips)
    {
        int indx = Random.Range(0, audioClips.Length);
        var audClip = audioClips[indx];
        PlayAudioCLip(audClip);
    }
}