using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum FadeType
{
    NoFade,     //フェードしない
    FadeIn,     //フェードイン
    FadeOut,    //フェードアウト
}

public class Fade : MonoBehaviour
{
    [SerializeField,Header("フェードスピード")]
    float m_fadeSpeed = 1f;

    [SerializeField, Header("フェード状態")]
    FadeType m_fade=FadeType.FadeOut;
    [SerializeField,Header("フェード用Image")]
    Image m_FadeImage;              

    void Start()
    {
        DontDestroyOnLoad(this);
        m_FadeImage = GetComponentInChildren<Image>();
        FadeOut();
    }
    //フェードイン
    public void FadeIn()
    {
        StartCoroutine(FadeInStart());
    }
    //フェードアウト
    public void FadeOut()
    {
        StartCoroutine(FadeOutStart());
    }
    //フェードイン処理（コルーチン）
    IEnumerator FadeInStart()
    {
        m_FadeImage.transform.parent.gameObject.SetActive(true);
        //yield return new WaitForSeconds(1);
        m_FadeImage.DOFade(1, 1);
        yield return new WaitForSeconds(1);

    }
    //フェードアウト処理（コルーチン）
    IEnumerator FadeOutStart()
    {
        //yield return new WaitForSeconds(1);
        m_FadeImage.DOFade(0, 1);
        yield return new WaitForSeconds(1);
        m_FadeImage.transform.parent.gameObject.SetActive(false);

    }
}
