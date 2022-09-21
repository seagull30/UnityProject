using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public bool IsGameOver { get; private set; }
    public int Turn;
    public PlayerController _player;
    public event UnityAction<GridIndex> OnTurnEnd;
    public event UnityAction NextStage;
    public UnityEvent OnGameEnd = new UnityEvent();

    public Board Board;

    private bool _isEnd = false; // 게임 오버 상태

    private void Awake()
    {
        _player.TurnOver.AddListener(Turnover);
    }

    private void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            reset();
        }
    }

    void Turnover(GridIndex playerPos)
    {
        Debug.Log("asd");
        OnTurnEnd?.Invoke(playerPos);
    }

    public void End()
    {
        _isEnd = true;
        OnGameEnd.Invoke();
        //OnGameEnd2?.Invoke();
    }

    private void reset()
    {
        _player.TurnOver.RemoveAllListeners();
        _player.TurnOver.AddListener(Turnover);
        _isEnd = false;
    }

}
