using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleManager : MonoBehaviour
{
    #region フィールド

    [SerializeField, Header("通常時点滅スピード")]
    float m_NoClickFlashingSpeed = 0.5f;
    [SerializeField, Header("クリック時点滅スピード")]
    float m_ClickFlashingSpeed = 0.5f;
    [SerializeField, Header("pushButton")]
    TextMeshProUGUI m_pushButton;

    bool m_flashing = false;

    Fade m_fade;
    AudioSource m_sound;
    #endregion
    void Start()
    {
        m_fade = FindObjectOfType<Fade>();
        StartCoroutine(StartBGM());
        m_fade.FadeOut();
    }

    void Update()
    {
        MessageFlashing(m_flashing);
        //マウスボタンの右でも左でも反応
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            m_flashing = true;
            SoundManager.Instance.PlaySEByName("Click");
            Scene_Manager.Instance.ChangeScene(Scene.Select);
            SoundManager.Instance.StopBGM();
        }
    }
    IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayBGMByName("GameTitle");

    }
    /// <summary>
    /// メッセージ点滅
    /// </summary>
    /// <param name="click">クリックされたか</param>
    void MessageFlashing(bool click)
    {
        float speed = (click ? m_ClickFlashingSpeed : m_NoClickFlashingSpeed);
        //点滅スピード
        float flashingSpeed = Time.time * speed;
        float flashingValue= Mathf.Sin(flashingSpeed);

        Color textColor = m_pushButton.color;
        textColor.a = flashingValue;
        m_pushButton.color = textColor;
    }
}
