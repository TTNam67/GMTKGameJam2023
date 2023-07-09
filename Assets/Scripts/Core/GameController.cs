using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameOverScreen _gameOverScreen;
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] TextMeshProUGUI _turnsLeftText;
    [SerializeField] public int _turnsLimit, _maxTurnsLimit = 8;
    void Start()
    {
        _gameOverScreen.gameObject.SetActive(false);
        _turnsLimit = _maxTurnsLimit;
        _turnsLeftText.text = "Turns left: " + _turnsLimit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverWin()
    {
        _gameOverText.text = "You Won";
        _gameOverScreen.gameObject.SetActive(true);
    }

    public void GameOverLose()
    {
        _gameOverText.text = "You Lose";
        _gameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateTurnsLeft(int turn)
    {
        _turnsLeftText.text = "Turns left: " + turn;
    }
}
