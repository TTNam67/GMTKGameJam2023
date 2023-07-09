using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    [SerializeField] GameObject[] _numbers;

    public void Reset()
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            _numbers[i].GetComponent<Number>().Reset();
        }
    }
}
