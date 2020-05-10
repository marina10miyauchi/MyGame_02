using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVConverter : SingletonMonoBehaviour<CSVConverter>
{
    List<string[]> m_csvDate = new List<string[]>();//csvのデータを格納するリスト
    TextAsset m_fieldFile;

    /// <summary>
    /// csv形式から変換してリストに追加
    /// </summary>
    /// <param name="fileName">csvのファイル名</param>
    /// <returns></returns>
    public List<string[]> CSVConversion(string fileName)
    {

        //Resourceファイルの中にあるフィールドのファイルをTestAssetに変換
        m_fieldFile = Resources.Load("Field/" + fileName) as TextAsset;
        //文字列の読み込み
        StringReader reader = new StringReader(m_fieldFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            m_csvDate.Add(line.Split('\t'));//\t の 区切りでリストに追加
        }
        return m_csvDate;
    }
    public int csvSize()
    {
        return m_csvDate.Count;
    }
}
