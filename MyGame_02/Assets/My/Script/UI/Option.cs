using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField,Header("オプションを開いているか")]
    bool m_isOpen=false;
    /// <summary>
    /// オプション画面の開閉状態　true=開　false=閉
    /// </summary>
    public bool OptionOpen { get { return m_isOpen; } }
    [SerializeField, Header("オプション→")]
    RectTransform m_optionArrow;

    RectTransform m_optionTransform;    //オプション画面UIのトランスフォーム

    // Start is called before the first frame update
    void Start()
    {
        m_optionTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// オプション画面尾開閉処理
    /// </summary>
    public void Change()
    {
        if (OptionOpen)//開いている状態の場合
            Close();
        else//開いていない状態の場合
            Open();
    }
    /// <summary>
    /// オプション画面を開く
    /// </summary>
    void Open()
    {
        m_optionTransform.DOAnchorPosX(0, 0.5f);
        m_optionArrow.DORotate(new Vector3(0, 0, 0), 0.5f);
        SoundManager.Instance.PlaySEByName("OptionOpen");
        m_isOpen = true;
        
    }
    /// <summary>
    /// オプション画面を閉じる
    /// </summary>
    void Close()
    {
        m_optionTransform.DOAnchorPosX(287, 0.5f);
        m_optionArrow.DORotate(new Vector3(0, 0, 180), 0.5f);
        SoundManager.Instance.PlaySEByName("OptionClose");
        m_isOpen = false;
    }
}