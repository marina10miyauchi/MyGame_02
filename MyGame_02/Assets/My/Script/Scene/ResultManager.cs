using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField, Header("行動回数表示テキスト")]
    GameObject m_CountText;
    [SerializeField, Header("クリア時間表示テキスト")]
    GameObject m_TimeText;

    //Text m_countResult;
    //Text m_timeResult;

    // Start is called before the first frame update
    void Start()
    {
        var m_countResult = m_CountText.GetComponent<TMPro.TextMeshProUGUI>();
        var m_timeResult = m_TimeText.GetComponent<TMPro.TextMeshProUGUI>();
        m_countResult.text = "ActCount : " + GameData.Instance.ActionCount.ToString();
        //m_timeResult.text = "ClearTime : ";
    }

    // Update is called once per frame
    void Update()
    {
        GameData.Instance.Reset();
    }
    void SetResult()
    {

    }
}
