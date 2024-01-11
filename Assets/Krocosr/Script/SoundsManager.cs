using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;

    public AudioClip[] _Music;

    public AudioClip[] _Sfx;

    public AudioSource _SFXSource, _MusicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            _MusicSource.clip = _Music[0];
            _MusicSource.Play();
        }
    }
    public void AudioClip(AudioClip clip)
    {
        _SFXSource.PlayOneShot(clip);
    }
}
