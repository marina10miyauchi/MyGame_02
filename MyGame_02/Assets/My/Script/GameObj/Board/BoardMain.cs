using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardMain : MonoBehaviour
{
    BoardParam m_param;

    StopBoard m_boardStop;
    MoveBoard m_boardMove;
    BoardPreparation m_boardPreparation;

    TurnManager m_turn;

    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
        m_param.Destination = Destination.None;

        m_boardStop = GetComponent<StopBoard>();
        m_boardMove = GetComponent<MoveBoard>();
        m_boardPreparation = GetComponent<BoardPreparation>();
        m_turn = FindObjectOfType<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //上にプレイヤーが乗っていなければ終了
        if (m_param.Player == null) return;
        //上に乗っているプレイヤーのターン出なければ終了
        if (m_turn.TurnPlayer().name!=m_param.Player.name) return;
        StateUpdate();
    }
    void StateUpdate()
    {
        switch (m_param.BoardState)
        {
            case BoardState.Stop:StopBoard();break;
            case BoardState.Preparation:MovingPreparation();break;
            case BoardState.Moving:MovingBoard();break;
        }
    }
    void StopBoard()//停止状態の処理
    {
        m_boardStop.Stop();
    }
    void MovingPreparation()//移動準備状態の処理
    {
        m_boardPreparation.Preparation();

    }
    void MovingBoard()//移動状態の処理
    {
        m_boardMove.Moving();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //m_param.OnThePlayre = false;
            m_param.Player = null;
            m_param.StateChange(BoardState.Stop);
            m_param.DestinationBrock.SetActive(false);

            //m_param.transform.parent = null;

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
