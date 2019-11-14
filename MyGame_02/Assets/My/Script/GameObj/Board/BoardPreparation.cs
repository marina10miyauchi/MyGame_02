using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPreparation : MonoBehaviour
{
    BoardParam m_param;
    // Start is called before the first frame update
    void Start()
    {
        m_param =GetComponent<BoardParam>();
    }

    // Update is called once per frame
    public void Preparation()
    {
        if (m_param.OnThePlayre)  //プレイヤーが乗っているか
        {
            //移動方向の指定のブロック表示
            m_param.DestinationBrock.SetActive(true);

            if (m_param.Destination != Destination.None)
            {
                m_param.BoardState = BoardState.Moving;
            }
        }
        else
        {
            m_param.BoardState = BoardState.Stop;
        }
    }
    
}
