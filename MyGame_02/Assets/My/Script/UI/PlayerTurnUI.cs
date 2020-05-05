using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    #region 
    [SerializeField, Header("プレイヤーターン")]
    GameObject m_playerTurn;


    int m_nextTurn = 0;

    List<RectTransform> m_TurnUI = new List<RectTransform>();
    TurnManager m_turn;

    RectTransform m_messageUI;

    //メッセージの表示ポジション 後でリネーム
    Vector2 m_messageStartPos = new Vector2(900, -30);
    Vector3 m_messageStopPos = new Vector3(50, -30, 0);
    Vector3 m_messageEndPos = new Vector3(-750, -30, 0);
    Vector3 m_messageEndPos2 = new Vector3(-1500, -30, 0);
    Vector3 m_messageEndPos3 = new Vector3(-2350, -30, 0);

    #endregion

    int m_curTurn = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetChild();
        m_turn = FindObjectOfType<TurnManager>();
        m_TurnUI[m_curTurn].DOAnchorPos3DX(0, 0.5f);
        SetUp();
    }
    void GetChild()
    {
        foreach (Transform child in m_playerTurn.transform)
        {
            var rect = child.gameObject.GetComponent<RectTransform>();
            m_TurnUI.Add(rect);
        }
    }
    //初期設定
    void SetUp()
    {
        NoDisplayTurnUI();
        for (int i = 0; i < GameData.Instance.PlayerCount; i++)
        {
            m_TurnUI[i].gameObject.SetActive(true);
        }
    }
    //全てのプレイヤーターンのUIを非表示にする
    public void NoDisplayTurnUI()
    {
        foreach (RectTransform ui in m_TurnUI)
        {
            ui.gameObject.SetActive(false);
        }
    }
    //ターン切り替え時のUI変化　nextTurn=次のターンプレイヤーの番号
    public void TurnChange(int nextTurn)
    {
        m_nextTurn = nextTurn;
        StartCoroutine(UIChange());
    }
    //UIの動き
    IEnumerator UIChange()
    {
        m_TurnUI[m_curTurn].DOAnchorPos3DX(35, 0.5f);
        yield return new WaitForSeconds(0.5f);
        m_TurnUI[m_nextTurn-1].DOAnchorPos3DX(0, 0.5f);
        m_curTurn = m_nextTurn-1;
    }

}
