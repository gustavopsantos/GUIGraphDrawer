Shader "Unlit/InspectorGraphDrawer/Graph"
{
    Properties {}
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	    Blend SrcAlpha OneMinusSrcAlpha
	    Lighting Off ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Bars
            float GraphMaxValue;
            int GraphValuesLength;
            float GraphValues[1023];

            // Colors
            int GraphColorsLength;
            float GraphColorsThresholds[8];
            float4 GraphColors[8];

            fixed4 frag(v2f i) : SV_Target
            {
                float pixelValue = i.uv.y * GraphMaxValue;
                float graphValue = GraphValues[floor(i.uv.x * GraphValuesLength)];

                if (pixelValue > graphValue)
                {
                    discard;
                }

                float4 color = float4(1, 1, 1, 1);
                for (int k = 0; k < GraphColorsLength; k++)
                {
                    if (graphValue >= GraphColorsThresholds[k])
                    {
                        color = GraphColors[k];
                    }
                }

                return color;
            }
            ENDCG
        }
    }
}