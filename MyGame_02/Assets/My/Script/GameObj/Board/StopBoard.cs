using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoard : MonoBehaviour
{
    //メインのボードスクリプト
    BoardParam m_param;

    TurnManager m_turnManager;
    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
        m_turnManager = GameObject.FindObjectOfType<TurnManager>();
    }
    /// <summary>
    /// 停止状態時の処理
    /// </summary>
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
