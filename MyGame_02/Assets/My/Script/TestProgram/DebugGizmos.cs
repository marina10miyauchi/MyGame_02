using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ギズモ
public class DebugGizmos : MonoBehaviour
{
    [SerializeField]
    Transform m_CameraPos;
    private void OnDrawGizmos()
    {
        CameraGizmos();
    }
    void CameraGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 1);
        Gizmos.DrawFrustum(m_CameraPos.position, 60f, 1000f, 0f, 1.6f);
    }
}
