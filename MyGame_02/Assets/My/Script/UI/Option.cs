using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField,Header("オプションを開いているか")]
    bool m_isOpen=false;
    [SerializeField, Header("プレイヤー人数テキスト")]
    Text m_playerCountText;
    [SerializeField, Header("BGM_text")]
    Text m_BGM;
    [SerializeField, Header("SE_text")]
    Text m_SE;

    RectTransform m_optionTransform;

    // Start is called before the first frame update
    void Start()
    {
        m_optionTransform = GetComponent<RectTransform>();
        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();
    }

    // Update is called once per frame
    public void Change()
    {
        if (m_isOpen)//開いている状態の場合
            Close();
        else//開いていない状態の場合
            Open();
    }
    void Open()
    {
        m_optionTransform.DOAnchorPosX(0, 0.5f);
        m_isOpen = true;
        
    }
    void Close()
    {
        m_optionTransform.DOAnchorPosX(287, 0.5f);
        m_isOpen = false;
    }
    //プレイヤー人数の変動
    //add=true → 増加 add=false → 減少
    public void Count(bool add)
    {
        if (!m_isOpen) return;
        if (add)
            GameData.Instance.AddPlayer();
        else
            GameData.Instance.DecrementPlayer();

        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();
       
    }
    //public void BGMSetting(bool add)
    //{
    //    if (!m_isOpen) return;
    //    if (add)
    //        SoundManager.Instance.BGMVolume=()

    //}
}