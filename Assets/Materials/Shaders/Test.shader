Shader "CPTV/Test" {
	Properties {

		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormalMap ("Normal Map", 2D) = "bump" {}
		_Color("Color", Color) = (1,1,1,1)
		_Glossiness("Glossy", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_Power ("Level of Power", Range(-2, 2)) = -2.0
		_PowerColor ("Color of Power", Color) = (3.0, 0.0, 0.0, 1.0)
		_PowerDirection ("Direction of Power", Vector) = (0,1,0)
		_PowerDepth ("Depth of Power", Range(1,-1)) = 0

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

		float _Power;
		float4 _PowerColor;
		float4 _Color;
		float4 _PowerDirection;
		float _PowerDepth;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_NormalMap;
			float3 worldNormal;
			INTERNAL_DATA
		};
		
		void vert(inout appdata_full v)
		{
			float4 sn = mul(_PowerDirection, unity_ObjectToWorld);
			
			if (dot(v.normal, sn.xyz) >= _Power)
			{
				v.vertex.xyz += (sn.xyz + v.normal) * _PowerDepth * _Power;
			}
		}

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
			if (dot(WorldNormalVector(IN, o.Normal), _PowerDirection.xyz) <= _Power)
			{
				o.Albedo = _PowerColor.rgb;
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
