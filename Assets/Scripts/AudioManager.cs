using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] effects;
    public Sound[] music;

    private bool shouldPlayMusic = false;

    public static AudioManager instance;

    private float mVol;
    private float eVol;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        mVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        eVol = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);

        CreateAudioSources(effects, eVol);
        CreateAudioSources(music, mVol);
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(effects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Unable to play sound effect " + name);
            return;
        }
        s.source.PlayOneShot(s.clip);
    }

    public void PlayMusic(string name)
    {
        if (shouldPlayMusic == false)
        {
            shouldPlayMusic = true;
        }
        Sound m = Array.Find(music, music => music.name == name);
        if (m == null)
        {
            Debug.LogError("Unable to play music " + name);
            return;
        }
        m.source.Play();
    }

    public void StopMusic(string name)
    {
        if (shouldPlayMusic == true)
        {
            shouldPlayMusic = false;
        }

        Sound m = Array.Find(music, music => music.name == name);
        if (m == null)
        {
            Debug.LogError("Unable to stop music " + name);
            return;
        }
        m.source.Stop();
    }

    public void MusicVolumeChanged()
    {
        foreach (Sound m in music)
        {
            mVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
            m.source.volume = m.volume * mVol;
        }
    }

    public void EffectVolumeChanged()
    {
        eVol = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);
        foreach (Sound s in effects)
        {
            s.source.volume = s.volume * eVol;
        }
        //effects[0].source.Play();
    }

    private void CreateAudioSources(Sound[] sounds, float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
}
