using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleStageUI : MonoBehaviour
{

    [SerializeField, Header("表示ステージモデル")]
    GameObject[] m_stage;

    GameObject m_titleTurnStage;
    Vector3 m_pos = new Vector3(-4.0f, 0.0f, -4.0f);

    // Start is called before the first frame update
    void Start()
    {
        StageGenerate();
        m_titleTurnStage.transform.DOScale(1, 1);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime * 0.5f);
    }
    // ステージ生成
    void StageGenerate()
    {
        int rand = Random.Range(0, m_stage.Length);

        m_titleTurnStage= Instantiate(m_stage[rand], transform);
        m_titleTurnStage.transform.localPosition = m_pos;
    }
}
