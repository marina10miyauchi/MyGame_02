using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー状態
/// </summary>
public enum PlayerState
{
    /// <summary>
    /// 初期状態
    /// </summary>
    Start,
    /// <summary>
    /// 待機状態
    /// </summary>
    Idle,
    /// <summary>
    /// 移動状態
    /// </summary>
    Move,
    /// <summary>
    /// 移動床に乗っている状態
    /// </summary>
    WithBoard,
    /// <summary>
    /// 移動終了状態
    /// </summary>
    End,
    /// <summary>
    /// ゴール状態
    /// </summary>
    Goal,
}

public class PlayerParam : MonoBehaviour
{
    [SerializeField, Header("移動先")]
    GameObject m_target;
    /// <summary>
    /// 移動先（移動したいマスをマークするターゲット）
    /// </summary>
    public GameObject Target { get { return m_target; } set { m_target = value; } }

    [SerializeField, Header("プレイヤー番号")]
    PlayerNumber m_playerNum;
    /// <summary>
    /// プレイヤー番号
    /// </summary>
    public PlayerNumber PlayerNum { get { return m_playerNum; } set { m_playerNum = value; } }
    [SerializeField, Header("Model")]
    GameObject m_model;
    /// <summary>
    /// モデルオブジェ
    /// </summary>
    public GameObject Model { get { return m_model; } private set { } }

    [SerializeField, Header("Playerの状態")]
    PlayerState m_state=PlayerState.Idle;
    /// <summary>
    /// プレイヤー状態
    /// </summary>
    public PlayerState PlayerState { get { return m_state; } set { m_state = value; } }

    [SerializeField, Header("自分の乗っている足場")]
    GameObject m_underBoard=null;
    /// <summary>
    /// 乗っている足場のオブジェ
    /// </summary>
    public GameObject UnderBoard { get { return m_underBoard; } set { m_underBoard = value; } }

    [SerializeField, Header("ゴールしたか？")]
    bool m_isGoal;
    /// <summary>
    /// ゴール状態
    /// </summary>
    public bool IsGoal { get { return m_isGoal; } set { m_isGoal = value; } }
}
