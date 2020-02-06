using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Image m_FadeImage;              //フェード用

    float m_FadeAlpha;          //フェード用キャンバスのα値
    float m_time = 0;           //フェード用時間

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        m_FadeImage = GetComponentInChildren<Image>();
    }
    private void Update()
    {
        FadeState();
    }
    void FadeState()
    {
        switch (m_fade)
        {
            case FadeType.NoFade:
                break;
            case FadeType.FadeIn:
                FadeIn();
                break;
            case FadeType.FadeOut:
                FadeOut();
                break;
        }
    }
    public void ChangeFade(FadeType changeState)
    {
        if (changeState == m_fade) return;
        m_FadeImage.transform.parent.gameObject.SetActive(true);
        m_fade = changeState;
    }
    //true→フェードイン時のチェック　false→フェードアウト時のチェック
    bool CheckFadeEnd(bool fadeIn)
    {
        if (fadeIn && m_FadeImage.color.a >= 1)
        {
            return true;
        }
        else if (!fadeIn && m_FadeImage.color.a <= 0)
        {
            return true;
        }
        else
            return false;
    }
    void FadeIn()
    {
       // m_time += m_fadeSpeed * Time.deltaTime;
        m_FadeAlpha = m_fadeSpeed * Time.deltaTime;

        Color fadeColor = m_FadeImage.color;

        fadeColor.a += m_FadeAlpha;
        m_FadeImage.color = fadeColor;
        //フェード終了か？
        if (CheckFadeEnd(true))
        {
            ChangeFade(FadeType.NoFade);
            m_FadeImage.transform.parent.gameObject.SetActive(false);
            m_time = 0;
        }
            
    }
    void FadeOut()
    {
        m_FadeAlpha = m_fadeSpeed * Time.deltaTime;
        Color fadeColor = m_FadeImage.color;

        fadeColor.a -= m_FadeAlpha;
        m_FadeImage.color = fadeColor;
        //フェード終了か？
        if (CheckFadeEnd(false))
        {
            ChangeFade(FadeType.NoFade);
            m_FadeImage.transform.parent.gameObject.SetActive(false);
            m_time = 0;
        }
            
    }

}
