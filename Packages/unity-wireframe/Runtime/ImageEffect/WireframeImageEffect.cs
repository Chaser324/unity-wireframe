using UnityEngine;
using System.Collections;

namespace SuperSystems.ImageEffects
{

[ExecuteInEditMode]
public class WireframeImageEffect : MonoBehaviour
{
    public enum WireframeType
    {
        None = 0,
        Solid,
        ShadedUnlit,
        Transparent,
        TransparentCulled,
        COUNT
    }

    [Header("Replacement Shader")]
    public WireframeType wireframeType = WireframeType.None;
    public string replacementTag = "RenderType";
    public bool cameraBackgroundMatchesBaseColor = true;

    [Header("Wireframe Shader Properties")]
    [Range(0, 800)]
    public float wireThickness = 600;

    [Range(0, 20)]
    public float wireSmoothness = 3;

    public Color wireColor = Color.green;
    public Color baseColor = Color.black;
    public float maxTriSize = 25.0f;

    private Color initialClearColor;
    private CameraClearFlags initialClearFlag;

    private Camera cam;
    private WireframeType lastWireframeType = WireframeType.None;

    protected void OnEnable()
    {
        cam = GetComponent<Camera>();
        initialClearFlag = cam.clearFlags;
        initialClearColor = cam.backgroundColor;
    }

    protected void OnDisable()
    {
        ResetCamera();
        lastWireframeType = WireframeType.None;
    }

    protected void Update()
    {
        Shader.SetGlobalFloat("_WireThickness", wireThickness);
        Shader.SetGlobalFloat("_WireSmoothness", wireSmoothness);
        Shader.SetGlobalColor("_WireColor", wireColor);
        Shader.SetGlobalColor("_BaseColor", baseColor);
        Shader.SetGlobalFloat("_MaxTriSize", maxTriSize);

        if (wireframeType != WireframeType.None && cameraBackgroundMatchesBaseColor)
        {
            cam.backgroundColor = baseColor;
            cam.clearFlags = CameraClearFlags.SolidColor;
        }

        ApplyShader();
    }

    private void ApplyShader()
    {
        if (wireframeType != lastWireframeType)
        {
            lastWireframeType = wireframeType;

            switch (wireframeType)
            {
                case WireframeType.Solid:
                    cam.SetReplacementShader(Shader.Find("hidden/SuperSystems/Wireframe-Global"), replacementTag);
                    break;
                case WireframeType.ShadedUnlit:
                    cam.SetReplacementShader(Shader.Find("hidden/SuperSystems/Wireframe-Shaded-Unlit-Global"), replacementTag);
                    break;
                case WireframeType.Transparent:
                    cam.SetReplacementShader(Shader.Find("hidden/SuperSystems/Wireframe-Transparent-Global"), replacementTag);
                    break;
                case WireframeType.TransparentCulled:
                    cam.SetReplacementShader(Shader.Find("hidden/SuperSystems/Wireframe-Transparent-Culled-Global"), replacementTag);
                    break;
                default:
                    ResetCamera();
                    break;
            }
        }
    }

    private void ResetCamera()
    {
        cam.ResetReplacementShader();
        cam.backgroundColor = initialClearColor;
        cam.clearFlags = initialClearFlag;
    }
}

}