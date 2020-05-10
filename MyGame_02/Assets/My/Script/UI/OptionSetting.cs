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

        if (m_playerCountText == null) return;
        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();
    }
    //プレイヤー人数の変動
    //add=true → 増加 add=false → 減少
    /// <summary>
    /// プレイヤー人数変動
    /// </summary>
    /// <param name="add">true= +  false= - </param>
    public void Count(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add)
            GameData.Instance.AddPlayer();
        else
            GameData.Instance.DecrementPlayer();

        m_playerCountText.text = GameData.Instance.PlayerCount.ToString();

    }
    /// <summary>
    /// BGMの音量調整
    /// </summary>
    /// <param name="add">true= +  false= - </param>
    public void BGMSettion(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add)UpBGM();
        else DownBGM();

        SoundManager.Instance.BGMVolume =m_BGMVolume/10;
        m_BGM.text = m_BGMVolume.ToString();
    }
    /// <summary>
    /// BGMボリュームを大きく
    /// </summary>
    void UpBGM()
    {
        if (m_BGMVolume == m_maxVolume) return;
        SelectSE();
        m_BGMVolume +=1;
    }
    /// <summary>
    /// BGMボリュームを小さく
    /// </summary>
    void DownBGM()
    {
        if (m_BGMVolume == m_minVolume) return;
        SelectSE();
        m_BGMVolume -=1;
    }
    /// <summary>
    /// SE音量調整
    /// </summary>
    /// <param name="add">true= +  false= - </param>
    public void SESetting(bool add)
    {
        if (!m_option.OptionOpen) return;
        if (add) UpSE();
        else DownSE();

        SoundManager.Instance.SEVolume = m_SEVolume / 10;
        m_SE.text = m_SEVolume.ToString();
    }
    /// <summary>
    /// SEボリュームを大きく
    /// </summary>
    void UpSE()
    {
        if (m_SEVolume == m_maxVolume) return;
        SelectSE();
        m_SEVolume += 1;
    }
    /// <summary>
    /// SEボリュームを小さく
    /// </summary>
    void DownSE()
    {
        if (m_SEVolume == m_minVolume) return;
        SelectSE();
        m_SEVolume -= 1;
    }
    /// <summary>
    /// オプション設定中のSE
    /// </summary>
    void SelectSE()
    {
        SoundManager.Instance.PlaySEByName("select");
    }

}
