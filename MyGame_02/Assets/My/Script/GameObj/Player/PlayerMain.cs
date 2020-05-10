using System.Collections;
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
    PlayerEnd m_end;
    MouseController m_controller;

    bool m_startSet = false;
    

    
    void Start()
    {
        m_param = GetComponent<PlayerParam>();
       // m_param.Target.transform.position = new Vector3(1.0f, 0.5f, 1.0f);

        m_idel = m_IdelObj.GetComponent<PlayerIdel>();
        m_move = m_MoveObj. GetComponent<PlayerMove>();
        m_end = m_EndObj.GetComponent<PlayerEnd>();
        m_controller = GetComponentInChildren<MouseController>();
    }
    /// <summary>
    ///　状態更新
    /// </summary>
    public void MoveStateUpdate()
    {
        switch (m_param.PlayerState)
        {
            case PlayerState.Start:start(); break;
            case PlayerState.Idle: Idel(); break;
            case PlayerState.Move: Move(); break;
            case PlayerState.WithBoard: break;
            case PlayerState.End: End(); break;
            case PlayerState.Goal: Goal(); break;

        }
    }
    /// <summary>
    /// 初期状態処理
    /// </summary>
    void start()
    {
        Vector3 pos = transform.position;
        m_param.Target.transform.position = new Vector3(pos.x, m_param.Target.transform.position.y, pos.z); 
        transform.parent = null;
        m_param.PlayerState = PlayerState.Idle;

    }
    /// <summary>
    /// 停止状態処理
    /// </summary>
    void Idel()
    {
        m_controller.Mouse();
        m_idel.Idel();
    }
    /// <summary>
    /// 移動状態処理
    /// </summary>
    void Move()
    {
        m_controller.Mouse();
        m_move.Moving();
    }
    /// <summary>
    /// 終了状態処理
    /// </summary>
    void End()
    {
        m_end.End();
    }
    /// <summary>
    /// ゴール時処理
    /// </summary>
    void Goal()
    {
        m_end.Goal();
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
    /// <summary>
    /// 一度だけ行う処理
    /// </summary>
    void OnceDoProcess()
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

