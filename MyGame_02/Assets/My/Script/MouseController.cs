using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    [SerializeField, Header("移動先のターゲットとなるオブジェクト")]
    GameObject m_targetObj = null;

    // Update is called once per frame
    void Update()
    {
        Mouse();
    }
    void Mouse()
    {
        if (Input.GetMouseButtonDown(0))//マウスのクリック検知
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            //カメラ内のマウスポジションからRayを飛ばす
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 nextPos = Vector3.zero;

            //マウスクリックした場所から飛ばしたRayの先にオブジェクトがあるか
            if (Physics.Raycast(ray.origin,ray.direction,out hit, Mathf.Infinity))
            {
                //当たったものについているタグが"Board"なら
                if (hit.collider.gameObject.tag == "Board")
                {
                    if (hit.collider.gameObject.GetComponent<BoardParam>().Ridable == true)
                    {
                        nextPos = hit.collider.gameObject.transform.position;
                        //移動先のオブジェクトのポジションを当たったものに設定
                        m_targetObj.transform.position = nextPos;

                    }
                }
            }

        }
    }
}
