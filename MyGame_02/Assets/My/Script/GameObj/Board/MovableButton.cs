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

    [SerializeField]
    bool m_Stop=false;

    void Start()
    {
        m_param = transform.parent.GetComponentInParent<BoardParam>();
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        if (m_Stop) return;

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
    private void OnTriggerStay(Collider other)
    {
        m_Stop = true;
    }
    private void OnTriggerExit(Collider other)
    {
        m_Stop = false;
    }
}