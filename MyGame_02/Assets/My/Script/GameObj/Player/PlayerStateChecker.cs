using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイヤーの状態をチェックしステートを切り替える
public class PlayerStateChecker : MonoBehaviour
{
    PlayerParam m_param;

    Animator m_anim;

    Vector3 position;


    void Start()
    {
        m_param = GetComponentInParent<PlayerParam>();
        m_anim = GetComponentInParent<Animator>();
    }
   
    public void ChangeState(PlayerState nextState)
    {
        if (m_param.PlayerState == nextState) return;
        m_param.PlayerState = nextState;
    }
    void IdelCheck()
    {
        //ターゲット位置が自分とずれていたらムーブへ　移動フラグが立っていたら床と一緒に移動
        if (!SameTarget() /*&& SameRotateTarget()*/)
        {
            //m_anim.SetTrigger("Move");
            //m_param.PlayerState = PlayerState.Move;
        }
        else if (UnderBoardMoving())
        {
            //m_anim.SetTrigger("IsBoard");
           // m_param.PlayerState = PlayerState.WithBoard;
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
    bool SameRotateTarget()
    {
        Vector3 target = m_param.Target.transform.position;
        target.y = m_param.Model.transform.position.y;
        var diff = target - m_param.Model.transform.position;
        var axis = Vector3.Cross(m_param.Model.transform.forward, diff);
        //
        var angle = Vector3.Angle(m_param.Model.transform.forward, diff) * (axis.y < 0 ? -1 : 1);

        return (angle < 5f);
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
