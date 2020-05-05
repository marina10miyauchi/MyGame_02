using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField,Header("ステージの名前が書いてあるUI")]
    GameObject m_stageNameUI;
    [SerializeField, Header("ステージの写真が載っているUI")]
    GameObject m_stageImageUI;

    StageSelectUI m_nameSelect;
    SelectStageUI m_imageSelect;
    Option m_option;

    [SerializeField,Header("上向き移動用か")]
    bool m_IsUP;

    bool m_onClick;             //クリックされたか

    float m_angle = 0;          //現在の角度
    float m_prevOffsetAngle;    //回転終了時の角度

    void Start()
    {
        m_nameSelect = m_stageNameUI.GetComponent<StageSelectUI>();
        m_imageSelect = m_stageImageUI.GetComponent<SelectStageUI>();
        m_prevOffsetAngle = m_nameSelect.OffsetAngle;
        m_option = GameObject.FindObjectOfType<Option>();   
    }

    private void Update()
    {
        if (m_option.OptionOpen) return;
        if (!m_onClick) return;
        if (m_IsUP)
            NextStage(-1);
        else
            NextStage(1);
    }
    //マウスでクリックされたときの処理
    public void OnPointerClick(PointerEventData pointerData)
    {
        m_onClick = true;
        if (m_IsUP)
            m_imageSelect.Next();
        else
            m_imageSelect.Back();
    }
    //次のステージまでUIを回転させる
    void NextStage(float changeValue)
    {
        if (Mathf.Abs(m_angle) <=Mathf.Abs(m_prevOffsetAngle+ m_nameSelect.TurnAngle))
        {
            m_nameSelect.OffsetAngle += changeValue*2;
            m_angle += changeValue*2;
        }
        else
        {
            m_prevOffsetAngle += m_nameSelect.TurnAngle;
            m_onClick = false;
        }
    }
}
