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
   /// <summary>
   /// ステート切り替え
   /// </summary>
   /// <param name="nextState">切り替える次のプレイヤー状態</param>
    public void ChangeState(PlayerState nextState)
    {
        if (m_param.PlayerState == nextState) return;
        m_param.PlayerState = nextState;
    }
}
