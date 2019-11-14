﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMain : MonoBehaviour
{
    PlayerParam m_param;

    //GameObject m_board = null;
    BoardMain m_boardmain;
    

    Vector3 m_prevPos;          //停止状態の自身のポジション

    [SerializeField]
    GameObject m_IdelObj;
    [SerializeField]
    GameObject m_MoveObj;
    [SerializeField]
    GameObject m_MovingObj;
    [SerializeField]
    GameObject m_EndObj;

    PlayerIdel m_idel;
    PlayerMove m_move;
    PlayerOnBoard m_onboard;
    PlayerEnd m_end;

    bool m_startSet = false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<PlayerParam>();
        m_param.Target = GameObject.FindGameObjectWithTag("Target");
        m_param.Target.transform.position = new Vector3(1.0f, 0.5f, 1.0f);

        m_idel = m_IdelObj.GetComponent<PlayerIdel>();
        m_move = m_MoveObj. GetComponent<PlayerMove>();
        m_onboard = m_MovingObj.GetComponent<PlayerOnBoard>();
        m_end = m_EndObj.GetComponent<PlayerEnd>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveStateUpdate();

    }
    void MoveStateUpdate()//移動状態のアップデート
    {
        switch (m_param.PlayerState)
        {
            case PlayerState.Start:start(); break;
            case PlayerState.Idle: Idel(); break;
            case PlayerState.Move: Move(); break;
            case PlayerState.WithBoard: withBoardMove(); break;
            case PlayerState.End: End(); break;
            
        }
    }
    void start()
    {
        m_param.Target.transform.position = m_param.UnderBoard.transform.localPosition;
        transform.parent = null;
        m_param.IsMyTurn = true;

    }
    void Idel()
    {
        m_idel.Idel();
    }
    void Move()
    {
        m_move.Moving();
    }
    void withBoardMove()//ボードを動かす(一緒に移動)
    {
        m_onboard.MoveWithBoard();
    }
    void End()
    {
        m_end.End();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Board")
        {
            OnceDoProcess();
            m_param.UnderBoard = other.gameObject; 
            m_boardmain = m_param.UnderBoard.GetComponent<BoardMain>();
            Vector3 boardPos = other.gameObject.transform.position;
            transform.position = new Vector3(boardPos.x, transform.position.y, boardPos.z);
            
        }
    }
    void OnceDoProcess()//一度だけ行う処理
    {
        if (!m_startSet)//スタート時のプレイヤーの初期設定をしたか
        {
            //RigitBodyの機能を変更　（物理エンジンによってポジションが微妙にずれてしまうのを防ぐため）
            var rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            m_startSet = true;  //設定がおわった
        }
    }
}
