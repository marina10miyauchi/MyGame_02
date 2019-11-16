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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData pointerData)//マウスでクリックされたときの処理
    {
        SetStage();
        Scene_Manager.Instance.ChangeScene(Scene.Game);
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
