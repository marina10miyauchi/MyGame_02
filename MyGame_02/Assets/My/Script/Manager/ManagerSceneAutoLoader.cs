using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneAutoLoader //ManagerSceneを自動的にロード
{
    //ゲーム開始時（シーン読み込み前）に絶対に実行　RuntimeInitializeLoadTypeで実行するタイミングの指定
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadManagerScene()
    {
        //名前の指定
        string managerSceneName = "ManagerScene";
        //指定したシーン(managerScene)が有効でない時（まだ読み込んでいない時）だけ実行
        if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
        {
            //シーンに新しいシーンの追加
            SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);
        }
    }
}
