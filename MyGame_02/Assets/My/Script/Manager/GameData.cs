using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
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
    string m_stageName="Stage_1";
    public string StageName { get { return m_stageName; } set { m_stageName = value; } }

    [SerializeField, Header("クリアまでにかかった経過時間")]
    float m_elapsedTime = 0.0f;
    public float ElapsedTime { get { return m_elapsedTime; } set { m_elapsedTime = value; } }

    // Start is called before the first frame update

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void MoveCount()
    {
        m_actionCoun++;
    }
}
