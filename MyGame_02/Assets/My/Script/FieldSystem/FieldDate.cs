using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Field      //フィールドの現状
{
    None,
    Wall,
    Goal
}

public enum Board     //移動床の状態
{
    None,
    Exists,
    Moving,
    OnPlayer,
}

public enum Player
{
    In,      //上にいる
    notIn    //上にいない
}

public class FieldDate : SingletonMonoBehaviour<FieldDate>
{
    [SerializeField, Header("フィールド横範囲")]
    static int m_side=9;
    [SerializeField, Header("フィールド奥行き範囲")]
    static int m_depth=9;

    public float m_TroutSize { get; set; }

    Field[,] m_fields = new Field[m_side, m_depth];
    Board[,] m_boards = new Board[m_side, m_depth];
    Player[,] m_onPlayer = new Player[m_side, m_depth];

    //フィールドの取得
    public Field Fields(int x,int z)
    {
        return m_fields[x,z];
    }
    //フィールドのセット
    public void Fields(int x,int z, Field mapValue)
    {
        m_fields[x,z] = mapValue;
    }

    //入れ替え
    public void ChangeFields(int prev_x,int prev_z,Field prev,int cur_x,int cur_z,Field cur)
    {
        m_fields[prev_x, prev_z] = prev;
        m_fields[cur_x, cur_z] = cur;
    }

    //ボード情報の取得
    public Board Boards(int x, int z)
    {
        return m_boards[x, z];
    }
    //ボード情報のセット
    public void Boards(int x, int z, Board boardValue)
    {
        m_boards[x, z] = boardValue;
    }
    public void ChangeBoard(int prev_x, int prev_z, Board prev, int cur_x, int cur_z, Board cur)
    {
        m_boards[prev_x, prev_z] = prev;
        m_boards[cur_x, cur_z] = cur;
    }
    //ボード情報の取得
    public Player Player(int x, int z)
    {
        return m_onPlayer[x, z];
    }
    //ボード情報のセット
    public void Player(int x, int z, Player onPlayerdValue)
    {
        m_onPlayer[x, z] = onPlayerdValue;
    }
    public void ChangePlayer(int prev_x, int prev_z, Player prev, int cur_x, int cur_z, Player cur)
    {
        m_onPlayer[prev_x, prev_z] = prev;
        m_onPlayer[cur_x, cur_z] = cur;
    }


}
