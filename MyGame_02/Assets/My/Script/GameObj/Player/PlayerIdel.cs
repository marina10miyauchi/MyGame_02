using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//待機処理
public class PlayerIdel : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;
    Vector3 position;

    Transform m_parent;
    Transform m_goal;

    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        position = transform.parent.parent.position;
        m_stateChange = transform.parent.GetComponent<PlayerStateChecker>();
        m_goal = GameObject.Find("Goal").transform;
        m_parent = transform.root;
    }

    public void Idel()
    {
        if (!IsMoveable())
            m_stateChange.ChangeState(PlayerState.End);

        if (!SameTarget())
            m_stateChange.ChangeState(PlayerState.Move);

        LookAtTarget();

    }
    //ずれているポジションを四捨五入してセットしなおす
    void RoundHalfUpSetPos(float x,float z) 
    {
        int round_x = Mathf.RoundToInt(x);
        int round_z = Mathf.RoundToInt(z);

        transform.root.position = new Vector3(round_x, transform.position.y, round_z);
    }
    //ターゲット方向を向く
    void LookAtTarget()
    {
        Vector3 target = m_goal.transform.position;
        if (m_param.Model.transform.position.y != m_param.Target.transform.position.y)
        {
            target.y = m_param.Model.transform.position.y;
        }
        Quaternion targetRotatio = Quaternion.LookRotation(target-transform.parent.position);

        m_param.Model.transform.rotation = Quaternion.Slerp(m_param.Model.transform.rotation, targetRotatio, Time.deltaTime);
    }
    //ターゲットの位置が自身と同じか
    bool SameTarget()
    {
        Vector3 targetPos = m_param.Target.gameObject.transform.position;
        Vector3 Pos = m_parent.position;

        if (Mathf.RoundToInt(targetPos.x) != Mathf.RoundToInt(Pos.x)) return false;
        else if (Mathf.RoundToInt(targetPos.z) != Mathf.RoundToInt(Pos.z)) return false;

        return true;
    }
    //移動可能か　(四方向が壁、床無、床あり（プレイヤーが乗っている）)
    bool IsMoveable()
    {

        int x = Mathf.RoundToInt(m_parent.position.x);
        int z = Mathf.RoundToInt(m_parent.position.z);


        if (CheckObstacle(x + 1, z) && CheckObstacle(x - 1, z) &&
            CheckObstacle(x, z + 1) && CheckObstacle(x, z - 1))
            return false;
        else return true;
    }
    //障害物（壁、プレイヤ-）チェック　あれば　true
    bool CheckObstacle(int x,int z)
    {
        return (WallCheck(x, z) || PlayerCheck(x, z));
    }
    //壁があったらtrue
    bool WallCheck(int x,int z)
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    //隣のマスにプレイヤーが居たらtrue
    bool PlayerCheck(int x,int z)
    {
        return (FieldDate.Instance.Player(x, z) == Player.In);
    }
}
