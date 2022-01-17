using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public GameplaySO _Gameplay;
    public GameStatisticSO _GameStatistic;
    public UIGameResultBehaviour _WinGameResultUI;
    public UIGameResultBehaviour _LoseGameResultUI;


    private void Start()
    {
        ActiveGameOverUI();
    }

    private void ActiveGameOverUI()
    {
        if (_GameStatistic.winnerTeam == _GameStatistic.masterTeam)
        {
            _WinGameResultUI.gameObject.SetActive(true);
        }
        else
        {
            _LoseGameResultUI.gameObject.SetActive(true);
        }
    }
}
