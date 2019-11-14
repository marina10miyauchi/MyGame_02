﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Start,
    Idle,
    Move,
    WithBoard,
    End,
}

public class PlayerParam : MonoBehaviour
{
    [SerializeField, Header("移動先")]
    GameObject m_target;
    public GameObject Target { get { return m_target; } set { m_target = value; } }

    [SerializeField, Header("プレイヤー番号")]
    PlayerNumber m_playerNum;
    public PlayerNumber PlayerNum { get { return m_playerNum; } set { m_playerNum = value; } }

    [SerializeField,Header("自分のターンか")]
    bool m_MyTurn=false;
    public bool IsMyTurn { get { return m_MyTurn; } set { m_MyTurn = value; } }

    [SerializeField, Header("Playerの状態")]
    PlayerState m_state=PlayerState.Start;
    public PlayerState PlayerState { get { return m_state; } set { m_state = value; } }

    [SerializeField, Header("自分の乗っている足場")]
    GameObject m_underBoard;
    public GameObject UnderBoard { get { return m_underBoard; } set { m_underBoard = value; } }

    [SerializeField, Header("足場が移動する")]
    bool m_isMoving;
    public bool IsMoving { get { return m_isMoving; } set { m_isMoving = value;} }

    [SerializeField, Header("ゴールしたか？")]
    bool m_isGoal;
    public bool IsGoal { get { return m_isGoal; } set { m_isGoal = value; } }
}