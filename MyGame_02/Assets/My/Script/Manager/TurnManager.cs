using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerTurn
{
    None,
    Player_1,
    Player_2,
    Player_3,
    player_4,
   
}

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    PlayerTurn m_Turn;

    //PlayerMain[] m_player;
    PlayerTurn m_currentTurn;

    //プレイヤーオブジェクトとプレイヤー管理クラス
    PlayerMain[] m_playerUpdate = new PlayerMain[4];
    GameObject[] m_player = new GameObject[4];

    //列挙型のプレイヤーナンバーとプレイヤーオブジェクトをディクショナリで紐づける
    Dictionary<PlayerTurn, GameObject> m_TurnObj = new Dictionary<PlayerTurn, GameObject>();

    PlayerTurnUI m_turnUI;      

    int m_player_num=1;         //プレイヤーの番号
    int m_maxPlayerNum;         //プレイヤー数

    bool m_EndSetUp = false;    //セットアップ終了か

    void Start()
    {
        //最初は1Pから始める
        m_currentTurn = PlayerTurn.Player_1;
        m_Turn= PlayerTurn.Player_1;
        m_maxPlayerNum = GameData.Instance.PlayerCount;
        m_turnUI = FindObjectOfType<PlayerTurnUI>();
        StartCoroutine(lateStart());
    }

    void Update()
    {
        if (!m_EndSetUp) return;
        TurnUpdata();
    }
    /// <summary>
    /// プレイヤーターンの更新
    /// </summary>
    void TurnUpdata()
    {
        switch (m_Turn)
        {
            case PlayerTurn.Player_1:
                m_playerUpdate[0].MoveStateUpdate();
                break;
            case PlayerTurn.Player_2:
                m_playerUpdate[1].MoveStateUpdate();
                break;
            case PlayerTurn.Player_3:
                m_playerUpdate[2].MoveStateUpdate();
                break;
            case PlayerTurn.player_4:
                m_playerUpdate[3].MoveStateUpdate();
                break;
            case PlayerTurn.None:break;
        }
    }
    /// <summary>
    /// ターン切り替え
    /// </summary>
    /// <param name="nextTurn">次のプレイヤー</param>
    public void TurnChange(PlayerTurn nextTurn)
    {
        if (m_currentTurn == nextTurn) return;
        m_Turn = nextTurn;
        m_currentTurn = m_Turn;
    }
    //次のターンへ
    /// <summary>
    /// 次のターンへ
    /// </summary>
    public void NextTurn()
    {
        m_player_num++;
        if (m_player_num > m_maxPlayerNum)
            m_player_num = 1;
        PlayerTurn turn = (PlayerTurn)Enum.ToObject(typeof(PlayerTurn), m_player_num);
       m_turnUI.TurnChange(m_player_num);
        TurnChange(turn);
    }
    /// <summary>
    /// プレイヤーのセットアップ
    /// </summary>
    void PlayerInfoSetUp()
    {
        //プレイヤーを名前検索し、プレイヤーを配列に格納
        //配列に格納したオブジェクトをもとにPlayerMainスクリプトを取得格納
        //ディクショナリーにプレイヤーターンとオブジェクトを紐づける

        for (int i = 0; i < m_maxPlayerNum; i++)
        {
            m_player[i] = GameObject.Find("Player_" + (i + 1).ToString());
            m_playerUpdate[i] = m_player[i].GetComponent<PlayerMain>();
            m_TurnObj.Add((PlayerTurn)i+1, m_player[i]);
        }
    }
    /// <summary>
    /// 時差スタート処理
    /// </summary>
    /// <returns></returns>
    IEnumerator lateStart()
    {
        //0.5秒後から処理を開始する
        yield return new WaitForSeconds(0.5f);
        //ブレイクするまでループ
        while (true)
        {
            //探しているものがnullなら最初からやり直す
            if (GameObject.FindGameObjectWithTag("Player") == null) continue;
            PlayerInfoSetUp();
            m_EndSetUp = true;
            break;  //セットアップ終了
        }
    }
    //現在のターンのオブジェクトを返却
    /// <summary>
    /// 現在のターンのプレイヤーターンオブジェクト
    /// </summary>
    /// <returns>プレイヤーオブジェクト</returns>
    public GameObject TurnPlayer()
    {
        return m_TurnObj[m_Turn];
    }
    /// <summary>
    /// 現在のターンのプレイヤー番号の返却
    /// </summary>
    /// <returns>プレイヤー番号</returns>
    public PlayerTurn GetTurn()
    {
        return m_Turn;
    }
}
