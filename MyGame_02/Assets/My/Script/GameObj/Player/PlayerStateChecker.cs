using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイヤーの状態をチェックしステートを切り替える
public class PlayerStateChecker : MonoBehaviour
{
    PlayerParam m_param;

    Vector3 position;

    void Start()
    {
        m_param = GetComponentInParent<PlayerParam>();
    }
    void Update()
    {
        switch (m_param.PlayerState)
        {
            case PlayerState.Idle:
                //ターゲット位置が自分とずれていたらムーブへ　移動フラグが立っていたら床と一緒に移動
                if (!SameTarget()) m_param.PlayerState = PlayerState.Move;
                else if (UnderBoardMoving()) m_param.PlayerState = PlayerState.WithBoard;
                break;
            case PlayerState.Move:
                //ターゲットの場所に移動したか
                if (SameTarget()) m_param.PlayerState = PlayerState.Idle;
                break;
            case PlayerState.WithBoard:
                //ボードの移動がしゅうりょうしたら
                if (!UnderBoardMoving()) m_param.PlayerState = PlayerState.End;
                break;
            case PlayerState.End:
                //自分のターンならステートをStartへ
                if (!m_param.IsMyTurn) m_param.PlayerState = PlayerState.Start;
                break;
            case PlayerState.Start:
                //自分のターンでかつ行動してよいのなら（行動してよいフラグはまだない）
                if (m_param.IsMyTurn) m_param.PlayerState = PlayerState.Idle;
                break;


        }
    }
    bool CheckIdelState()//待機状態にするかのチェック
    {
        if (SameTarget()) return true;
        //if (!UnderBoardMoving()) return true;
        return false;
    }
    bool CheckMoveState()
    {
        if (!SameTarget()) return true;

        return false;
    }
    bool CheckMovingWithBoard()
    {
        if (UnderBoardMoving()) return true;
        return false;
    }

    bool SameTarget()//ターゲットとプレイヤーが同じ位置にいるか
    {
        //軸方向に動けるか
        bool move_x = false;
        bool move_z = false;

        Vector3 targetPos = m_param.Target.transform.position;
        position = transform.parent.position;

        //x座標が等しくない->x座標に動ける
        if (Mathf.RoundToInt(targetPos.x) != Mathf.RoundToInt(position.x)) move_x = true;
        //z座標が等しくない->z座標に動ける
        else if (Mathf.RoundToInt(targetPos.z) != Mathf.RoundToInt(position.z)) move_z = true;

        //どちらかに動けるか
        if (move_x || move_z) return false;
        //動けないなら
        else return true;
    }
    bool UnderBoardMoving()
    {
        if (m_param.UnderBoard != null)
            if (m_param.IsMoving) return true;
        return false;
    }
    bool UnderBoardMoveStop()//移動足場が移動を終了したか
    {
        return false;
    }
}
