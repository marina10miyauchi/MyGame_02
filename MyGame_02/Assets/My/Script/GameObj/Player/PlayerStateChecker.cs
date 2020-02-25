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
}
