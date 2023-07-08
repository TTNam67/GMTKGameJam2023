using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSlots : MonoBehaviour
{
    [SerializeField] int _value;
    [SerializeField] int _check = 0;
    
    [SerializeField] GameObject[] _itemSlots;
    GameObject _enemy;
    void Start()
    {
        _enemy = GameObject.FindWithTag("Enemy");
        if (_enemy == null)
        {
            Debug.LogWarning("NumberSlots.cs: Enemy is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // CountingValue();
    }

    public void CountingValue()
    {
        _value = 0;
        _check = 0;
        for (int i = 0; i < _itemSlots.Length; i++)
        {
            ItemSlot slot = _itemSlots[i].GetComponent<ItemSlot>();
            _value += slot._value;
            if (slot.IsOccupied()) _check++;
        }

        if (_check >= 3)
        {
            _enemy.GetComponent<Enemy>().RetrieveValue();
        }
    }

    public int GetValue()
    {
        return _value;
    }
}
