// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Post Outline" {
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "black" {}
	}
		SubShader
		{
		Blend SrcAlpha OneMinusSrcAlpha
			Pass
			{
				CGPROGRAM

				sampler2D _MainTex;
				float2 _MainTex_TexelSize;

				#pragma vertex vert
				#pragma fragment frag
				#include "UNITYCG.cginc"

				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uvs : TEXCOORD0;
				};

				v2f vert(appdata_base v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);

					//fix uvs
					o.uvs = o.pos.xy / 2 + 0.5;

					return o;
				}

				half4 frag(v2f i) : COLOR
				{
					int NumberOfIterations = 9;

				float TX_x = _MainTex_TexelSize.x;
				float TX_y = _MainTex_TexelSize.y;

				float ColorIntensityInRadius;

				if (tex2D(_MainTex, i.uvs.xy).r > 0)
				{
					discard;
				}

				for (int k = 0; k < NumberOfIterations; k += 1)
				{
					for (int j = 0; j < NumberOfIterations; j += 1)
					{
						ColorIntensityInRadius += tex2D(
							_MainTex,
							i.uvs.xy + float2((k - NumberOfIterations / 2)*TX_x, (j - NumberOfIterations / 2)*TX_y)).r;
					}
				}


				return ColorIntensityInRadius*half4(0, 1, 1, 1);
				}
					ENDCG
			}
			
		}
		

		FallBack "Diffuse"
}
