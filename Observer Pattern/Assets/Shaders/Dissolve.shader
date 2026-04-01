Shader "Custom/Dissolve" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _DissolveAmount ("Dissolve Amount", Range(0,1)) = 0
        _Scale ("Noise Scale", Float) = 5
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        Cull Off

        CGPROGRAM
        #pragma surface surf Lambert

        float4 _Color;
        float _DissolveAmount;
        float _Scale;

        struct Input {
            float3 worldPos;
        };

        float noise(float3 p) {
            return frac(sin(dot(p, float3(12.9898, 78.233, 45.164))) * 43758.5453);
        }

        void surf (Input IN, inout SurfaceOutput o) {
            float n = noise(floor(IN.worldPos * _Scale));
            clip(n - _DissolveAmount);
            o.Albedo = _Color.rgb;
        }
        ENDCG
    }
}