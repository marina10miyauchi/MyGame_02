using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>フィールドの現状  </summary>
public enum Field 
{
    /// <summary> 何もない </summary>
    None,
    /// <summary> 壁がある </summary>
    Wall,
    /// <summary> ゴールがある </summary>
    Goal
}

/// <summary> 移動床の状態 </summary>
public enum Board
{
    /// <summary> なにもない </summary>
    None,
    /// <summary> 床がある </summary>
    Exists,
    /// <summary> 移動中 </summary>
    Moving,
    /// <summary>プレイヤーが上に乗っている </summary>
    OnPlayer,   
}
/// <summary> プレイヤーの情報（いるかどうか） </summary>
public enum Player
{
    /// <summary>上にいる </summary>
    In,
    /// <summary> 上にいない </summary>
    notIn
}

public class FieldDate : SingletonMonoBehaviour<FieldDate>
{
    [SerializeField, Header("フィールド横範囲")]
    static int m_side=9;
    [SerializeField, Header("フィールド奥行き範囲")]
    static int m_depth=9;

    /// <summary>1マスの大きさ </summary>
    public float m_TroutSize { get; set; }

    Field[,] m_fields = new Field[m_side, m_depth];
    Board[,] m_boards = new Board[m_side, m_depth];
    Player[,] m_onPlayer = new Player[m_side, m_depth];

    /// <summary> フィールドの取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>指定された引数の場所のField配列の情報</returns>
    public Field Fields(int x, int z)
    {
        return m_fields[x, z];
    } 
    /// <summary> フィールドの取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>指定された引数の場所のField配列の情報</returns>
    public Field Fields(float x, float z)
    {
        var x_ = Mathf.RoundToInt(x);
        var z_ = Mathf.RoundToInt(z);
        return m_fields[x_, z_];
    }
    /// <summary> フィールド情報のセット </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="mapValue">セットするフィールド情報</param>
    public void Fields(int x,int z, Field mapValue)
    {
        m_fields[x,z] = mapValue;
    }
    /// <summary> フィールド情報のセット </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="mapValue">セットするフィールド情報</param>
    public void Fields(float x, float z, Field mapValue)
    {
        var x_ = Mathf.RoundToInt(x);
        var z_ = Mathf.RoundToInt(z);
        m_fields[x_, z_] = mapValue;
    }
    /// <summary> ボード情報の取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>指定したポジションのボード情報</returns>
    public Board Boards(int x, int z)
    {
        return m_boards[x, z];
    }
    /// <summary> ボード情報の取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>指定したポジションのボード情報</returns>
    public Board Boards(float x, float z)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        return m_boards[x_, z_];
    }
    /// <summary> ボード情報のセット </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="boardValue">セットするボード情報</param>
    public void Boards(int x, int z, Board boardValue)
    {
        m_boards[x, z] = boardValue;
    }
    /// <summary> ボード情報のセット </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="boardValue">セットするボード情報</param>
    public void Boards(float x, float z, Board boardValue)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        m_boards[x_, z_] = boardValue;
    }

    /// <summary> 指定したボードのポジション二つを入れ替える </summary>
    /// <param name="prev_x">移動前のポジション x</param>
    /// <param name="prev_z">移動前のポジション z</param>
    /// <param name="prev">移動前のポジションの移動後のボード状態</param>
    /// <param name="cur_x">移動後のポジション</param>
    /// <param name="cur_z">移動後のポジション</param>
    /// <param name="cur">移動後のポジションの移動後のボード状態</param>
    public void ChangeBoard(int prev_x, int prev_z, Board prev, int cur_x, int cur_z, Board cur)
    {
        m_boards[prev_x, prev_z] = prev;
        m_boards[cur_x, cur_z] = cur;
    }
    /// <summary> 指定したボードのポジション二つを入れ替える </summary>
    /// <param name="prev_x">移動前のポジション x</param>
    /// <param name="prev_z">移動前のポジション z</param>
    /// <param name="prev">移動前のポジションの移動後のボード状態</param>
    /// <param name="cur_x">移動後のポジション</param>
    /// <param name="cur_z">移動後のポジション</param>
    /// <param name="cur">移動後のポジションの移動後のボード状態</param>
    public void ChangeBoard(float prev_x, float prev_z, Board prev, float cur_x, float cur_z, Board cur)
    {
        int prev_x_ = Mathf.RoundToInt(prev_x);
        int prev_z_ = Mathf.RoundToInt(prev_z);

        int cur_x_ = Mathf.RoundToInt(cur_x);
        int cur_z_ = Mathf.RoundToInt(cur_z);

        m_boards[prev_x_, prev_z_] = prev;
        m_boards[cur_x_, cur_z_] = cur;
    }

    /// <summary> プレイヤーボード情報の取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>x,zの場所のプレイヤー情報</returns>
    public Player Player(int x, int z)
    {
        return m_onPlayer[x, z];
    }
    /// <summary> プレイヤーボード情報の取得 </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <returns>x,zの場所のプレイヤー情報</returns>
    public Player Player(float x, float z)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        return m_onPlayer[x_, z_];
    }

    /// <summary> プレイヤーボード情報のセット  </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="onPlayerdValue">x,zの場所のプレイヤー情報</param>
    public void Player(int x, int z, Player onPlayerdValue)
    {
        m_onPlayer[x, z] = onPlayerdValue;
    }
    /// <summary> プレイヤーボード情報のセット  </summary>
    /// <param name="x">ポジション x</param>
    /// <param name="z">ポジション z</param>
    /// <param name="onPlayerdValue">x,zの場所のプレイヤー情報</param>
    public void Player(float x, float z, Player onPlayerdValue)
    {
        int x_ = Mathf.RoundToInt(x);
        int z_ = Mathf.RoundToInt(z);
        m_onPlayer[x_, z_] = onPlayerdValue;
    }
    /// <summary> 指定したプレイヤーボード情報を切り替える </summary>
    /// <param name="prev_x">移動前のポジション x</param>
    /// <param name="prev_z">移動前のポジション z</param>
    /// <param name="prev">移動前のポジションの移動後の状態</param>
    /// <param name="cur_x">移動後のポジション x</param>
    /// <param name="cur_z">移動後のポジション z</param>
    /// <param name="cur">移動後のポジションの移動後の状態</param>
    public void ChangePlayer(int prev_x, int prev_z, Player prev, int cur_x, int cur_z, Player cur)
    {
        m_onPlayer[prev_x, prev_z] = prev;
        m_onPlayer[cur_x, cur_z] = cur;
    }
    /// <summary> 指定したプレイヤーボード情報を切り替える </summary>
    /// <param name="prev_x">移動前のポジション x</param>
    /// <param name="prev_z">移動前のポジション z</param>
    /// <param name="prev">移動前のポジションの移動後の状態</param>
    /// <param name="cur_x">移動後のポジション x</param>
    /// <param name="cur_z">移動後のポジション z</param>
    /// <param name="cur">移動後のポジションの移動後の状態</param>
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
