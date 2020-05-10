using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Fade : MonoBehaviour
{
    [SerializeField,Header("フェード用Image")]
    Image m_FadeImage;              

    void Start()
    {
        DontDestroyOnLoad(this);
        m_FadeImage = GetComponentInChildren<Image>();
        FadeOut();
    }
    /// <summary>
    /// フェードイン
    /// </summary>
    public void FadeIn()
    {
        StartCoroutine(FadeInStart());
    }
    /// <summary>
    /// フェードアウト
    /// </summary>
    public void FadeOut()
    {
        StartCoroutine(FadeOutStart());
    }
    /// <summary>
    /// フェードイン処理
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeInStart()
    {
        m_FadeImage.transform.parent.gameObject.SetActive(true);
        //yield return new WaitForSeconds(1);
        m_FadeImage.DOFade(1, 1);
        yield return new WaitForSeconds(1);

    }
    /// <summary>
    /// フェードアウト処理
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutStart()
    {
        //yield return new WaitForSeconds(1);
        m_FadeImage.DOFade(0, 1);
        yield return new WaitForSeconds(1);
        m_FadeImage.transform.parent.gameObject.SetActive(false);

    }
}
