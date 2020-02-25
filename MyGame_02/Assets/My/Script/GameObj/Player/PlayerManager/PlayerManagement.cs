using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum PlayerNumber
{
    Player_1,   //1P
    Player_2,   //2P
    Player_3,   //3P
    Player_4,   //4P
    None,       //プレイヤーなし
}

public class PlayerManagement : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")]
    GameObject[] m_Player_;
    [SerializeField, Header("プレイヤー")]
    GameObject m_Player;

    public Dictionary<GameObject, PlayerNumber> m_playerData = new Dictionary<GameObject, PlayerNumber>();

    //変わる前のプレイヤーを保存
    PlayerNumber m_prevTurnPlayer;
    //ターンを切り替えるフラグ
    bool m_isChange;


    delegate void PlayerActions();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameData.Instance.PlayerCount; i++)
        {
             SetPlayer(i);
        }
        m_prevTurnPlayer = PlayerNumber.Player_1;
    }
    private void Update()
    {
        //TurnCheck();
        ////CheckPlayer();

        ////もしプレイヤーのターンが終了していてターンを切り替えられるなら
        //if (m_isChange)
        //{
        //    PlayerNumber nextturn = m_prevTurnPlayer + 1;
        //    if ((int)nextturn >= m_playerData.Count)
        //        nextturn = PlayerNumber.Player_1;
        //    ChangePlayerTurn(nextturn, GetPlayerDataKey(m_prevTurnPlayer));
        //    m_prevTurnPlayer = nextturn;
        //}
    }

    //void TurnCheck()    //現在のターンに行動中のプレイヤーは居るか
    //{
    //    int count = 0;
    //    for (int i = 0; i < 2; i++)
    //    {
    //        var player = GetPlayerDataKey((PlayerNumber)Enum.ToObject(typeof(PlayerNumber), i));
    //        var playerparam = player.GetComponent<PlayerParam>();
    //        if (!playerparam.IsMyTurn)
    //            //ターン出ないプレイヤーの数をカウント
    //            count++;
    //    }

    //    //カウントの数が同じであれば　チェンジ可能
    //    if (count >= 2) m_isChange = true;
    //}
    //プレイヤーの切り替え
    //public void ChangePlayerTurn(PlayerNumber nextTurnPlayer,GameObject myself)
    //{
    //    var myselfParam = myself.GetComponent<PlayerParam>();
    //    myselfParam.IsMyTurn = false;

    //    //逆引き
    //    var nextPlayer = GetPlayerDataKey(nextTurnPlayer);
    //    var nextPlayerparam = nextPlayer.GetComponent<PlayerParam>();
    //    nextPlayerparam.IsMyTurn = true;
    //    nextPlayerparam.PlayerState = PlayerState.Start;
    //}

    GameObject GetPlayerDataKey(PlayerNumber playerNum)//valueの値からkeyを取得
    {
        return m_playerData.First(x => x.Value == playerNum).Key;

    }

    public void SetPlayer(int Player)//プレイヤー生成
    {
        //読み込んだcsvからデータの最大数を取得
        int maxField = CSVConverter.Instance.csvSize();

        //intからPlayerNumberに変換
        PlayerNumber playerNum = (PlayerNumber)Enum.ToObject(typeof(PlayerNumber), Player);

        switch (playerNum)
        {
            case PlayerNumber.Player_1: PlayerGeneration(1, 1, 1); break;
            case PlayerNumber.Player_2: PlayerGeneration(2, 1, 7); break;
            case PlayerNumber.Player_3: PlayerGeneration(3, 7, 1); break;
            case PlayerNumber.Player_4: PlayerGeneration(4, 7, 7); break;
            case PlayerNumber.None: break;
        }
    }
    void PlayerGeneration(int playerNum, int x, int z)//プレイヤーの生成
    {
        var fieldDate = FieldDate.Instance;
        var troutSize = fieldDate.m_TroutSize;
        Vector3 pos = new Vector3(troutSize * x, troutSize + 2, troutSize * z);
        fieldDate.Player(x, z, Player.In);
        //複数モデルを使用する場合
        //var player = Instantiate(m_Player_[playerNum - 1], new Vector3(troutSize * x, troutSize + 2, troutSize * z), Quaternion.identity);
        //一つのモデルを使用する場合
        var player = Instantiate(m_Player, pos, Quaternion.identity);
        GameObject target = new GameObject("Target_" + playerNum);
        //プレイヤーの名前をプレイヤーの番号と一致
        player.name = "Player_" + playerNum.ToString();

        PlayerParamSetting(player, playerNum);
        player.GetComponent<PlayerParam>().PlayerNum = (PlayerNumber)Enum.ToObject(typeof(PlayerNumber), playerNum - 1);
        player.GetComponent<PlayerParam>().Target = target;
        //ディレクトリに追加　プレイヤーのオブジェクトとナンバー
        m_playerData.Add(player, (PlayerNumber)Enum.ToObject(typeof(PlayerNumber), playerNum - 1));
    }
    void PlayerParamSetting(GameObject player, int playerNum)
    {
        var param = player.GetComponent<PlayerParam>();
        param.PlayerNum = (PlayerNumber)Enum.ToObject(typeof(PlayerNumber), playerNum - 1);
        param.Target = GameObject.Find("Target_" + playerNum);
        param.PlayerState = PlayerState.Start;
        //1Pは自分のターンに設定
        //if (param.PlayerNum == PlayerNumber.Player_1) param.IsMyTurn = true;
        //else param.IsMyTurn = false;

    }



}
