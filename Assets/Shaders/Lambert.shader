  Shader "Custom/Lambert" {
    Properties {
      _Color ("Color", COLOR) = (1,1,1,1)
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      
      struct Input {
          float2 uv_MainTex;
      };
      
      half4 _Color;
      
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = _Color.rgb;
      }
      ENDCG
    }
    Fallback "Diffuse"
  }