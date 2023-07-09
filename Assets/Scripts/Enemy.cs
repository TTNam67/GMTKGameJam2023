using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _numberSlots;
    [SerializeField] GameObject _numbers;
    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] GameController _gameController;
    [SerializeField] int _value = 0;
    [SerializeField] float _healthPoint, _damage, _maxHealthPoint = 30f, _healthRegen = 7f;
    
    int _hardRange = 2, _mediumRange = 3, _easyRange = 3, _totalRange;
    
    EnemyHealthBar _enemyHealthBar;

    void Start()
    {
        _numberSlots = GameObject.Find("NumberSlots");
        if (_numberSlots == null)
            Debug.LogWarning("Enemy.cs: Numberslots is null.");

        _numbers = GameObject.Find("Numbers");
        if (_numbers == null)
            Debug.LogWarning("Enemy.cs: Numbers is null.");

        _enemyHealthBar = GameObject.Find("EnemyHealthBar").GetComponent<EnemyHealthBar>();
        if (_enemyHealthBar == null)
            Debug.LogWarning("Enemy.cs: EnemyHealthBar is null.");

        _textMeshPro = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        if (_textMeshPro == null)
            Debug.LogWarning("Enemy.cs: TextMeshPro is null.");

        _gameController = GameObject.FindWithTag("MainCamera").GetComponent<GameController>();
        if (_gameController == null)
            Debug.LogWarning("Enemy.cs: GameController is null.");

        _textMeshPro.text = "";

        _totalRange = _hardRange + _mediumRange + _easyRange;
        _healthPoint = _maxHealthPoint;
    }
    



    public void Solve(int val)
    {
        _textMeshPro.text = "";
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

        path.RemoveAt(0);


        if (path.Count > 0)
        {
            _textMeshPro.text += "Solution for " + _value + " is: \n";
            foreach (KeyValuePair<int, string> step in path)
            {
                _textMeshPro.text += step.Value + ": " + step.Key + "\n";
            }

            _textMeshPro.text += "Stamina spent: " + path.Count;
        }

        _damage = path.Count;
        
    }

    public void Reset()
    {
        if (_numberSlots.GetComponent<NumberSlots>()._check == 3)
        {
            _healthPoint = Mathf.Min(_healthPoint + _healthRegen, _maxHealthPoint);
            UpdateHealthVisual();
            _numberSlots.GetComponent<NumberSlots>().Reset();
            _numbers.GetComponent<Numbers>().Reset();
            _value = 0;
            _textMeshPro.text = "";
        }
    }

    public void RetrieveValue()
    {
        _value = _numberSlots.GetComponent<NumberSlots>().GetValue();
        Solve(_value);

        TakeDamage(_damage);
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

    void TakeDamage(float damage)
    {
        UpdateTurnsLeft();

        _healthPoint = Mathf.Max(0f, _healthPoint - damage);
        if (_healthPoint <= 0f)
        {
            Die();
        }

        UpdateHealthVisual();
        // Reset();
    }

    private void UpdateTurnsLeft()
    {
        _gameController._turnsLimit--;
        _gameController.UpdateTurnsLeft(_gameController._turnsLimit);
        if (_gameController._turnsLimit == 0)
            _gameController.GameOverLose();
    }

    private void UpdateHealthVisual()
    {
        
        _enemyHealthBar.SetHealth(_healthPoint);
    }


    public void Die()
    {
        _gameController.GameOverWin();
    }

}
