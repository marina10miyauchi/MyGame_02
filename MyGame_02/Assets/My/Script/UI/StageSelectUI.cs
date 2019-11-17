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
    //regionのブロックの終わり

    void Arrage()
    {
        //表示するスプライトを円形に均等に並べるための角度計算
        float splitAngle = 360 / transform.childCount;
        var rect = transform as RectTransform;

        for(int elementID = 0; elementID < transform.childCount; elementID++)
        {
            var child = transform.GetChild(elementID) as RectTransform;
            float currentAngle = splitAngle * elementID + m_offsetAngle;

            child.anchoredPosition = new Vector2(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * m_radius;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
