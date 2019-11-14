using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardMain : MonoBehaviour
{
    BoardParam m_param;

    PlayerMain m_player;

    StopBoard m_boardStop;
    MoveBoard m_boardMove;
    BoardPreparation m_boardPreparation;

    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
        m_param.Destination = Destination.None;

        m_boardStop = GetComponent<StopBoard>();
        m_boardMove = GetComponent<MoveBoard>();
        m_boardPreparation = GetComponent<BoardPreparation>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_param.Player = other.gameObject;
            //m_param.transform.parent = transform;
        }
    }
    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        m_param.OnThePlayre = true;
    //        if (other.gameObject.GetComponent<Rigidbody>().IsSleeping()) return;
    //        m_player = other.gameObject.GetComponent<PlayerMain>();
    //    }
    //}
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_param.OnThePlayre = false;
            m_param.Player = null;
            //m_param.transform.parent = null;

        }
    }
}
