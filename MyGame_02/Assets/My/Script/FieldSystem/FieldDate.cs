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
    public Field Fields(int x, int z)
    {
        return m_fields[x, z];
    }
    public Field Fields(float x, float z)
    {
        var x_ = Mathf.RoundToInt(x);
        var z_ = Mathf.RoundToInt(z);
        return m_fields[x_, z_];
    }
    //フィールドのセット
    public void Fields(int x,int z, Field mapValue)
    {
        m_fields[x,z] = mapValue;
    }
    public void Fields(float x, float z, Field mapValue)
    {
        var x_ = Mathf.RoundToInt(x);
        var z_ = Mathf.RoundToInt(z);
        m_fields[x_, z_] = mapValue;
    }

    //ボード情報の取得
    public Board Boards(int x, int z)
    {
        return m_boards[x, z];
    }
    public Board Boards(float x, float z)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        return m_boards[x_, z_];
    }
    //ボード情報のセット
    public void Boards(int x, int z, Board boardValue)
    {
        m_boards[x, z] = boardValue;
    }
    public void Boards(float x, float z, Board boardValue)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        m_boards[x_, z_] = boardValue;
    }
    public void ChangeBoard(int prev_x, int prev_z, Board prev, int cur_x, int cur_z, Board cur)
    {
        m_boards[prev_x, prev_z] = prev;
        m_boards[cur_x, cur_z] = cur;
    }
    public void ChangeBoard(float prev_x, float prev_z, Board prev, float cur_x, float cur_z, Board cur)
    {
        int prev_x_ = Mathf.RoundToInt(prev_x);
        int prev_z_ = Mathf.RoundToInt(prev_z);

        int cur_x_ = Mathf.RoundToInt(cur_x);
        int cur_z_ = Mathf.RoundToInt(cur_z);

        m_boards[prev_x_, prev_z_] = prev;
        m_boards[cur_x_, cur_z_] = cur;
    }

    //ボード情報の取得
    public Player Player(int x, int z)
    {
        return m_onPlayer[x, z];
    }
    public Player Player(float x, float z)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        return m_onPlayer[x_, z_];
    }

    //ボード情報のセット
    public void Player(int x, int z, Player onPlayerdValue)
    {
        m_onPlayer[x, z] = onPlayerdValue;
    }
    public void Player(float x, float z, Player onPlayerdValue)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        m_onPlayer[x_, z_] = onPlayerdValue;
    }
    public void ChangePlayer(int prev_x, int prev_z, Player prev, int cur_x, int cur_z, Player cur)
    {
        m_onPlayer[prev_x, prev_z] = prev;
        m_onPlayer[cur_x, cur_z] = cur;
    }
    public void ChangePlayer(float prev_x, float prev_z, Player prev, float cur_x, float cur_z, Player cur)
    {
        int prev_x_ = Mathf.RoundToInt(prev_x);
        int prev_z_ = Mathf.RoundToInt(prev_z);

        int cur_x_ = Mathf.RoundToInt(cur_x);
        int cur_z_ = Mathf.RoundToInt(cur_z);

        m_onPlayer[prev_x_, prev_z_] = prev;
        m_onPlayer[cur_x_, cur_z_] = cur;
    }
}
