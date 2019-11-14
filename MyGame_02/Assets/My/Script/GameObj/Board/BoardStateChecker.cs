using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateChecker : MonoBehaviour
{
    BoardParam m_param;
    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
    }

    // Update is called once per frame
    void Update()
    {
        //StateCheck();
    }  
    void StateCheck()//ステートの状態チェック
    {
        //if (m_board.m_onThePlayer == true)//プレイヤーが上に乗っていたら
        //{
        //    m_board.m_state = BoardState.Preparation;//準備状態に移行
        //    //その状態で移動方向の指定がNoneでなかったら（移動方向を指定されたら）
        //    if (m_board.m_destination != Destination.None)
        //    {
        //        m_board.m_state = BoardState.Moving;
        //    }
        //}
        //else//それ以外は
        //{
        //    m_board.m_state = BoardState.Stop;
        //}

    }
}
