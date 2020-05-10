using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
    [SerializeField, Header("プレイ人数")]
    int m_player_count = 1;
    /// <summary>
    /// プレイ人数
    /// </summary>
    public int PlayerCount { get { return m_player_count; } }

    [SerializeField, Header("ステージの横のサイズ")]
    int m_stageWide = 10;
    /// <summary>
    /// ステージサイズ（横）
    /// </summary>
    public int StageWidth { get { return m_stageWide; } set { m_stageWide = value; } }
    [SerializeField, Header("ステージの高さ（奥行き）")]
    int m_stageHeight = 10;
    /// <summary>
    /// ステージサイズ（奥）
    /// </summary>
    public int StageHeight { get { return m_stageHeight; } set { m_stageHeight = value; } }

    [SerializeField,Header("行動回数")]
    int m_actionCoun=0;
    /// <summary>
    /// 行動回数
    /// </summary>
    public int ActionCount { get { return m_actionCoun; } private set { } }

    [SerializeField, Header("選択したステージの名前")]
    string m_stageName= "field_1";
    /// <summary>
    /// ステージ名
    /// </summary>
    public string StageName { get { return m_stageName; } set { m_stageName = value; } }

    [SerializeField, Header("クリアまでにかかった経過時間")]
    float m_elapsedTime = 0.0f;
    public float ElapsedTime { get { return m_elapsedTime; } set { m_elapsedTime = value; } }


    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    ///行動回数カウント
    /// </summary>
    public void MoveCount()
    {
        m_actionCoun++;
    }
    /// <summary>
    /// ゲームデータ初期化
    /// </summary>
    public void ReSet()
    {
        m_actionCoun = 0;
        ElapsedTime = 0;
    }
    /// <summary>
    /// プレイヤー人数追加
    /// </summary>
    public void AddPlayer()
    {
        //プレイヤー人数が4の場合これ以上増やさない
        if (m_player_count == 4) return;
        SelectSE();
        m_player_count++;
    }
    /// <summary>
    /// プレイヤー人数減少
    /// </summary>
    public void DecrementPlayer()
    {
        //プレイヤー人数が1の場合これ以上減らさない
        if (m_player_count == 1) return;
        SelectSE();
        m_player_count--;       
    }
    /// <summary>
    /// 選択中のSE
    /// </summary>
    void SelectSE()
    {
        SoundManager.Instance.PlaySEByName("select");
    }
}
