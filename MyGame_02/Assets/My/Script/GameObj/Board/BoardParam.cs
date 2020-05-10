using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状態
/// </summary>
public enum BoardState
{
    /// <summary>
    /// 停止状態
    /// </summary>
    Stop,
    /// <summary>
    /// 移動準備状態
    /// </summary>
    Preparation,    
    /// <summary>
    /// 移動状態
    /// </summary>
    Moving,         
}

/// <summary>
/// 移動方向
/// </summary>
public enum Destination
{
    Right,
    Left,
    Forward,
    Back,
    None
}

public class BoardParam : MonoBehaviour
{
    [SerializeField,Header("床の状態")]
    BoardState m_boardState;
    /// <summary>
    /// ボード状態
    /// </summary>
    public BoardState BoardState { get { return m_boardState; } set { m_boardState = value; } }

    [SerializeField,Header("移動方向")]
    Destination m_destination;
    /// <summary>
    /// 移動方向
    /// </summary>
    public Destination Destination { get { return m_destination; } set { m_destination = value; } }

    [SerializeField, Header("移動できるボードか")]
    bool m_ridable;
    /// <summary>
    /// 移動できるボードか
    /// </summary>
    public bool Ridable { get { return m_ridable; } set { m_ridable = value; } }

    [SerializeField, Header("上に乗っているプレイヤー")]
    GameObject m_player;
    /// <summary>
    /// 上に乗っているプレイヤー（いない場合はNull）
    /// </summary>
    public GameObject Player { get { return m_player; } set { m_player = value; } }

    [SerializeField, Header("移動方向オブジェ")]
    GameObject m_destinationBrock;
    /// <summary>
    /// 移動方向オブジェクト
    /// </summary>
    public GameObject DestinationBrock { get { return m_destinationBrock; } }

    /// <summary>
    /// 状態切り替え
    /// </summary>
    /// <param name="nextState">切り替える状態</param>
    public void StateChange(BoardState nextState)
    {
        if (m_boardState == nextState) return;
        m_boardState = nextState;
    }
}
