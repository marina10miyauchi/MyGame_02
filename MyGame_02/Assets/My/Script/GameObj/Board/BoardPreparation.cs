using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPreparation : MonoBehaviour
{
    BoardParam m_param;
    void Start()
    {
        m_param = GetComponent<BoardParam>();
    }
    //待機状態の処理
    public void Preparation()
    {
        var pos = transform.localPosition;
        //プレイヤーが自身の上に乗っている状態かチェック
        if (FieldDate.Instance.Player(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)) != Player.In)
        {
            m_param.StateChange(BoardState.Stop);
            m_param.DestinationBrock.SetActive(false);

            return;
        }
        else
        {
            //移動方向の指定のブロック表示
            m_param.DestinationBrock.SetActive(true);
            //移動方向が何か選択されたら
            if (m_param.Destination != Destination.None)
            {
                m_param.Player.transform.parent = transform;
                m_param.StateChange(BoardState.Moving);
                m_param.DestinationBrock.SetActive(false);
            }
        }
    }
}
