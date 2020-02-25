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

    [SerializeField,Header("クリック可能か（センターか）")]
    bool m_IsOnClick = true;

    RectTransform m_rect;

    // Start is called before the first frame update
    void Start()
    {
        m_rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (195<= m_rect.position.x && m_rect.position.x<125)
        //    m_IsOnClick = true;
    }
    public void OnPointerClick(PointerEventData pointerData)//マウスでクリックされたときの処理
    {
        if (m_IsOnClick)
        {
            SetStage();
            Scene_Manager.Instance.ChangeScene(Scene.Game);
        }
    }
    void SetStage()
    {
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

}
