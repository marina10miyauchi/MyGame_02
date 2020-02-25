using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボードに乗っている時の処理
public class PlayerOnBoard : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;

    Transform m_parent;
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        m_stateChange = transform.root.gameObject.GetComponentInChildren<PlayerStateChecker>();
        m_parent = transform.root;
    }
    public void MoveWithBoard()
    {
        m_parent = m_param.UnderBoard.transform;
    }
}
