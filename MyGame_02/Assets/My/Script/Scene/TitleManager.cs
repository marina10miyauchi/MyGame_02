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
    [SerializeField, Header("演出用アニメーター")]
    Animator m_directingAnim;
    bool m_flashing = false;

    Fade m_fade;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        m_fade = GameObject.Find("FadeManager").GetComponentInChildren<Fade>();
        StartCoroutine(StartBGM());
    }

    // Update is called once per frame
    void Update()
    {
        MessageFlashing(m_flashing);
        //マウスボタンの右でも左でも反応
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            m_flashing = true;
            StartCoroutine(ChangeDirecting());
        }
    }
    IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayBGMByName("GameTitle");

    }
    //ボタンクリック時の演出 数秒待ってシーン遷移
    IEnumerator ChangeDirecting()
    {
        yield return new WaitForSeconds(2);
        //ぱっちぃアニメーション

        yield return new WaitForSeconds(2);
        m_fade.ChangeFade(FadeType.FadeIn);
        //フェードアウト
        yield return new WaitForSeconds(1);
        //フェードアウト終了後シーン切り替え
        Scene_Manager.Instance.ChangeScene(Scene.Select);
    }
    //メッセージの点滅
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
