﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンの種類
/// </summary>
public enum ButtonCategory
{
    Retry,
    SelectStage,
    GameEnd
}

public class AfterResultSelect : MonoBehaviour
{
    [SerializeField,Header("ボタン")]
    ButtonCategory m_Button;

    /// <summary>
    /// クリック処理
    /// </summary>
    public void OnClick()
    {
        SoundManager.Instance.PlaySEByName("Click");
        TransitionTarget();
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    void TransitionTarget()
    {
        switch (m_Button)
        {
            case ButtonCategory.Retry:
                Scene_Manager.Instance.ChangeScene(Scene.Game);
                break;
            case ButtonCategory.SelectStage:
                Scene_Manager.Instance.ChangeScene(Scene.Select);
                break;
            case ButtonCategory.GameEnd:
                Scene_Manager.Instance.ChangeScene(Scene.End);
                break;
        }
    }
}
