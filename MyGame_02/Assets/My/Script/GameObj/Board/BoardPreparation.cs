using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPreparation : MonoBehaviour
{
    BoardParam m_param;
    // Start is called before the first frame update
    void Start()
    {
        m_param = GetComponent<BoardParam>();
    }

    // Update is called once per frame
    public void Preparation()
    {
        var pos = transform.localPosition;
        //プレイヤーが自身の上に乗っている状態かチェック
        if (FieldDate.Instance.Player(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)) != Player.In)
        {
            m_param.StateChange(BoardState.Stop);
            return;
        }

        //移動方向の指定のブロック表示
        m_param.DestinationBrock.SetActive(true);
            //移動方向が何か選択されたら
            if (m_param.Destination != Destination.None)
            {
                m_param.StateChange(BoardState.Moving);
            m_param.DestinationBrock.SetActive(false);

        }
    }
}
