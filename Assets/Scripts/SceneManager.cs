using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    [SerializeField] Text _text;
    PlayerMoving _playerMove;
    Shooting _shoot;
    int _islandNum = 0;
    bool _isStart = false;
    bool _isEnd = false;

    private void Start()
    {
        GameObject player = GameObject.Find("Player_Character");
        _playerMove = player.GetComponent<PlayerMoving>();
        _shoot = player.GetComponent<Shooting>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetMouseButtonDown(0))
        {
            if (!_isStart) // В начале сцены по клику на экран очищаем текст и задаем движение к следующему вейпоинту
            {
                _text.text = "";
                _isStart = true;
                _playerMove.NextWaypoint();
            }

            if (_isEnd)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0); // На финише перезапускаем сцену
        }

        if (_playerMove.isStay) // Вкдючаем/Отключаем стрельбу если стоим/двигаемся
            _shoot.enabled = true;
        else
            _shoot.enabled = false;

        if (!_isEnd && _enemies[_islandNum].transform.childCount == 0)  // Когда все враги убиты переходим к следующему вейпоинту
        {
            _islandNum++;
            if(_islandNum != _enemies.Length)
                _playerMove.NextWaypoint();
        }

        if (_islandNum == _enemies.Length) // Если вейпоинтов нет отмечаем финиш
        {
            _text.text = "You won!" + Environment.NewLine + "Click to restart scene";
            _isEnd = true;
        }

    }
}