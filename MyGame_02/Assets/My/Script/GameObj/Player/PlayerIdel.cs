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
    /// <summary>
    /// 待機状態処理
    /// </summary>
    public void Idel()
    {
        if (!IsMoveable())
            m_stateChange.ChangeState(PlayerState.End);

        if (!SameTarget())
            m_stateChange.ChangeState(PlayerState.Move);

        LookAtTarget();

    }
    /// <summary>
    /// ずれているポジションをセットしなおす
    /// </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    void RoundHalfUpSetPos(float x,float z) 
    {
        int round_x = Mathf.RoundToInt(x);
        int round_z = Mathf.RoundToInt(z);

        transform.root.position = new Vector3(round_x, transform.position.y, round_z);
    }
    /// <summary>
    /// ターゲット方向を向く
    /// </summary>
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
    /// <summary>
    /// ターゲット位置のチェック（自身のポジションと同位置か）
    /// </summary>
    /// <returns>true= 同じ位置  false= 違う位置 </returns>
    bool SameTarget()
    {
        Vector3 targetPos = m_param.Target.gameObject.transform.position;
        Vector3 Pos = m_parent.position;

        if (Mathf.RoundToInt(targetPos.x) != Mathf.RoundToInt(Pos.x)) return false;
        else if (Mathf.RoundToInt(targetPos.z) != Mathf.RoundToInt(Pos.z)) return false;

        return true;
    }
    /// <summary>
    /// 移動可能か(四方向が壁、床無、床あり（プレイヤーが乗っている）状態でないか)
    /// </summary>
    /// <returns>true=   false=  </returns>
    bool IsMoveable()
    {

        int x = Mathf.RoundToInt(m_parent.position.x);
        int z = Mathf.RoundToInt(m_parent.position.z);


        if (CheckObstacle(x + 1, z) && CheckObstacle(x - 1, z) &&
            CheckObstacle(x, z + 1) && CheckObstacle(x, z - 1))
            return false;
        else return true;
    }
    /// <summary>
    /// 障害物（壁、プレイヤ-）チェック
    /// </summary>
    /// <param name="x">チェックするポジション x（隣のマス）</param>
    /// <param name="z">チェックするポジション z（隣のマス）</param>
    /// <returns>true= 有  false= 無 </returns>
    bool CheckObstacle(int x,int z)
    {
        return (WallCheck(x, z) || PlayerCheck(x, z));
    }
    /// <summary>
    /// 壁チェック
    /// </summary>
    /// <param name="x">チェックするポジション x（隣のマス）</param>
    /// <param name="z">チェックするポジション z（隣のマス）</param>
    /// <returns>true= 有  false= 無 </returns>
    bool WallCheck(int x,int z)
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    /// <summary>
    /// プレイヤーチェック
    /// </summary>
    /// <param name="x">チェックするポジション x（隣のマス）</param>
    /// <param name="z">チェックするポジション z（隣のマス）</param>
    /// <returns>true= 居る  false= 居ない </returns>
    bool PlayerCheck(int x,int z)
    {
        return (FieldDate.Instance.Player(x, z) == Player.In);
    }
}
