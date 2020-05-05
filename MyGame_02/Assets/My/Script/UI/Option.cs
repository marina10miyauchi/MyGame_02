using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField,Header("オプションを開いているか")]
    bool m_isOpen=false;
    public bool OptionOpen { get { return m_isOpen; } }
    [SerializeField, Header("オプション→")]
    RectTransform m_optionArrow;

    RectTransform m_optionTransform;    //オプション画面UIのトランスフォーム

    // Start is called before the first frame update
    void Start()
    {
        m_optionTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void Change()
    {
        if (m_isOpen)//開いている状態の場合
            Close();
        else//開いていない状態の場合
            Open();
    }
    //オプション画面を開く
    void Open()
    {
        m_optionTransform.DOAnchorPosX(0, 0.5f);
        m_optionArrow.DORotate(new Vector3(0, 0, 0), 0.5f);
        m_isOpen = true;
        
    }
    //オプション画面を閉じる
    void Close()
    {
        m_optionTransform.DOAnchorPosX(287, 0.5f);
        m_optionArrow.DORotate(new Vector3(0, 0, 180), 0.5f);
        m_isOpen = false;
    }
}