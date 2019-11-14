using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField, Header("")]
    bool m_gameEnd=false;
    public bool GameEnd { get { return m_gameEnd; } set { m_gameEnd = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが終了していなければ処理終わり
        if (!GameEnd) return;

        Scene_Manager.Instance.ChangeScene(Scene.Result);
    }
    //アニメーションイベント用の関数↓
    
}
