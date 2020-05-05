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
    //メインで取得したプレイヤーの情報を引数で受け取る
    public void Stop()
    {
        var pos = transform.position;
        if (FieldDate.Instance.Player(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)) == Player.In)
        {
            m_param.Ridable = true;
            m_param.StateChange(BoardState.Preparation);
        }     
    }
}
