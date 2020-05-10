using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    [SerializeField, Header("移動先のターゲットとなるオブジェクト")]
    GameObject m_targetObj = null;

    [SerializeField, Header("アウトラインの太さ")]
    float m_outlineWidth = 0.05f;
    [SerializeField, Header("カラー")]
    Color m_changeColor;

    PlayerParam m_param;

    List<Renderer> m_boards = new List<Renderer>();

    static readonly int MainColor = Shader.PropertyToID("_MainColor");
    static readonly int OutLineWidth = Shader.PropertyToID("_Width");

    void Start()
    {
        m_param = transform.parent.gameObject.GetComponent<PlayerParam>();
        m_targetObj = m_param.Target;
        GetBoaed();
    }
    /// <summary>
    /// マウス処理
    /// </summary>
    public void Mouse()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        //カメラ内のマウスポジションからRayを飛ばす
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 nextPos = Vector3.zero;

        //マウスクリックした場所から飛ばしたRayの先にオブジェクトがあるか
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            var hitTag = hit.collider.tag;
            //当たったものについているタグが"Board"なら
            if (hitTag=="Board")
            {
                //Shader.SetGlobalColor(MainColor, new Color(1,0,0,1));
                if (hit.collider.gameObject.GetComponent<BoardParam>().Ridable == true)
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_MainColor", new Color(1, 0, 0, 1));
                    if (Input.GetMouseButtonDown(0))
                    {
                        nextPos = hit.collider.gameObject.transform.position;
                        //移動先のオブジェクトのポジションを当たったものに設定
                        m_targetObj.transform.position = nextPos;
                    }
                }
            }
        }
        else
        {
            foreach(Renderer board in m_boards)
            {
                board.material.SetColor("_MainColor", new Color(1, 1, 1, 1));
            }
        }

    }
    /// <summary>
    /// フィールドのボードを全て取得
    /// </summary>
    void GetBoaed()
    {
        GameObject[] boards = GameObject.FindGameObjectsWithTag("Board");
        foreach(GameObject board in boards)
        {
            var tem = board.GetComponent<Renderer>();
            m_boards.Add(tem);
        }
    }
}
