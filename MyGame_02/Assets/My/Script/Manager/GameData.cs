using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
    [SerializeField, Header("プレイ人数")]
    int m_player_count = 1;
    public int PlayerCount { get { return m_player_count; } }

    [SerializeField, Header("ステージの横のサイズ")]
    int m_stageWide = 10;
    public int StageWidth { get { return m_stageWide; } set { m_stageWide = value; } }
    [SerializeField, Header("ステージの高さ（奥行き）")]
    int m_stageHeight = 10;
    public int StageHeight { get { return m_stageHeight; } set { m_stageHeight = value; } }

    [SerializeField,Header("行動回数")]
    int m_actionCoun=0;
    public int ActionCount { get { return m_actionCoun; } private set { } }

    [SerializeField, Header("選択したステージの名前")]
    string m_stageName= "field_1";
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
    //行動回数追加
    public void MoveCount()
    {
        m_actionCoun++;
    }
    //数値の初期化
    public void ReSet()
    {
        m_actionCoun = 0;
        ElapsedTime = 0;
    }
    //プレイヤー追加
    public void AddPlayer()
    {
        //プレイヤー人数が4の場合これ以上増やさない
        if (m_player_count == 4) return;    

            m_player_count++;
    }
    //プレイヤー減少
    public void DecrementPlayer()
    {
        //プレイヤー人数が1の場合これ以上減らさない
        if (m_player_count == 1) return;    
        m_player_count--;       
    }
}
