using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        //m_parent = m_param.UnderBoard.transform;
        //Vector3 curpos = m_parent.position;
        //int cur_x = Mathf.RoundToInt(curpos.x);
        //int cur_z = Mathf.RoundToInt(curpos.z);


        ////次に移動する場所
        //Vector3 nextpos =
        //    new Vector3(curpos.x + x, curpos.y, curpos.z + z);
        //int next_x = Mathf.RoundToInt(nextpos.x);
        //int next_z = Mathf.RoundToInt(nextpos.z);
        //FieldDate.Instance.ChangePlayer(cur_x, cur_z, Player.notIn, next_x, next_z, Player.In);

    }
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
