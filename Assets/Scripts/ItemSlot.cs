using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int _base;
    [SerializeField] bool _isOccupied = false; // If there is any number in this slot 
    public int _value;
    public void OnDrop(PointerEventData eventData)
    {
        // eventData.pointerDrag: The gameObject that is currently being dragged
        GameObject draggedObject = eventData.pointerDrag;

        if (_isOccupied)
        {
            draggedObject.GetComponent<DragDrop>().BackToOrigin();
            return;
        }

        _isOccupied = true;
        
        if (draggedObject != null)
        {
            
            draggedObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            _value = draggedObject.GetComponent<DragDrop>()._value * _base;
        }

        GameObject.Find("NumberSlots").GetComponent<NumberSlots>().CountingValue();

        
    }

    public bool IsOccupied()
    {
        return _isOccupied;
    }

    

}
