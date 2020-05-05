﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardMain : MonoBehaviour
{
    BoardParam m_param;
    StopBoard m_boardStop;
    MoveBoard m_boardMove;
    BoardPreparation m_boardPreparation;

    TurnManager m_turn;

    void Start()
    {
        m_param = GetComponent<BoardParam>();
        m_param.Destination = Destination.None;

        m_boardStop = GetComponent<StopBoard>();
        m_boardMove = GetComponent<MoveBoard>();
        m_boardPreparation = GetComponent<BoardPreparation>();
        m_turn = FindObjectOfType<TurnManager>();
    }

    void Update()
    {
        //上にプレイヤーが乗っていなければ終了
        if (m_param.Player == null) return;
        //上に乗っているプレイヤーのターン出なければ終了
        if (m_turn.TurnPlayer().name!=m_param.Player.name) return;
        StateUpdate();
    }
    //状態更新
    void StateUpdate()
    {
        switch (m_param.BoardState)
        {
            case BoardState.Stop:StopBoard();break;
            case BoardState.Preparation:MovingPreparation();break;
            case BoardState.Moving:MovingBoard();break;
        }
    }
    //停止状態の処理
    void StopBoard()
    {
        m_boardStop.Stop();
    }
    //移動準備状態の処理
    void MovingPreparation()
    {
        m_boardPreparation.Preparation();
    }
    //移動状態の処理
    void MovingBoard()
    {
        //Debug.Log("moveing:" + gameObject.name);
        m_boardMove.Moving();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_param.Player = null;
            m_param.StateChange(BoardState.Stop);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (m_param.Player != null) return;
        if (other.gameObject.tag == "Player")
        {
            m_param.Player = other.gameObject;
        }

    }
}
