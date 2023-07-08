using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int _base;
    public int _value;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop Item");
        

        // eventData.pointerDrag: The gameObject that is currently being dragged
        GameObject draggedObject = eventData.pointerDrag;
        
        if (draggedObject != null)
        {
            draggedObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            _value = draggedObject.GetComponent<DragDrop>()._value * _base;
        }

        GameObject.Find("NumberSlots").GetComponent<NumberSlots>().CountingValue();

        
    }

}
