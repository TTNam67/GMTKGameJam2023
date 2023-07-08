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
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
        } 

        

        
    }

}
