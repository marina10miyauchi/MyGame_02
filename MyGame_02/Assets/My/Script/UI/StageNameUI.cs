using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Stage{
    Null,
    Stage01,
    Stage02,
    Stage03,
    Stage04,
    Stage05
}

public class StageNameUI : MonoBehaviour,IPointerClickHandler
{
    [SerializeField,Header("何処につながっているか")]
    Stage m_stage;

    RectTransform m_rect;
    Option m_option;
    SelectPlayer m_selectPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_rect = GetComponent<RectTransform>();
        m_option = GameObject.FindObjectOfType<Option>();
        m_selectPlayer = GameObject.Find("SelectPlayer").GetComponent<SelectPlayer>();
        SoundManager.Instance.PlayBGMByName("Select");

    }

    public void OnPointerClick(PointerEventData pointerData)//マウスでクリックされたときの処理
    {
        if (m_option.OptionOpen) return;
        if (CenterCheck())
        {
            m_selectPlayer.IsEnd = true;
            SetStage();
            SoundManager.Instance.PlaySEByName("Click");
            Scene_Manager.Instance.ChangeScene(Scene.Game);
            SoundManager.Instance.StopBGM();
        }
    }
    /// <summary>
    /// ステージのセット
    /// </summary>
    void SetStage()
    {
        //ステージ情報をもとにcsvをゲームデータに渡す
        switch (m_stage)
        {
            case Stage.Null: break;
            case Stage.Stage01:
                GameData.Instance.StageName = "field_1";
                break;
            case Stage.Stage02:
                GameData.Instance.StageName = "field_2";
                break;
            case Stage.Stage03:
                GameData.Instance.StageName = "field_3";
                break;
            case Stage.Stage04:
                GameData.Instance.StageName = "field_4";
                break;
            case Stage.Stage05:
                GameData.Instance.StageName = "field_4";
                break;

        }
    }
    /// <summary>
    /// クリック範囲か　
    /// </summary>
    /// <returns>true= 可  false= 不可 </returns>
    bool CenterCheck()
    {
        //UIのx座標が中心値近辺にあったらクリック可能
        if (240 < m_rect.anchoredPosition.x && m_rect.anchoredPosition.x <= 260)
            return true;
        else
            return false;
    }

}
