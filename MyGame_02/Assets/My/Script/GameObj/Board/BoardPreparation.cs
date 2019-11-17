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
        //プレイヤーが乗っているてかつプレイヤーの状態が停止状態
        if (m_param.OnThePlayre
            &&m_param.Player.GetComponent<PlayerParam>().PlayerState==PlayerState.Idle)  
        {
            var pos = transform.localPosition;
            if(FieldDate.Instance.Player(Mathf.RoundToInt(pos.x),Mathf.RoundToInt(pos.z))==Player.In)
            //移動方向の指定のブロック表示
            m_param.DestinationBrock.SetActive(true);

            if (m_param.Destination != Destination.None)
            {
                m_param.BoardState = BoardState.Moving;
            }
        }
        else if(!m_param.OnThePlayre)
        {
            m_param.BoardState = BoardState.Stop;
        }
    }
    
}
