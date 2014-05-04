Shader "Custom/UnlitTransparent" {
	Properties {
		_MainTex ("Color (RGB) Alpha (A)", 2D) = "white"
	}
	SubShader {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Emission = tex2D (_MainTex, IN.uv_MainTex).rgb;
			o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
