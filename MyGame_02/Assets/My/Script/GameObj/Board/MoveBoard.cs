using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBoard : MonoBehaviour
{
    BoardParam m_param;

    bool m_moving = false;

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
            case Destination.Right:     Move(1, 0);break;
            case Destination.Left:      Move(-1, 0);break;
            case Destination.Forward:   Move(0, 1);break;
            case Destination.Back:      Move(0, -1);break;
            case Destination.None:
                m_param.BoardState = BoardState.Stop;
                break;

        }
        //if (m_moving)
        //{
        //    SmoothMoving();

        //}
    }
    void Move(int x, int z)//移動処理
    {
        //現在の位置
        Vector3 currentPos = transform.localPosition;
        //四捨五入して整数にする
        int currentPos_x = Mathf.RoundToInt(currentPos.x);
        int currentPos_z = Mathf.RoundToInt(currentPos.z);

        //次の移動位置
        Vector3 nextPos = transform.localPosition + new Vector3(x, 0, z);
        int nextPos_x = Mathf.RoundToInt(nextPos.x);
        int nextPos_z = Mathf.RoundToInt(nextPos.z);

        ////移動先が壁か移動床か？
        if (CheckWall(nextPos_x, nextPos_z)) MoveStop();
        else if (CheckBoard(nextPos_x, nextPos_z)) MoveStop();
        else
        {
            FieldDate.Instance.ChangeBoard(currentPos_x, currentPos_z, Board.None, nextPos_x, nextPos_z, Board.Exists);

            m_moving = true;

            transform.position = nextPos;
        }
        m_moveCount = 0;
        m_moveDirection = new Vector3(x, 0, z);
    }
    bool CheckWall(int x,int z)
    {
        return (FieldDate.Instance.Fields(x, z) == Field.Wall);
    }
    bool CheckBoard(int x,int z)
    {
        return (FieldDate.Instance.Boards(x, z) == Board.Exists);
    }
    bool IsNextAdvance(Vector3 curPos, int x, int z)
    {
        int currentPos_x = Mathf.RoundToInt(curPos.x);
        int currentPos_z = Mathf.RoundToInt(curPos.z);

        if ((FieldDate.Instance.Fields(currentPos_x + x, currentPos_z + z)) == Field.Wall) return false;
        if ((FieldDate.Instance.Boards(currentPos_x + x, currentPos_z + z)) == Board.None) return false;
        return true;
    }

    void SmoothMoving()//スムーズに動かすための処理
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
            m_moving = false;
        }
    }
    void MoveStop()
    {
        m_param.Destination = Destination.None;
        m_param.Player.GetComponent<PlayerParam>().IsMoving = false;
        if (CheckGoal())
            //Scene_Manager.Instance.ChangeScene(Scene.Result);
            m_param.Player.GetComponent<PlayerParam>().IsGoal = true;

    }
    bool CheckGoal()    //自身がいる場所にゴールはあるか
    {
        Vector3 pos = transform.localPosition;
        var fieldData = FieldDate.Instance;
        return (fieldData.Fields(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)) == Field.Goal);
    }
    public Vector2 BoardDataValue()//
    {
        float x = transform.localPosition.x;
        float z = transform.localPosition.z;
        return new Vector2(x, z);
    }

}
