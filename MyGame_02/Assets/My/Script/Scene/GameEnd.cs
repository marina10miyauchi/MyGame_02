﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameEnd : MonoBehaviour
{
    [SerializeField,Header("表示オブジェ")]
    GameObject m_textObj;

    TextMeshProUGUI m_text;

    void Start()
    {
        SoundManager.Instance.StopBGM();
        m_text = m_textObj.GetComponent<TextMeshProUGUI>();
        StartCoroutine(TextFade());
        SoundManager.Instance.PlaySEByName("GameEnd");
    }
    /// <summary>
    /// 文字フェード
    /// </summary>
    /// <returns></returns>
    IEnumerator TextFade()
    {
        m_text.DOFade(1, 3);
        yield return new WaitForSeconds(3);
        m_text.DOFade(0, 2);
        yield return new WaitForSeconds(3);
        Scene_Manager.Instance.GameEnd();

    }
}
