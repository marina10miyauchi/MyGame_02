using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;
    TurnManager m_turn;
    Transform m_parent;//プレイヤーのトランスフォーム

    Camera m_EventCamera;
    Animator m_animator;

    Vector3 m_lookPoint;

    bool m_one = false;
    void Start()
    {
        m_param = transform.root.gameObject.GetComponent<PlayerParam>();
        m_turn = FindObjectOfType<TurnManager>();
        m_stateChange = transform.parent.gameObject.GetComponent<PlayerStateChecker>();
        m_parent = transform.root;
        m_animator = m_parent.GetComponent<Animator>();
        m_lookPoint = GameObject.Find("Goal").transform.position;
        m_lookPoint.y = m_parent.position.y;
        m_lookPoint.z -= 2.5f;
    }
    public void End()//行動終了
    {
        //乗っているボードのデータを取得　配列を直す
        var boarData = m_param.UnderBoard.GetComponent<MoveBoard>().BoardDataValue();
        var prevPos = m_param.Target.transform.localPosition;
        //FieldDate.Instance.Player(Mathf.RoundToInt(prevPos.x), Mathf.RoundToInt(prevPos.z), Player.notIn);
        //FieldDate.Instance.Player(Mathf.RoundToInt(boarData.x), Mathf.RoundToInt(boarData.y), Player.In);


        //行動回数のカウント
        GameData.Instance.MoveCount();
        //ゴールしたか
        if (CheckGoal(boarData.x, boarData.y))
        {
            m_stateChange.ChangeState(PlayerState.Goal);
        }
        else
        {
            TargetPosSet();
            //m_parent.parent = null;
            m_stateChange.ChangeState(PlayerState.Idle);
            m_turn.NextTurn();
        }
    }
    public void Goal()
    {
        if (!m_one)
        {
            FindObjectOfType<PlayerTurnUI>().NoDisplayTurnUI();
            StartCoroutine(GoalAction());
            m_one = true;
        }
    }
    IEnumerator GoalAction()
    {
        Camera.main.GetComponent<CameraControll>().GoalEvent();
        m_param.Model.transform.eulerAngles = new Vector3(0, 200, 0); 
        yield return new WaitForSeconds(2);
        m_animator.SetTrigger("IsGoal");
        yield return new WaitForSeconds(3);
        Camera.main.GetComponent<CameraControll>().ResultCamera();
        yield return new WaitForSeconds(2);
        FindObjectOfType<ResultManager>().SetResult();

        //UI表示
    }
    void TargetPosSet()//移動ターゲットをプレイヤーの位置にセット
    {
        Vector3 pos = m_param.Target.transform.position;
        pos.x = Mathf.RoundToInt(m_parent.position.x);
        pos.z = Mathf.RoundToInt(m_parent.position.z);
        m_param.Target.transform.position = pos;

    }
    bool CheckGoal(float x,float z)    //自身がいる場所にゴールはあるか
    {
        var fieldData = FieldDate.Instance;
        return (fieldData.Fields(Mathf.RoundToInt(x), Mathf.RoundToInt(z)) == Field.Goal);
    }

}
