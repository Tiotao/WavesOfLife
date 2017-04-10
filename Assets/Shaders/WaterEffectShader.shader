Shader "Custom/WaterEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		// _NoiseTex ("Noise Texture", 2D) = "white" {}
		// _DistortionAmount ("Distortion Amount", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			// sampler2D _NoiseTex;
			// float _DistortionAmount;

			fixed4 frag (v2f IN) : SV_Target
			{
				
				float2 offset = float2( (sin(IN.vertex.y/100 + _Time[1] / 2)) / 100, 
										(sin(IN.vertex.x/100 + _Time[1] / 2)) / 100);

				// float2 offset = float2(
				// 	tex2D(_NoiseTex, float2(i.vertex.y / 10000 * _DistortionAmount, _Time[1] / 1000)).r, 
				// 	tex2D(_NoiseTex, float2(_Time[1] / 1000, i.vertex.x / 10000 * _DistortionAmount)).r
				// );

				// offset -= 0.5;
				
				fixed4 col = tex2D(_MainTex, IN.uv + offset);

				// fixed4 col = tex2D(_MainTex, IN.uv);
				
				return col;
			}
			ENDCG
		}
	}
}
