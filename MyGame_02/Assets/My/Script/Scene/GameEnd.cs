using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    [SerializeField,Header("テキスト")]
    GameObject m_textObj;

    TextMeshProUGUI m_text;

    float m_alpha = 0;  //テキストカラーのα値

    bool m_IsAlphaMax;//α値がマックスになったか
    bool m_IsEnd;

    // Start is called before the first frame update
    void Start()
    {
        m_text = m_textObj.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsAlphaMax)
            FadeInText();
        else
            FadeOutText();

        if (m_IsEnd) Scene_Manager.Instance.GameEnd();

    }
    void FadeInText()
    {
        if (m_alpha <= 1)
        {
            m_alpha += 0.2f * Time.deltaTime;
            m_text.alpha = m_alpha;          
        }
        else
        {
            m_IsAlphaMax = true;
        }
        
    }
    void FadeOutText()
    {
        if (m_alpha >= 0)
        {
            m_alpha -= 0.2f * Time.deltaTime;
            m_text.alpha = m_alpha;

        }
        else
        {
            m_IsEnd = true;
        }
    }
}
