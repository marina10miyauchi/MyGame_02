using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//行動処理
public class PlayerMove : MonoBehaviour
{
    GameObject m_myTarget;
    PlayerParam m_param;

    


    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
    }
    public void Moving()
    {
        //TurnForTarget();
        ToTarget();
    }
     void Move(int x,int z)//プレイヤーの移動処理
    {
        Vector3 curpos = transform.root.localPosition;

        //次に移動する場所
        Vector3 nextpos = 
            new Vector3(curpos.x + x, curpos.y, curpos.z + z);

        if (CheckWall(nextpos.x, nextpos.z)) return;      //次の移動先は壁か
        if (!CheckBoard(nextpos.x, nextpos.z)) return;   //次の移動先に移動床はあるか
        else
        {
            FieldDate.Instance.ChangePlayer(curpos.x, curpos.z, Player.notIn, nextpos.x, nextpos.z, Player.In);
            transform.root.position = nextpos;   //自身のポジションを移動先に移動
        }
    }
    bool CheckWall(float x,float z)//指定した場所に壁があるかのチェック
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    bool CheckBoard(float x,float z)//指定した場所に床があるかのチェック
    {
        return (FieldDate.Instance.Boards(x, z) == Board.Exists);
    }
    void ToTarget()     //ターゲットの方へ
    {
        Vector3 target = m_param.Target.transform.localPosition;
        int target_x = Mathf.RoundToInt(target.x);
        int target_z = Mathf.RoundToInt(target.z);
        Vector3 myPos = transform.root.localPosition;
        int my_x = Mathf.RoundToInt(myPos.x);
        int my_z =  Mathf.RoundToInt(myPos.z);

        //ターゲットのポジションと自分のポジションのX,zが一緒なら　returu
        if (target_x == my_x && target_z == my_z) return;
        //ターゲットのxと自信のxは同じか
        if (target_x != my_x)
        {
            if (TargetIsRight(target_x,my_x))Move(1, 0);
            else Move(-1, 0);
        }
        if (target_z != my_z)
        {
            if (TargetIsForward(target_z,my_z))Move(0, 1);
            else Move(0, -1);
        }
    }
    bool TargetIsRight(int t_x,int m_x)       //右に移動するか
    {
        return (t_x > m_x);
    }
    bool TargetIsForward(int t_z, int m_z)     //前にいどうするか
    {
        return (t_z > m_z);
    }
    void TurnForTarget()//ターゲットの方向に回転する
    {
        Quaternion targetRotation = Quaternion.LookRotation(m_param.Target.transform.position, -transform.parent.parent.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
