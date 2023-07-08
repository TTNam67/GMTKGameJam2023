using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject _numberSlots;
    [SerializeField] int _value = 0;
    [SerializeField] int _healthPoint = 50;
    int _hardRange = 2, _mediumRange = 3, _easyRange = 3, _totalRange;

    void Start()
    {
        _numberSlots = GameObject.Find("NumberSlots");
        if (_numberSlots == null)
            Debug.LogWarning("Enemy.cs: Numberslots is null.");

        _totalRange = _hardRange + _mediumRange + _easyRange;
    }
    



    public void Solve(int val)
    {
        List<KeyValuePair<int, string>> path = new List<KeyValuePair<int, string>>();
        
        int code = Random.Range(0, _totalRange);
        if (code < _hardRange)
        {
            path = HardSolve(val);
            Debug.Log("HardSolve");
        }
        else if (code < _hardRange + _mediumRange)
        {
            path = MediumSolve(val);
            Debug.Log("MediumSolve");
        }
        else 
        {
            path = EasySolve(val);
            Debug.Log("EasySolve");
        }


        if (path.Count > 0)
        {
            // Debug.Log("The best solution to reach 1 from " + val + " is: ");
            // foreach (KeyValuePair<int, string> step in path)
            // {
            //     Debug.Log(step.Value + ": " + step.Key);
            // }

            Debug.Log("Stamina spent: " + path.Count);
        }
    }

    public void RetrieveValue()
    {
        _value = _numberSlots.GetComponent<NumberSlots>().GetValue();
        Solve(_value);
    }




    static List<KeyValuePair<int, string>> HardSolve(int n)
    {
        Queue<List<KeyValuePair<int, string>>> q = new Queue<List<KeyValuePair<int, string>>>();
        HashSet<int> visited = new HashSet<int>();

        // Enqueue the initial number as a path
        q.Enqueue(new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(n, "") });
        visited.Add(n);

        while (q.Count > 0)
        {
            List<KeyValuePair<int, string>> currentPath = q.Dequeue();
            int currentNum = currentPath.Last().Key;

            if (currentNum == 1)
            {
                return currentPath; // Found the target number
            }

            // Generate next numbers by dividing or subtracting
            List<KeyValuePair<int, string>> nextNums = new List<KeyValuePair<int, string>>();

            if (currentNum % 2 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 2, "/2"));
            if (currentNum % 3 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 3, "/3"));
            if (currentNum % 5 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 5, "/5"));

            nextNums.Add(new KeyValuePair<int, string>(currentNum - 1, "-1"));
            nextNums.Add(new KeyValuePair<int, string>(currentNum - 2, "-2"));
            nextNums.Add(new KeyValuePair<int, string>(currentNum - 3, "-3"));

            foreach (KeyValuePair<int, string> nextNum in nextNums)
            {
                if (!visited.Contains(nextNum.Key) && nextNum.Key >= 1)
                {
                    List<KeyValuePair<int, string>> newPath = new List<KeyValuePair<int, string>>(currentPath);
                    newPath.Add(nextNum);
                    q.Enqueue(newPath);
                    visited.Add(nextNum.Key);
                }
            }
        }

        // Return an empty path if no solution is found
        return new List<KeyValuePair<int, string>>();
    }

    static List<KeyValuePair<int, string>> MediumSolve(int n)
    {
        Queue<List<KeyValuePair<int, string>>> q = new Queue<List<KeyValuePair<int, string>>>();
        HashSet<int> visited = new HashSet<int>();

        // Enqueue the initial number as a path
        q.Enqueue(new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(n, "") });
        visited.Add(n);

        while (q.Count > 0)
        {
            List<KeyValuePair<int, string>> currentPath = q.Dequeue();
            int currentNum = currentPath.Last().Key;

            if (currentNum == 1)
            {
                return currentPath; // Found the target number
            }

            // Generate next numbers by dividing or subtracting
            List<KeyValuePair<int, string>> nextNums = new List<KeyValuePair<int, string>>();

            
            if (currentNum % 5 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 5, "/5"));
            else if (currentNum % 3 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 3, "/3"));
            else if (currentNum % 2 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 2, "/2"));
            else if (currentNum > 3)
                nextNums.Add(new KeyValuePair<int, string>(currentNum - 3, "-3"));
            else if (currentNum > 2)
                nextNums.Add(new KeyValuePair<int, string>(currentNum - 2, "-2"));
            else if (currentNum > 1)
                nextNums.Add(new KeyValuePair<int, string>(currentNum - 1, "-1"));
            

            foreach (KeyValuePair<int, string> nextNum in nextNums)
            {
                if (!visited.Contains(nextNum.Key) && nextNum.Key >= 1)
                {
                    List<KeyValuePair<int, string>> newPath = new List<KeyValuePair<int, string>>(currentPath);
                    newPath.Add(nextNum);
                    q.Enqueue(newPath);
                    visited.Add(nextNum.Key);
                }
            }
        }

        // Return an empty path if no solution is found
        return new List<KeyValuePair<int, string>>();
    }

    static List<KeyValuePair<int, string>> EasySolve(int n)
    {
        Queue<List<KeyValuePair<int, string>>> q = new Queue<List<KeyValuePair<int, string>>>();
        HashSet<int> visited = new HashSet<int>();

        // Enqueue the initial number as a path
        q.Enqueue(new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(n, "") });
        visited.Add(n);

        while (q.Count > 0)
        {
            List<KeyValuePair<int, string>> currentPath = q.Dequeue();
            int currentNum = currentPath.Last().Key;

            if (currentNum == 1)
            {
                return currentPath; // Found the target number
            }

            // Generate next numbers by dividing or subtracting
            List<KeyValuePair<int, string>> nextNums = new List<KeyValuePair<int, string>>();


            if (currentNum % 2 == 0)
                nextNums.Add(new KeyValuePair<int, string>(currentNum / 2, "/2"));
            else
                nextNums.Add(new KeyValuePair<int, string>(currentNum - 1, "-1"));


            foreach (KeyValuePair<int, string> nextNum in nextNums)
            {
                if (!visited.Contains(nextNum.Key) && nextNum.Key >= 1)
                {
                    List<KeyValuePair<int, string>> newPath = new List<KeyValuePair<int, string>>(currentPath);
                    newPath.Add(nextNum);
                    q.Enqueue(newPath);
                    visited.Add(nextNum.Key);
                }
            }
        }

        // Return an empty path if no solution is found
        return new List<KeyValuePair<int, string>>();
    }


}
