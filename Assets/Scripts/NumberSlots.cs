using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSlots : MonoBehaviour
{
    [SerializeField] int _value = 0;
    [SerializeField] int _check = 0;
    
    [SerializeField] GameObject[] _numberSlots;
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
        for (int i = 0; i < _numberSlots.Length; i++)
        {
            NumberSlot slot = _numberSlots[i].GetComponent<NumberSlot>();
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

    public void Reset()
    {
        _check = 0;
        _value = 0;
        for (int i = 0; i < _numberSlots.Length; i++)
        {
            NumberSlot slot = _numberSlots[i].GetComponent<NumberSlot>();
            slot.Reset();
        }
    }
}
