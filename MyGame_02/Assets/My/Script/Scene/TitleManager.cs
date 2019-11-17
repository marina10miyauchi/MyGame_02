using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    bool m_click;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartBGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_click)
        {
            Scene_Manager.Instance.ChangeScene(Scene.Select);
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_click = true;
        }
    }
    IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayBGMByName("GameTitle");

    }
}
