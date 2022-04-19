using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        // Allow for audio manager to be in multiple scenes with only one instance
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.file;
            s.source.volume = PlayerPrefs.GetFloat("gameVolume");
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string title)
    {
        Sound s = Array.Find(sounds, sound => sound.title == title);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + title + " does not exist.");
            return;
        }
        s.source.PlayOneShot(s.file);
    }
}
