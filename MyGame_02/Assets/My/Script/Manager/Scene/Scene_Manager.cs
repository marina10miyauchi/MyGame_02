using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class Scene_Manager : SingletonMonoBehaviour<Scene_Manager>
{
    //シーンをディレクトリ管理
    Dictionary<Scene, string> m_SceneName = new Dictionary<Scene, string>()
    {
        { Scene.Title,"TitleScene" },
        {Scene.Select,"SelectScene" },
        {Scene.Game,"GameScene" },
        {Scene.Result,"ResultScene" },
        {Scene.End,"EndScene" },
        {Scene.Null,"" }
    };

    const string scene_build_path = "Assets/My/Scenes";

    //一つ前のシーンの名前
    string m_beforeSceneName = "";
    public string BefoeSceneName      //一つ前のシーンの名前を返却
    {
        get { return m_beforeSceneName; }
    }
    //現在のシーンの名前
    string m_currentSceneName = "";
    public string CurrentSceneName    //現在のシーンの名前を返却
    {
        get { return m_currentSceneName; }
    }
    //次のシーンの名前
    string m_nextSceneName = "";
    public string NextScene           //次のシーンの名前を返却
    {
        get { return m_nextSceneName; }
    }


    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    public void ChangeScene(Scene sceneName)//シーン切り替え
    {
        m_nextSceneName = m_SceneName[sceneName];
        SceneManager.LoadScene(m_nextSceneName);
        m_beforeSceneName = m_currentSceneName;
        m_currentSceneName = m_nextSceneName;
    }
    public void BackScene()//一つ前のシーンに切り替える
    {
        //valueからkeyを逆引き
        var scene = m_SceneName.First(x => x.Value == m_beforeSceneName).Key;
        ChangeScene(scene);
    }

    public void StopGameTimer()//ゲームを一時停止
    {
        Time.timeScale = 0.0f;
    }
    public void StartGameTimer()//止めていたゲームを再開
    {
        Time.timeScale = 1.0f;
    }

    public void GameEnd()//ゲーム終了
    {
        //開発画面用
        EditorApplication.isPlaying = false;
        //スタンドアローン（ビルド）
        Application.Quit();
    }
    void Retry()//シーン再読み込み（ゲームリトライ）
    {
        SceneManager.LoadScene(m_nextSceneName);
    }

    void Setting()
    {
        //自身を保持しているオブジェクトの名前を変更
        gameObject.name = "MySceneManager";
        //TODO:スクリプト分けをしてスクリプトをこれと同じオブジェクトにセット
        //m_fade = GetComponent<Fade>();
    }
    //キャンバスにシェーダーを設定用
    void Shader()
    {

    }

}

