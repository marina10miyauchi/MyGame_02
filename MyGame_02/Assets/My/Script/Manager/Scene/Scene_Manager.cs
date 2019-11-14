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
//public class Fade
//{
//    GameObject m_fadeCanvas;

//    void FadeSetting(Transform parent)
//    {
//        FadeCanvasSet(parent);
//        CanvasAdd();
//        ImageSet(m_fadeCanvas.transform);
//    }
//    void FadeCanvasSet(Transform parent)//フェード用のキャンバス設定
//    {
//        //シーン切り替え用のオブジェクトを作成し親の指定　シーン切り替え用なので非表示に変更
//        m_fadeCanvas = new GameObject("Fade");
//        m_fadeCanvas.transform.parent = parent;
//        m_fadeCanvas.SetActive(false);
//    }
//    void CanvasAdd()//キャンバスの追加とそのキャンバスの設定追加
//    {
//        //キャンバスの追加、レンダーモードを2Dキャンバスに設定、
//        Canvas canvas = m_fadeCanvas.AddComponent<Canvas>();
//        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
//        //描画するときの優先度を高くする（より前に描画する）
//        canvas.sortingOrder = 999;
        
//        //キャンバス内のUIを画面に納まるように拡大縮小するようにする
//        m_fadeCanvas.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
//        //グラフィックに対してレイキャストを行えるようにする
//        m_fadeCanvas.AddComponent<GraphicRaycaster>();

//    }
//    void ImageSet(Transform parent)//フェード用イメージ画像の設定
//    {
//        //フェード用画像を作成し親をキャンバスに設定　イメージのカラーとUIのスクリーンサイズを設定
//        GameObject imageObj = new GameObject("Image");
//        imageObj.transform.parent = parent;
//        imageObj.AddComponent<Image>().color = Color.black;
//        imageObj.GetComponent<RectTransform>().sizeDelta = new Vector2(2000, 2000);
//    }


//}
