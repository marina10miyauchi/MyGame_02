using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    void Start()
    {
        m_param = transform.parent.GetComponentInParent<BoardParam>();
    }

    public void OnPointerClick(PointerEventData pointerData)//マウスでクリックされたときの処理
    {
        
        if (CheckNoMoving()) return;

        m_param.Player.GetComponent<PlayerParam>().IsMoving = true;
        m_param.Player.transform.parent = m_param.gameObject.transform;
        BoardControl();
    }
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
    bool CheckNoMoving()//動けないかのチェック
    {
        var pos = transform.position;
        var field = FieldDate.Instance;
        if (field.Fields(pos.x, pos.z) == Field.Wall) return true;
        else if (field.Boards(pos.x, pos.z) == Board.Exists) return true;
        else return false;
    }
}