using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoadSensor : MonoBehaviour
{
    GameObject m_parent;
    BoardParam m_param;
    // Start is called before the first frame update
    void Start()
    {
        m_parent = transform.parent.gameObject;
        m_param = m_parent.GetComponent<BoardParam>();
    }

    void OnTriggerStay(Collider other)
    {
        //隣接するボードが乗れる状態かどうかのチェック
        //乗れるのなら自身も乗れる状態
        if (other.gameObject.tag == "Board")
        {
            if (other.gameObject.GetComponent<BoardParam>().Ridable == true)
            {
                m_param.Ridable = true;
            }            
        }
    }
}
