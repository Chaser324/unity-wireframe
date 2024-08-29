Shader "hidden/SuperSystems/Wireframe-Global"
{
	SubShader
	{
		// Each color represents a meter.

		Tags { "RenderType"="Opaque" }

		Pass
		{
			// Wireframe shader based on the the following
			// http://developer.download.nvidia.com/SDK/10/direct3d/Source/SolidWireframe/Doc/SolidWireframe.pdf

			CGPROGRAM
			#pragma vertex vert
			#pragma geometry geom
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "../Wireframe.cginc"

			ENDCG
		}
	}
}
