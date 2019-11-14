using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoardState//状態
{
    Stop,           //停止状態
    Preparation,    //移動準備状態
    Moving,         //移動状態
}

public enum Destination//移動先
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
    public BoardState BoardState { get { return m_boardState; } set { m_boardState = value; } }

    [SerializeField,Header("移動方向")]
    Destination m_destination;
    public Destination Destination { get { return m_destination; } set { m_destination = value; } }

    [SerializeField, Header("プレイヤーが上に乗っているか")]
    bool m_onThePlayer;
    public bool OnThePlayre { get { return m_onThePlayer; } set { m_onThePlayer = value; } }

    [SerializeField, Header("")]
    bool m_ridable;
    public bool Ridable { get { return m_ridable; } set { m_ridable = value; } }

    [SerializeField, Header("上に乗っているプレイヤー")]
    GameObject m_player;
    public GameObject Player { get { return m_player; } set { m_player = value; } }

    [SerializeField, Header("")]
    GameObject m_destinationBrock;
    public GameObject DestinationBrock { get { return m_destinationBrock; } }


}
