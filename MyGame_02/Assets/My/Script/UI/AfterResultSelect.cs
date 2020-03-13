using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    public void OnClick()
    {
        TransitionTarget();
    }
    void TransitionTarget()//遷移先
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
