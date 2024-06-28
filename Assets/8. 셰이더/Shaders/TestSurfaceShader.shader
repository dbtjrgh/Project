Shader "Custom/TestSurfaceShader"
{
    Properties // 이 셰이더에서 사용할 변수 선언
    {   // _변수명 ([Inspector에서 표시될 이름], 자료형) = [초기값 할당] 라인의 끝에선 ; 대신 줄바꿈으로 구분 
        _MainTex ("Main Texture", 2D) = "white" {}
        OverlabTex("Overlab Texture", 2D) = "gray" {}
        _colorAmount("Color Amount", Range(0,1)) = 1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        // Opaque -> 투명도 적용 x
        // Transparent -> 투명도 적용 o
        // Cutout -> 투명도가 0.5 이하가 되면 안 보임

        LOD 200 // Level of detail. 200 : Diffuse Level

        CGPROGRAM
        // c for graphics 문법이 사용된 영역

        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert
        //#pragma vertex vert // 정점 셰이딩 라이브러리 함수를 사용하겠다
        //#pragma fragment frag // 픽셸 셰이딩 라이브러리 함수를 사용하겠다

        // Use shader model 3.0 target, to get nicer looking lighting

        sampler2D _MainTex;
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            float2 uv_MainTex; // uv 매핑을 적용한 _MainTex 색 정보
            float2 uvOverlabTex;
            float4 screenPos;
        };

        // _Time : float4, 즉 4차원의 값으로 제공이 되는데,
        // x : t/20 , y : t, z : t*2, w : t*3

        void surf (Input IN, inout SurfaceOutput o)
        {   // 표면 셰이더에 텍스쳐 색을 적용
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;
            // o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;

            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10,5);

            o.Albedo *= tex2D(OverlabTex, screenUV + +_Time.x).rgb;
        }
        ENDCG
    }

    FallBack "Standard"
}