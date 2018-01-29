Shader "Custom/Test" {
	Properties {

		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormalMap ("Normal Map", 2D) = "bump" {}
		_Color("Color", Color) = (1,1,1,1)
		_Glossiness("Glossy", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_Blood ("Level of Blood", Range(-2, 2)) = -2.0

		_BloodColor ("Color of Blood", Color) = (3.0, 0.0, 0.0, 1.0)
		_BloodDirection ("Direction of Blood", Vector) = (0,1,0)
		_BloodDepth ("Depth of Blood", Range(1,-1)) = 0

	}
	SubShader
	{

		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0
		sampler2D _MainTex;
		sampler2D _NormalMap;

		half _Glossiness;
		half _Metallic;

		float _Blood;
		float4 _BloodColor;
		float4 _Color;
		float4 _BloodDirection;
		float _BloodDepth;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_NormalMap;
			float3 worldNormal;
			INTERNAL_DATA
		};
		
		void vert(inout appdata_full v)
		{
			float4 sn = mul(_BloodDirection, unity_WorldToObject);
			
			if (dot(v.normal, sn.xyz) >= _Blood)
			{
				v.vertex.xyz += (sn.xyz + v.normal) * _BloodDepth * _Blood;
			}
		}

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
			if (dot(WorldNormalVector(IN, o.Normal), _BloodDirection.xyz) <= _Blood)
			{
				o.Albedo = _BloodColor.rgb;
			}
			else
			{
				o.Albedo = c.rgb * _Color;
			}
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
