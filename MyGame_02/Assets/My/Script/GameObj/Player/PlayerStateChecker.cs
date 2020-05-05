using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイヤーの状態をチェックしステートを切り替える
public class PlayerStateChecker : MonoBehaviour
{
    PlayerParam m_param;

    void Start()
    {
        m_param = GetComponentInParent<PlayerParam>();
    }
   //ステート切り替え　nextState=切り替えステート
    public void ChangeState(PlayerState nextState)
    {
        if (m_param.PlayerState == nextState) return;
        m_param.PlayerState = nextState;
    }
}
