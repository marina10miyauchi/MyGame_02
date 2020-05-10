using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    [SerializeField, Header("行動回数表示テキスト")]
    GameObject m_CountText;
    [SerializeField,Header("リザルトUIのグループ")]
    CanvasGroup m_MenuImage;

    void Start()
    {
        m_MenuImage.alpha = 0;
        m_MenuImage.gameObject.SetActive(false);
    }
    /// <summary>
    /// リザルト情報セット
    /// </summary>
    public void SetResult()
    {
        m_MenuImage.gameObject.SetActive(true);
        var m_countResult = m_CountText.GetComponent<TMPro.TextMeshProUGUI>();
        m_countResult.text = "ActCount : " + (GameData.Instance.ActionCount / GameData.Instance.PlayerCount).ToString();
        m_MenuImage.DOFade(1, 1);

        GameData.Instance.ReSet();
    }
}
