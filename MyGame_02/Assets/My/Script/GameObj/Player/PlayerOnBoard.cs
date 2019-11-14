using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボードに乗っている時の処理
public class PlayerOnBoard : MonoBehaviour
{
    PlayerParam m_param;
    GameObject m_board = null;
    // Start is called before the first frame update
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
    }
    // Update is called once per frame
    public void MoveWithBoard()
    {
        transform.parent.parent.parent = m_param.UnderBoard.transform;

    }
}
