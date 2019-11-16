using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMeasurement : MonoBehaviour
{
    int m_minute;
    float m_second;

    [SerializeField,Header("Playerのオブジェクト")]
    GameObject m_Player;    //プレイヤーがゴールしたかを取得するため

    PlayerParam m_playerParam;

    // Start is called before the first frame update
    void Start()
    {
        m_playerParam = m_Player.GetComponent<PlayerParam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_playerParam.IsGoal)
            Timer();
    }
    void Timer()
    {
        m_second += Time.deltaTime;
        if (m_second >= 60f)//60秒立ったか
        {
            m_minute++;
            m_second = m_second - 60;
        }
    }
}
