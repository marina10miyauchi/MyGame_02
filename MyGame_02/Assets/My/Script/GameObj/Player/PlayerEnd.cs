using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;
    TurnManager m_turn;
    Transform m_parent;//プレイヤーのトランスフォーム

    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        m_turn = FindObjectOfType<TurnManager>();
        m_stateChange = transform.parent.gameObject.GetComponent<PlayerStateChecker>();
        m_parent = transform.root;
    }
    public void End()//行動終了
    {
        //乗っているボードのデータを取得　配列を直す
        var boarData = m_param.UnderBoard.GetComponent<MoveBoard>().BoardDataValue();
        var prevPos = m_param.Target.transform.localPosition;
        FieldDate.Instance.Player(Mathf.RoundToInt(prevPos.x), Mathf.RoundToInt(prevPos.z), Player.notIn);
        FieldDate.Instance.Player(Mathf.RoundToInt(boarData.x), Mathf.RoundToInt(boarData.y), Player.In);

        //行動回数のカウント
        GameData.Instance.MoveCount();

        //もしゴールしたのであれば
        if (m_param.IsGoal)
            Debug.Log("goal");
        //テスト

        //ステートを写すか、

        //移動が終わったので親を無くす
        //移動フラグも元に戻す
        // m_param.IsMyTurn = false;
        TargetPosSet();
        m_parent.parent = null;
        m_stateChange.ChangeState(PlayerState.Idle);
        m_turn.NextTurn();
        
    }

    void GoalAction()
    {
        //アニメーションをする
        //アニメーションが終了したら画面遷移
        //画面遷移で暗くなったらシーン切り替え
        
    }
    void TargetPosSet()
    {
        Vector3 pos = m_param.Target.transform.position;
        pos.x = Mathf.RoundToInt(m_parent.position.x);
        pos.z = Mathf.RoundToInt(m_parent.position.z);
        m_param.Target.transform.position = pos;

    }
}
