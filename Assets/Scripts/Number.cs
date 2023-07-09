using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Number : MonoBehaviour, 
IPointerDownHandler, IPointerUpHandler,
IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvas;
    RectTransform _rectTransform;
    CanvasGroup _canvasGroup;
    [SerializeField] Image _image;
    [SerializeField] Sprite[] _sprites; 

    [SerializeField] Vector3 _originalPosition;

    public int _cnt, _randTimes = 45, _value = 0;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform == null)
            Debug.LogWarning("DragDrop.cs: RectTransform is null.");

        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogWarning("DragDrop.cs: Image is null.");

        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
            Debug.LogWarning("DragDrop.cs: CanvasGroup is null.");

        _originalPosition = transform.position;      
        Reset();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // print("OnBeginDrag");
        _canvasGroup.alpha = 0.7f;

        // Raycast goes through this object and lands on the items on
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // print("Dragging");
        _rectTransform.anchoredPosition += (eventData.delta / _canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // print("OnEndDrag");
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        // print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // print("Up");
    }

    public void RandomNumber()
    {
         _cnt = _randTimes;
            StartCoroutine(RandNumber());
    }

    IEnumerator RandNumber()
    {
        while(_cnt > 0)
        {
            _value = Random.Range(0, 10);
            _image.sprite = _sprites[_value];
            
            yield return new WaitForSeconds(.02f);
            _cnt--;
        }   
    }

    public void BackToOrigin()
    {
        transform.position = _originalPosition;
    }

    public void Reset() 
    {
        BackToOrigin();
        RandomNumber();
    }
}
