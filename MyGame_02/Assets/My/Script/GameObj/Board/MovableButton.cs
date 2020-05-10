using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 移動する方向のタイプ
/// </summary>
enum ButtonType
{
    Right,
    Left,
    Forward,
    Back
}
public class MovableButton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField,Header("移動ボタンの種類")]
    ButtonType m_button;

    BoardParam m_param;
    PlayerStateChecker m_stateChange;

    void Start()
    {
        m_param = transform.parent.GetComponentInParent<BoardParam>();
        transform.parent.gameObject.SetActive(false);
    }
    //マウスでクリックされたときの処理
    public void OnPointerClick(PointerEventData pointerData)
    {
        
        if (CheckNoMoving()) return;
        SoundManager.Instance.PlaySEByName("move");
        m_param.Player.GetComponentInChildren<PlayerStateChecker>().ChangeState(PlayerState.WithBoard);
        m_param.Player.transform.parent = m_param.gameObject.transform;
        BoardControl();
    }
    /// <summary>
    /// ボード移動方向操作
    /// </summary>
    void BoardControl()
    {
        switch (m_button)
        {
            case ButtonType.Right:
                m_param.Destination = Destination.Right;
                break;
            case ButtonType.Left:
                m_param.Destination = Destination.Left;
                break;
            case ButtonType.Forward:
                m_param.Destination = Destination.Forward;
                break;
            case ButtonType.Back:
                m_param.Destination = Destination.Back;
                break;
        }
    }
    /// <summary>
    /// 移動不可能チェック
    /// </summary>
    /// <returns>true= 動けない  false= 動ける </returns>
    bool CheckNoMoving()
    {
        var pos = transform.position;
        var field = FieldDate.Instance;
        if (field.Fields(pos.x, pos.z) == Field.Wall) return true;
        else if (field.Boards(pos.x, pos.z) == Board.Exists) return true;
        else return false;
    }
}