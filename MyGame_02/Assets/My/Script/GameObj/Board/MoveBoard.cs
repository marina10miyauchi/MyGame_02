using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBoard : MonoBehaviour
{
    BoardParam m_param;


    float m_moveCount;          //移動のためのカウンター
    float m_maxmoveTime = 1f;    //移動にかける時間

    Vector3 m_moveDirection;    //移動方向
    Vector3 m_moveOffset;       //移動中の最終的な位置との差分

    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
    }
    public void Moving()
    {
            switch (m_param.Destination)
            {
                case Destination.Right: Move(1, 0); break;
                case Destination.Left: Move(-1, 0); break;
                case Destination.Forward: Move(0, 1); break;
                case Destination.Back: Move(0, -1); break;
                case Destination.None:
                    break;

            }
    }
    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    void Move(int x, int z)
    {
        //現在の位置
        Vector3 currentPos = transform.position;
        //四捨五入して整数にする
        int currentPos_x = Mathf.RoundToInt(currentPos.x);
        int currentPos_z = Mathf.RoundToInt(currentPos.z);

        //次の移動位置
        Vector3 nextPos = currentPos;
        nextPos.x += x;
        nextPos.z += z;
        int nextPos_x = Mathf.RoundToInt(nextPos.x);
        int nextPos_z = Mathf.RoundToInt(nextPos.z);

        ////移動先が壁か移動床か？
        if (CheckWall(nextPos_x, nextPos_z))
            MoveStop();
        else if (CheckBoard(nextPos_x, nextPos_z))
            MoveStop();
        else
        {
            FieldDate.Instance.ChangeBoard(currentPos_x, currentPos_z, Board.None, nextPos_x, nextPos_z, Board.Exists);
            FieldDate.Instance.ChangePlayer(currentPos_x, currentPos_z, Player.notIn, nextPos_x, nextPos_z, Player.In);

            transform.position = nextPos;
        }
    }
    /// <summary>
    /// 壁チェック
    /// </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>true= 壁有  false= 壁無 </returns>
    bool CheckWall(int x,int z)
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    /// <summary>
    /// ボードチェック
    /// </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>true= ボード有  false= ボード無 </returns>
    bool CheckBoard(int x,int z)
    {
        return (FieldDate.Instance.Boards(x, z) == Board.Exists);
    }
    //スムーズに動かすための処理
    void SmoothMoving()
    {
        m_moveCount += Time.deltaTime;
        if (m_moveCount < m_maxmoveTime)
        {
            float rate = (float)m_moveCount / m_maxmoveTime;
            m_moveOffset = Vector3.Lerp(-m_moveDirection * 1.0f, Vector3.zero, rate);
            //transform.position += m_moveOffset;
        }
        else
        {
            m_moveOffset = Vector3.zero;
        }
    }
    /// <summary>
    /// 移動停止
    /// </summary>
    void MoveStop()
    {
        m_param.Destination = Destination.None;
        m_param.StateChange(BoardState.Stop);
        m_param.Player.GetComponentInChildren<PlayerStateChecker>().ChangeState(PlayerState.End);
    }
    //自身がいる場所にゴールはあるか
    /// <summary>
    /// 自身のいるポジションはゴールか
    /// </summary>
    /// <returns>true= ゴール  false= ゴールでない </returns>
    bool CheckGoal()    
    {
        Vector3 pos = transform.localPosition;
        var fieldData = FieldDate.Instance;
        return (fieldData.Fields(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)) == Field.Goal);
    }
    //現在の場所(x,z)をvector2に入れて返却する
    /// <summary>
    /// 現在の場所(x,z)をvector2に入れて返却する
    /// </summary>
    /// <returns>vector2= ポジション </returns>
    public Vector2 BoardDataValue()
    {
        float x = transform.localPosition.x;
        float z = transform.localPosition.z;
        return new Vector2(x, z);
    }
}
