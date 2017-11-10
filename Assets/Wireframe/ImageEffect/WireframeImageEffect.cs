using UnityEngine;
using System.Collections;

namespace SuperSystems.ImageEffects
{

public class WireframeImageEffect : MonoBehaviour
{
    public enum WireframeType
    {
        None = 0,
        Solid,
        Transparent,
        TransparentCulled,
        COUNT
    }

    public WireframeType wireframeType = WireframeType.None;
    public bool setCameraClearColor = true;
    public float wireThickness = 100;
    public Color wireColor = Color.green;
    public Color baseColor = Color.black;
    public float maxTriSize = 25.0f;
    public string replacementTag = "RenderType";

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
        Shader.SetGlobalColor("_WireColor", wireColor);
        Shader.SetGlobalColor("_BaseColor", baseColor);
        Shader.SetGlobalFloat("_MaxTriSize", maxTriSize);

        if (wireframeType != WireframeType.None)
        {
            if (setCameraClearColor)
            {
                cam.backgroundColor = baseColor;
                cam.clearFlags = CameraClearFlags.SolidColor;
            }
            else
            {
                cam.backgroundColor = initialClearColor;
                cam.clearFlags = initialClearFlag;
            }
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
                    cam.SetReplacementShader(Shader.Find("Hidden/SuperSystems/Wireframe-Global"), replacementTag);
                    break;
                case WireframeType.Transparent:
                    cam.SetReplacementShader(Shader.Find("Hidden/SuperSystems/Wireframe-Transparent-Global"), replacementTag);
                    break;
                case WireframeType.TransparentCulled:
                    cam.SetReplacementShader(Shader.Find("Hidden/SuperSystems/Wireframe-Transparent-Culled-Global"), replacementTag);
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