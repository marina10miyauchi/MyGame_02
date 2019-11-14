using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    [SerializeField, Header("カメラに設定したいポストエフェクトの付いたマテリアル")]
    Material m_shaderMaterial;

    [SerializeField, Range(0, 1)]
    float m_noiseX;
    public float NoiseX { get { return m_noiseX; } set { m_noiseX = value; } }

    [SerializeField, Range(0, 1)]
    float m_rgbNoise;
    public float RGBNoise { get { return m_rgbNoise; } set { m_rgbNoise = value; } }

    [SerializeField, Range(0, 1)]
    float m_sinNoiseScale;
    public float SinNoiseScale { get { return m_sinNoiseScale; } set { m_sinNoiseScale = value; } }

    [SerializeField, Range(0, 10)]
    float m_sinNoiseWidth;
    public float SinNoiseWidth { get { return m_sinNoiseWidth; } set { m_sinNoiseWidth = value; } }

    [SerializeField]
    float m_sinNoiseOffset;
    public float SinNoiseOffset { get { return m_sinNoiseOffset; } set { m_sinNoiseOffset = value; } }

    [SerializeField]
    Vector2 m_offset;
    public Vector2 Offset { get { return m_offset; } set { m_offset = value; } }

    [SerializeField, Range(0, 2)]
    float m_scaleLineTail = 1.5f;
    public float ScaleLineTail { get { return m_scaleLineTail; } set { m_scaleLineTail = value; } }

    [SerializeField, Range(-10, 10)]
    float m_scanLineSpeed = 10;
    public float ScanLineSpeed { get { return m_scanLineSpeed; } set { m_scanLineSpeed = value; } }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        m_shaderMaterial.SetFloat("_NoiseX", m_noiseX);
        m_shaderMaterial.SetFloat("_RGBNoise", m_rgbNoise);
        m_shaderMaterial.SetFloat("_SinNoiseScale", m_sinNoiseScale);
        m_shaderMaterial.SetFloat("_SinNoiiseWidth", m_sinNoiseWidth);
        m_shaderMaterial.SetFloat("_SinNoiseOffset", m_sinNoiseOffset);
        m_shaderMaterial.SetFloat("_ScanLineTail", m_scaleLineTail);
        m_shaderMaterial.SetFloat("_ScanLineSpeed", m_scanLineSpeed);
        m_shaderMaterial.SetVector("_Offset", m_offset);
        Graphics.Blit(source, destination, m_shaderMaterial);
    }

}
