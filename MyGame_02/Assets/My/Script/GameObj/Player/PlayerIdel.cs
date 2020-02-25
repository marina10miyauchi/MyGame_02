using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//待機処理
public class PlayerIdel : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        position = transform.parent.parent.position;
        m_stateChange = transform.parent.GetComponent<PlayerStateChecker>();
    }

    // Update is called once per frame
    public void Idel()
    {
        if (!SameTarget())
            m_stateChange.ChangeState(PlayerState.Move);

        //RoundHalfUpSetPos(m_param.Target.transform.position.x, m_param.Target.transform.position.z);
        //LookAtTarget();
    }
    void RoundHalfUpSetPos(float x,float z) //ずれているポジションを四捨五入してセットしなおす
    {
        int round_x = Mathf.RoundToInt(x);
        int round_z = Mathf.RoundToInt(z);

        transform.root.position = new Vector3(round_x, transform.position.y, round_z);
    }
    //ターゲット方向を向く
    void LookAtTarget()
    {
       

        Vector3 target = m_param.Target.transform.position;
        if (m_param.Model.transform.position.y != m_param.Target.transform.position.y)
        {
            target.y = m_param.Model.transform.position.y;
        }
        Quaternion targetRotatio = Quaternion.LookRotation(target-transform.parent.position);

        m_param.Model.transform.rotation = Quaternion.Slerp(m_param.Model.transform.rotation, targetRotatio, Time.deltaTime);

    }

    //ターゲット方向を取得
    float GetTargetRadian()
    {
        var target = m_param.Target.transform.position;
        Vector3 pos = m_param.Model.transform.localPosition;
        float radian = Mathf.Atan2(target.z - pos.z, target.x - pos.x);
        return radian;
    }
    bool SameTarget()//ターゲットの位置が自身と同じか
    {
        Vector3 targetPos = m_param.Target.gameObject.transform.position;
        Vector3 Pos = transform.parent.parent.position;

        if (Mathf.RoundToInt(targetPos.x) != Mathf.RoundToInt(Pos.x)) return false;
        else if (Mathf.RoundToInt(targetPos.z) != Mathf.RoundToInt(Pos.z)) return false;

        return true;
    }
    bool TargetIsRight(int t_x, int m_x)       //右に移動するか
    {
        return (t_x > m_x);
    }
    bool TargetIsForward(int t_z, int m_z)     //前にいどうするか
    {
        return (t_z > m_z);
    }

}
