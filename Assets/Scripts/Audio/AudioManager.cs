using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour {


    private static AudioManager _instance;
    private AudioManager() { }
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    public string ResourceDir = "Audio";
    private AudioSource audioSource;

    void Awake()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;

    }

    #region BGM
    public bool Mute
    {
        get { return audioSource.mute; }
        set
        {
            audioSource.mute = value;
        }
    }

    public float BGMVolume //0-1
    {
        get { return audioSource.volume; }
        set { audioSource.volume = value; }
    }

    public void PlayBGM(string name)
    {
        string path = ResourceDir + "/" + name;
        AudioClip ac = Resources.Load<AudioClip>(path);
        audioSource.clip = ac;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.clip = null;
        audioSource.Stop();

    }
    #endregion

    //音效
    public void PlaySound(string name)
    {
        string path = ResourceDir + "/" + name;
        AudioClip ac = Resources.Load<AudioClip>(path);
        AudioSource.PlayClipAtPoint(ac, Vector2.zero);
    }
}
