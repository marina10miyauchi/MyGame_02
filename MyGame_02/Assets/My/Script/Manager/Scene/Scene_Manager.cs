using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class Scene_Manager : SingletonMonoBehaviour<Scene_Manager>
{
    #region

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

    Fade m_fade;

    //一つ前のシーンの名前
    string m_beforeSceneName = "";
    //一つ前のシーンの名前を返却
    public string BefoeSceneName      
    { get { return m_beforeSceneName; } }
    //現在のシーンの名前
    string m_currentSceneName = "";
    //現在のシーンの名前を返却
    public string CurrentSceneName    
    { get { return m_currentSceneName; } }

    //次のシーンの名前
    string m_nextSceneName = "";
    //次のシーンの名前を返却
    public string NextScene { get { return m_nextSceneName; } }


    #endregion

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        m_fade = FindObjectOfType<Fade>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameEnd();
    }
    //シーン切り替え
    public void ChangeScene(Scene sceneName)
    {
        StartCoroutine(FadeScreen(sceneName));
    }
    //一つ前のシーンに切り替える
    public void BackScene()
    {
        //valueからkeyを逆引き
        var scene = m_SceneName.First(x => x.Value == m_beforeSceneName).Key;
        ChangeScene(scene);
    }
    //ゲームを一時停止
    public void StopGameTimer()
    {
        Time.timeScale = 0.0f;
    }
    //止めていたゲームを再開
    public void StartGameTimer()
    {
        Time.timeScale = 1.0f;
    }

    public void GameEnd()//ゲーム終了
    {
        //開発画面用
        #if UNITY_EDITOR
             EditorApplication.isPlaying = false;
        //ゲーム（ビルド）
        #elif UNITY_STANDALONE
            Application.Quit();
        #endif
    }
    //シーン再読み込み（ゲームリトライ）
    void Retry()
    {
        SceneManager.LoadScene(m_nextSceneName);
    }
    //フェードをしながらシーン切り替え
    IEnumerator FadeScreen(Scene nextScene)
    {
        m_fade.FadeIn();
        yield return new WaitForSeconds(1.5f);
        m_nextSceneName = m_SceneName[nextScene];
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(m_nextSceneName);
        m_beforeSceneName = m_currentSceneName;
        m_currentSceneName = m_nextSceneName;

        m_fade.FadeOut();
    }

}

