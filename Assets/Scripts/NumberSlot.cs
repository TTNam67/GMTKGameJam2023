using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int _base;
    [SerializeField] bool _isOccupied = false; // If there is any number in this slot 
    public int _value = 0;
    GameObject _draggedObject;
    public void OnDrop(PointerEventData eventData)
    {

        // eventData.pointerDrag: The gameObject that is currently being dragged
        _draggedObject = eventData.pointerDrag;
        _draggedObject.GetComponent<Number>()._draggable = false;

        if (_isOccupied)
        {
            _draggedObject.GetComponent<Number>().BackToOrigin();
            return;
        }

        _isOccupied = true;
        
        if (_draggedObject != null)
        {
            
            _draggedObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            _value = _draggedObject.GetComponent<Number>()._value * _base;
        }

        GameObject.Find("NumberSlots").GetComponent<NumberSlots>().CountingValue();

        
    }

    public bool IsOccupied()
    {
        return _isOccupied;
    }

    public void Reset()
    {
        _isOccupied = false;
        _draggedObject.GetComponent<Number>().BackToOrigin();
        _value = 0;
    }
    

}
