//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class MovingBoard : MonoBehaviour
//{
//    //プレイヤーが上に乗っているか
//    [SerializeField, Header("Playerが上にのっているか")]
//    public bool m_onPlayer = true;

//    [SerializeField]
//    public bool m_ridable_player = false;

//    public bool m_IsMove = false;   //移動フラグ

//    public Destination m_destination;       //移動方向の指定
//    BoardState m_state = BoardState.Stop;   //現在の自身（床）の状態
//    float m_moveCount;          //移動のためのカウンター
//    float m_maxmoveTime = 0f;    //移動にかける時間

//    Vector3 m_moveDirection;    //移動方向
//    Vector3 m_moveOffset;       //移動中の最終的な位置との差分

//    // Start is called before the first frame update
//    void Start()
//    {
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (m_onPlayer) m_ridable_player = true;
//        //プレイヤーが乗っていてかつ移動フラグが立っていたら
//        if (m_onPlayer&& m_IsMove)
//        {
//            if(m_destination == Destination.Right)   Move(1, 0);
//            if(m_destination == Destination.Left)    Move(-1, 0);
//            if(m_destination==Destination.Forward)   Move(0, 1);
//            if(m_destination==Destination.Back)      Move(0, -1);
//        }
//        //停止状態
//        if (m_state == BoardState.Stop)
//        {
//            if (m_onPlayer)
//            {
//            }
//            m_destination = Destination.None;
//            m_IsMove = false;

//            //CheckRadePlayer();
//        }
//        else if (m_state == BoardState.Moving)
//        {
//            //MoveState();
//        }

//    }
//    /// <summary>
//    /// 移動
//    /// </summary>
//    /// <param name="x">横の移動量</param>
//    /// <param name="z">奥の移動量</param>
//    void Move(int x, int z)
//    {
//        Vector3 currentPos = transform.position;
//        Vector3 nextPos = transform.position + new Vector3(x, 0, z);
//        ////移動先が壁か移動床か？
//        if (ObstacleCheck(x, z) == true)
//        {
//            //m_state = BoardState.stop;
//            return;
//        }
//        else
//        {
//            FieldDate.Instance.Boards((int)currentPos.x, (int)currentPos.z, Board.None);
//            FieldDate.Instance.Boards((int)nextPos.x, (int)nextPos.z, Board.Moving);

//            m_state = BoardState.Moving;

//            transform.position = nextPos;
//        }
//        m_moveCount = 0;
//        m_moveDirection = new Vector3(x, 0, z);
//    }
//    void MoveState()//stateがmovingの時の処理
//    {
//        m_moveCount += Time.deltaTime;
//        Debug.Log("count"+m_moveCount);

//        if (m_moveCount < m_maxmoveTime)
//        {
//            float rate = (float)m_moveCount / m_maxmoveTime;
//            m_moveOffset = Vector3.Lerp(-m_moveDirection * 1.0f, Vector3.zero, rate);
//            transform.position += m_moveOffset;
//        }
//    }
//    bool ObstacleCheck(int x,int z)//障害物チェック 壁か移動床があるか？ （true=あり　false=無し）
//    {
//        Vector3 currentPos = transform.position;

//        if (FieldDate.Instance.Fields((int)currentPos.x + x, (int)currentPos.z + z) == Field.Wall)
//            return true;
//        if(FieldDate.Instance.Boards((int)currentPos.x + x, (int)currentPos.z + z) == Board.Exists)
//            return true;
        

//            return false;
//    }
//    public Vector2 BoardDataValue()//
//    {
//        float x = transform.position.x;
//        float z = transform.position.z;
//        return new Vector2(x, z);
//    }
//}
