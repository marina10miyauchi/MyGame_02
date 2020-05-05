﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

//行動処理
public class PlayerMove : MonoBehaviour
{
    GameObject m_myTarget;
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;

    Transform m_parent;
    bool m_right;
    bool m_forward;

    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        m_stateChange = transform.parent.GetComponent<PlayerStateChecker>();
        m_parent = transform.root;
    }
    //プレイヤーの移動処理
    void Move(int x,int z)
    {
        Vector3 curpos = m_parent.position;
        int cur_x = Mathf.RoundToInt(curpos.x);
        int cur_z = Mathf.RoundToInt(curpos.z);


        //次に移動する場所
        Vector3 nextpos = 
            new Vector3(curpos.x + x, curpos.y, curpos.z + z);
        int next_x = Mathf.RoundToInt(nextpos.x);
        int next_z = Mathf.RoundToInt(nextpos.z);


        if (CheckWall(next_x, next_z)) return;      //次の移動先は壁か
        if (!CheckBoard(next_x, next_z)) return;    //次の移動先に移動床はあるか
        if (PlayerCheck(next_x, next_z)) return;    //次の移動先にプレイヤーがいるか
        else
        {
            FieldDate.Instance.ChangePlayer(cur_x, cur_z, Player.notIn, next_x, next_z, Player.In);
            //TODO:　Tweenに頼りすぎプログラムなので書き直したい
            if (x != 0)
            {
                m_parent.DOMoveX(next_x, 1);
            }
            if (z != 0)
            {
                m_parent.DOMoveZ(next_z, 1);
            }
        }
    }

    //指定した場所に壁があるかのチェック
    bool CheckWall(int x,int z)
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    //指定した場所に床があるかのチェック
    bool CheckBoard(int x,int z)
    {
        return (FieldDate.Instance.Boards(x, z) == Board.Exists);
    }
    //指定した場所にプレイヤーがいるか
    bool PlayerCheck(int x, int z)
    {
        return (FieldDate.Instance.Player(x, z) == Player.In);
    }
    //ターゲットの方へ
    public void Moving()     
    {
        Vector3 target = m_param.Target.transform.position;
        int target_x = Mathf.RoundToInt(target.x);
        int target_z = Mathf.RoundToInt(target.z);
        Vector3 myPos = m_parent.position;
        int my_x = Mathf.RoundToInt(myPos.x);
        int my_z =  Mathf.RoundToInt(myPos.z);

        //ターゲットのポジションと自分のポジションのX,zが一緒なら　returu
        if (target_x == my_x && target_z == my_z)
        {
            m_stateChange.ChangeState(PlayerState.Idle);
            return;
        }
        //ターゲットのxと自信のxは同じか
        if (target_x != my_x)
        {
            if (TargetIsRight(target_x,my_x))Move(1, 0);
            else Move(-1, 0);
        }
        if (target_z != my_z)
        {
            if (TargetIsForward(target_z,my_z))Move(0, 1);
            else Move(0, -1);
        }

    }
    //右に移動するか
    bool TargetIsRight(int t_x,int m_x)       
    {
        return (t_x > m_x);
    }
    //前にいどうするか
    bool TargetIsForward(int t_z, int m_z)     
    {
        return (t_z > m_z);
    }
    void MoveStop()
    {
        m_param.PlayerState = PlayerState.Idle;
    }
}
