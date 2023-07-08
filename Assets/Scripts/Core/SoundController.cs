using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("SoundController.cs: AudioSource is not found");

        _audioSource.volume = 0.9f;
        _audioSource.Play();

        DontDestroyOnLoad(this.gameObject);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
