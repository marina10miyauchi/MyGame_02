using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//待機処理
public class PlayerIdel : MonoBehaviour
{
    PlayerParam m_param;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        position = position = transform.parent.parent.position;

    }

    // Update is called once per frame
    public void Idel()
    {
        RoundHalfUpSetPos(transform.position.x,transform.position.z);
    }
    void RoundHalfUpSetPos(float x,float z) //ずれているポジションを四捨五入してセットしなおす
    {
        int round_x = Mathf.RoundToInt(x);
        int round_z = Mathf.RoundToInt(z);

        transform.position = new Vector3(round_x, transform.position.y, round_z);

    }
    bool SameTarget()//ターゲットの位置が自身と同じか
    {
        Vector3 targetPos = m_param.Target.gameObject.transform.position;
        Vector3 Pos = transform.parent.parent.position;

        if (Mathf.RoundToInt(targetPos.x) != Mathf.RoundToInt(Pos.x)) return false;
        else if (Mathf.RoundToInt(targetPos.z) != Mathf.RoundToInt(Pos.z)) return false;

        return true;
    }

}
