using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionSetting : MonoBehaviour
{
    [SerializeField, Header("プレイヤー人数テキスト")]
    Text m_playerCountText;
    [SerializeField, Header("BGM_text")]
    Text m_BGM;
    [SerializeField, Header("SE_text")]
    Text m_SE;

    float m_SEVolume = 5;    //現在SEのvolumeの大きさ
    float m_BGMVolume = 5;    //現在BGMのvolumeの大きさ

    float m_maxVolume = 10;   //音の最大volume値
    float m_minVolume = 0;    //音の最小volume値



    Option m_option;

    void Start()
    {
        m_option = GetComponent<Option>();

        m_BGMVolume = SoundManager.Instance.BGMVolume * 10;
        m_SEVolume = SoundManager.Instance.SEVolume * 10;

        m_BGM.text = m_BGMVolume.ToString();
        m_SE.text = m_SEVolume.ToString();

        if (m_playerCountText != null) return;
        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //プレイヤー人数の変動
    //add=true → 増加 add=false → 減少
    public void Count(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add)
            GameData.Instance.AddPlayer();
        else
            GameData.Instance.DecrementPlayer();

        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();

    }
    public void BGMSettion(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add)UpBGM();
        else DownBGM();

        SoundManager.Instance.BGMVolume =m_BGMVolume/10;
        m_BGM.text = m_BGMVolume.ToString();
    }
    void UpBGM()
    {
        if (m_BGMVolume == m_maxVolume) return;
        m_BGMVolume+=1;
    }
    void DownBGM()
    {
        if (m_BGMVolume == m_minVolume) return;
        m_BGMVolume-=1;
    }

    public void SESetting(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add) UpSE();
        else DownSE();

        SoundManager.Instance.SEVolume = m_SEVolume / 10;
        m_SE.text = m_SEVolume.ToString();
    }
    void UpSE()
    {
        if (m_SEVolume == m_maxVolume) return;
        m_SEVolume += 1;
    }
    void DownSE()
    {
        if (m_SEVolume == m_minVolume) return;
        m_SEVolume -= 1;
    }
}
