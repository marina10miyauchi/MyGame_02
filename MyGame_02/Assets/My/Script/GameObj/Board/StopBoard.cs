using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoard : MonoBehaviour
{
    //メインのボードスクリプト
    BoardParam m_param;
    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
    }
    
    public void Stop()//メインで取得したプレイヤーの情報を引数で受け取る
    {
        //パラメータの中のUnderPlayerがnullならプレイヤーは居ない
        //m_param.DestinationBrock.SetActive(false);
        if (m_param.Player != null)//プレイヤーが上に乗っていれば
        {
            //m_param.OnThePlayre = true;
            m_param.Ridable = true;
            m_param.StateChange(BoardState.Preparation);
            m_param.DestinationBrock.SetActive(true);
        }     
    }
}
