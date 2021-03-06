﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AI;

[DefaultExecutionOrder(-103)]//他よりも少し早く読み込むため
public class FieldFactory : MonoBehaviour
{
    [SerializeField,Header("移動床")]
    GameObject m_SliderObj;
    [SerializeField, Header("壁")]
    GameObject m_wall;
    [SerializeField, Header("ゴール")]
    GameObject m_goal;
    float m_tile_size = 1.0f;       //オブジェクトサイズ

    List<string[]> m_data = new List<string[]>();//csvのデータを格納するリスト
    void Awake()
    {
        //1マスの大きさの設定
        FieldDate.Instance.m_TroutSize = m_wall.transform.localScale.x;
        m_tile_size = FieldDate.Instance.m_TroutSize;
        m_data = CSVConverter.Instance.CSVConversion(GameData.Instance.StageName);
       CreateField();
    }
    /// <summary>データと照らし合わせてフィールドを作成 </summary>
    /// <param name="SpecificChar">データ内の文字列</param>
    /// <param name="w">ポジション</param>
    /// <param name="h">ポジション</param>
    void FieldSet(string SpecificChar,int x,int z)
    {
        Vector3 pos = new Vector3(x * m_tile_size, 0.5f, z * m_tile_size);

        var fieldDate = FieldDate.Instance;
        fieldDate.Player(x, z, Player.notIn);

        switch (SpecificChar)
        {
            case "0"://何もない場所
                fieldDate.Fields(x, z,Field.None);
                break;
            case "1":
                fieldDate.Boards(x, z, Board.Exists);
                var obj=Instantiate(m_SliderObj, pos, Quaternion.identity, transform);
                obj.name = "Slider" + x + "," + z;
                break;
            case "5"://ゴール
                fieldDate.Fields(x, z, Field.Goal);
                pos.y = 0.3f;
                var goal = Instantiate(m_goal, pos, Quaternion.identity, transform);
                goal.name = "Goal";
                break;
            case "9"://壁
                fieldDate.Fields(x, z, Field.Wall);
                Instantiate(m_wall, pos, Quaternion.identity, transform);
                break;
            default: //その他
                Debug.LogError("不正な文字が混入しています:" + SpecificChar);
                break;
        }
    }
    /// <summary> フィールド生成 </summary>
    void CreateField()
    {
        for (int x = 0; x < m_data.Count; x++)
        {
            //列のループ
            for (int z = 0; z < m_data.Count; z++)
            {
                //フィールド情報のセット
                FieldSet(m_data[x][z], x, z);
            }
        }

    }
}
