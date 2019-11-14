//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerChange : MonoBehaviour
//{


//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    void NextTurnSet(PlayerNumber currentPlayer)
//    {
//        m_nextTurnPlayer = m_currentTurnPlayer + 1;
//    }

//    PlayerNumber NextTurnPlayer()//次のタ-ンのプレイヤー
//    {
//        //次のプレイヤー番号が現在場にいるプレイヤーよりも大きくなってしまったら
//        if ((int)m_nextTurnPlayer > 2)
//            m_nextTurnPlayer = PlayerNumber.Player_1;
//        return m_nextTurnPlayer;
//    }
//    public void ChangePlayerTurn()
//    {
//        if (m_isChange)
//        {
//            ChangePlayerTurn(NextTurnPlayer(), GetPlayerDataKey(m_currentTurnPlayer));
//            NextTurnSet(m_currentTurnPlayer);
//        }
//    }

//    public void CheckPlayer()//プレイヤーのターンが終了したかをチェックし続ける
//    {
//        var player = GetPlayerDataKey(CurrentPlayerTurn());
//        var playerParam = player.GetComponent<PlayerParam>();

//        if (!playerParam.ActionEnd) return;
//        var nextPlayer = playerParam.PlayerNum + 1;
//        //次のプレイヤーの数が現在場にいるプレイヤー数を超えたら
//        if ((int)nextPlayer > m_playerData.Count)
//            nextPlayer = PlayerNumber.Player_1;
//        ChangePlayerTurn(nextPlayer, player);
//    }
//    //現在誰のターンか？
//    public PlayerNumber CurrentPlayerTurn()
//    {
//        int count = 0;
//        var currentPlayer = PlayerNumber.None;
//        for (int i = 0; i < 2; i++)
//        {
//            var player = GetPlayerDataKey((PlayerNumber)Enum.ToObject(typeof(PlayerNumber), i));
//            var playerparam = player.GetComponent<PlayerParam>();
//            if (!playerparam.IsMyTurn)
//                //ターン出ないプレイヤーの数をカウント
//                count++;
//        }
//        return currentPlayer;
//    }
//    void TurnCheck()
//    {
//        int count = 0;
//        for (int i = 0; i < 2; i++)
//        {
//            var player = GetPlayerDataKey((PlayerNumber)Enum.ToObject(typeof(PlayerNumber), i));
//            var playerparam = player.GetComponent<PlayerParam>();
//            if (!playerparam.IsMyTurn)
//                //ターン出ないプレイヤーの数をカウント
//                count++;
//        }

//        //カウントの数が同じであれば　チェンジ可能
//        if (count >= 2) m_isChange = true;

//    }

//    PlayerNumber CurrentTurn()//現在のターンのプレイヤーを返す
//    {

//        for (int i = 0; i < 2; i++)
//        {
//            var player = GetPlayerDataKey((PlayerNumber)Enum.ToObject(typeof(PlayerNumber), i));
//            var playerparam = player.GetComponent<PlayerParam>();
//            if (playerparam.IsMyTurn)
//                m_currentTurnPlayer = playerparam.PlayerNum;
//            else
//            {
//                m_isChange = true;
//            }
//        }
//        return m_currentTurnPlayer;
//    }

//    //プレイヤーの切り替え
//    public void ChangePlayerTurn(PlayerNumber nextTurnPlayer, GameObject myself)
//    {
//        var myselfParam = myself.GetComponent<PlayerParam>();
//        myselfParam.IsMyTurn = false;
//        myselfParam.PlayerState = PlayerState.End;

//        //逆引き
//        var nextPlayer = GetPlayerDataKey(nextTurnPlayer);
//        var nextPlayerparam = nextPlayer.GetComponent<PlayerParam>();
//        nextPlayerparam.IsMyTurn = true;
//        nextPlayerparam.PlayerState = PlayerState.Start;
//    }

//    GameObject GetPlayerDataKey(PlayerNumber playerNum)//valueの値からkeyを取得
//    {
//        return m_playerData.First(x => x.Value == playerNum).Key;

//    }



//}
