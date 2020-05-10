using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
    PlayerParam m_param;
    PlayerStateChecker m_stateChange;
    TurnManager m_turn;
    Transform m_parent;     //プレイヤーのトランスフォーム

    Animator m_animator;

    Vector3 m_lookPoint;    //モデルが最後に見るポジション

    bool m_one = false;     //一度だけ処理するためのフラグ
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
    /// <summary>
    /// 終了行動
    /// </summary>
    public void End()
    {
        //乗っているボードのデータを取得　配列を直す
        var boarData = m_param.UnderBoard.GetComponent<MoveBoard>().BoardDataValue();
        var prevPos = m_param.Target.transform.localPosition;

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
    /// <summary>
    /// ゴール時処理
    /// </summary>
    public void Goal()
    {
        if (!m_one)
        {
            FindObjectOfType<PlayerTurnUI>().NoDisplayTurnUI();
            StartCoroutine(GoalAction());
            m_one = true;
        }
    }
    /// <summary>
    /// ゴール時の挙動
    /// </summary>
    /// <returns></returns>
    IEnumerator GoalAction()
    {
        //プレイヤー演出が入る前にBGMを止めるかボリュームを下げる
        Camera.main.GetComponent<CameraControll>().GoalEvent();
        m_param.Model.transform.eulerAngles = new Vector3(0, 200, 0); 
        yield return new WaitForSeconds(2);

        m_animator.SetTrigger("IsGoal");
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.PlaySEByName("pacchiJamp");

        yield return new WaitForSeconds(1.5f);
        SoundManager.Instance.PlaySEByName("pose_2");

        Camera.main.GetComponent<CameraControll>().ResultCamera();
        yield return new WaitForSeconds(2);
        SoundManager.Instance.PlaySEByName("result");
        FindObjectOfType<ResultManager>().SetResult();

        //UI表示
    }
    /// <summary>
    /// 移動ターゲットをプレイヤーの位置にセット
    /// </summary>
    void TargetPosSet()
    {
        Vector3 pos = m_param.Target.transform.position;
        pos.x = Mathf.RoundToInt(m_parent.position.x);
        pos.z = Mathf.RoundToInt(m_parent.position.z);
        m_param.Target.transform.position = pos;

    }
    /// <summary>
    /// ゴールはあるか
    /// </summary>
    /// <param name="x">チェックするポジション x</param>
    /// <param name="z">チェックするポジション z</param>
    /// <returns>true= ゴール有  false= ゴール無 </returns>
    bool CheckGoal(float x,float z)    
    {
        var fieldData = FieldDate.Instance;
        return (fieldData.Fields(Mathf.RoundToInt(x), Mathf.RoundToInt(z)) == Field.Goal);
    }

}
