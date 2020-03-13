using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelectUI : UIBehaviour/*,ILayoutGroup*/
{

    [SerializeField]
    float m_radius = 100;
    [SerializeField]
    float m_offsetAngle;
    public float OffsetAngle { get { return m_offsetAngle; } set { m_offsetAngle = value; } }
    public float TurnAngle { get { return m_tarnAngle; } private set { m_tarnAngle = value; } }

    float m_tarnAngle = 0;
    //protected override void OnValidate()
    //{
    //    base.OnValidate();
    //    Arrage();
    //}

    ////要素数が変わると自動的に呼ばれる
    //#region IlayoutController implementation;
    //public void SetLayoutHorizontal() { }
    //public void SetLayoutVertical()
    //{
    //    Arrage();
    //}

    //#endregion; 
    ////regionのブロックの終わり
    void Arrage()
    {
        //表示するスプライトを円形に均等に並べるための角度計算
        m_tarnAngle = 360 / transform.childCount;
        var rect = transform as RectTransform;

        for(int elementID = 0; elementID < transform.childCount; elementID++)
        {
            var child = transform.GetChild(elementID) as RectTransform;
            float currentAngle = m_tarnAngle * elementID + m_offsetAngle;

            child.anchoredPosition = new Vector2(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * m_radius;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Arrage();
    }
}
