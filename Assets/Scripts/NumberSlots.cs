using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSlots : MonoBehaviour
{
    public int _value;
    
    [SerializeField] GameObject[] _itemSlots;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // CountingValue();
    }

    public void CountingValue()
    {
        _value = 0;
        for (int i = 0; i < _itemSlots.Length; i++)
        {
            _value += _itemSlots[i].GetComponent<ItemSlot>()._value;
        }
    }
}
