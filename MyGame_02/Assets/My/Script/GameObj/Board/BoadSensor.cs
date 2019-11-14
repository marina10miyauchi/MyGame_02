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

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Board")
        {
            if (other.gameObject.GetComponent<BoardParam>().Ridable == true)
            {
                m_param.Ridable = true;
            }            
        }
    }
}
