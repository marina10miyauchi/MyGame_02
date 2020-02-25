using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボードに乗っている時の処理
public class PlayerOnBoard : MonoBehaviour
{
    PlayerParam m_param;
    GameObject m_board = null;
    PlayerStateChecker m_stateChange;

    Transform m_parent;
    // Start is called before the first frame update
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        m_stateChange = transform.root.gameObject.GetComponentInChildren<PlayerStateChecker>();
        m_parent = transform.root;
    }
    // Update is called once per frame
    public void MoveWithBoard()
    {
        m_parent = m_param.UnderBoard.transform;
    }
}
