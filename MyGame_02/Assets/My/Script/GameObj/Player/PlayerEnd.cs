using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
    PlayerParam m_param;

    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
    }
    public void End()
    {
        EndMove();
    }
    void EndMove()//行動終了
    {
        //乗っているボードのデータを取得　配列を直す
        var boarData = m_param.UnderBoard.GetComponent<MoveBoard>().BoardDataValue();
        var prevPos = m_param.Target.transform.localPosition;
        FieldDate.Instance.Player(Mathf.RoundToInt(prevPos.x), Mathf.RoundToInt(prevPos.z), Player.notIn);
        FieldDate.Instance.Player(Mathf.RoundToInt(boarData.x), Mathf.RoundToInt(boarData.y), Player.In);
        
        //もしゴールしたのであれば
        if(m_param.IsGoal)
            //テスト

        //ステートを写すか、

        //移動が終わったので親を無くす
        //移動フラグも元に戻す
        m_param.IsMyTurn = false;
    }

    void GoalAction()
    {
        //アニメーションをする
        //アニメーションが終了したら画面遷移
        //画面遷移で暗くなったらシーン切り替え
        
    }
}
