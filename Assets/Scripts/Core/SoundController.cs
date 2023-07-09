using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("SoundController.cs: AudioSource is not found");

        // _audioSource.Stop();
        _audioSource.volume = 1.0f;
        // _audioSource.loop = true;
        _audioSource.Play();

        // _audioSource.PlayOneShot(_audioClip);

        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
