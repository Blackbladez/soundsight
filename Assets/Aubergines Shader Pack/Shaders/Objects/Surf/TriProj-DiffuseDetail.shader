Shader "Aubergine/Objects/Surf/TriProj-DiffuseDetail" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_DetailTex ("Detail (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue" = "Geometry" "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
			#include "../../Includes/Aubergine_Lights.cginc"
			#pragma exclude_renderers flash
			#pragma surface surf Aub_Lambert

			sampler2D _MainTex, _DetailTex;
			float4 _MainTex_ST;

			struct Input {
				float3 worldPos;
				float3 worldNormal;
			};

			void surf (Input IN, inout SurfaceOutput o) {
				fixed3 bw = ((abs(IN.worldNormal)) - 0.2) * 7;
				//fixed3 bw = abs(IN.worldNormal);
				bw = max(bw, 0);
				bw /= (bw.x + bw.y + bw.z).xxx;

				float2 uvx = (IN.worldPos.yz - _MainTex_ST.zw) * _MainTex_ST.xy;
				float2 uvy = (IN.worldPos.xz - _MainTex_ST.zw) * _MainTex_ST.xy;
				float2 uvz = (IN.worldPos.xy - _MainTex_ST.zw) * _MainTex_ST.xy;

				fixed4 c1 = tex2D(_MainTex, uvx);
				fixed4 c2 = tex2D(_MainTex, uvy);
				fixed4 c3 = tex2D(_MainTex, uvz);
				fixed3 d1 =  tex2D(_DetailTex, uvx).rgb;
				fixed3 d2 =  tex2D(_DetailTex, uvy).rgb;
				fixed3 d3 =  tex2D(_DetailTex, uvz).rgb;

				fixed4 col = (c1 * bw.xxxx) + (c2 * bw.yyyy) + (c3 * bw.zzzz);
				fixed3 det = (d1 * bw.xxx) + (d2 * bw.yyy) + (d3 * bw.zzz);

				o.Albedo = col.rgb * det.rgb * 2;
				o.Alpha = col.a;
			}
		ENDCG
	} 
	FallBack "Diffuse"
}