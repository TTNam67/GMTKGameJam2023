using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressedClip, _uncompressedClip;
    [SerializeField] private AudioSource _audioSource;
    RectTransform _rectTransform;
    float _changeY = 5.6f;
    float _uncompressedSoundScale = 0.7f, _compressedSoundScale = 0.7f;

    private void Start() 
    {
        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogWarning("ClickyButton.cs: _image is null");

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("ClickyButton.cs: _audioSource is null");

        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform == null)
        {
            Debug.LogWarning("ClickyButton.cs: _rectTransform is null");
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        _audioSource.volume = _uncompressedSoundScale;
        _audioSource.PlayOneShot(_uncompressedClip);

        Invoke("LoadGameScene", 0f);

        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y += _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        _audioSource.volume = _compressedSoundScale; 
        _audioSource.PlayOneShot(_compressedClip);
        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y -= _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
        
        
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}