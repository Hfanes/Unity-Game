Shader "Custom/GrassAnimate" {
	Properties {
	  _Color ("Tint", Color) = (1,1,1,1)
      _MainTex ("Texture", 2D) = "white" {}
	  [MaterialToggle] _("isToggle", Float) = 0
	  _windSpeed ("Wind Speed", Range(-10,10)) = 1
      _xAngle ("Wind X Dir", Range(-10,10)) = 2
	  _zAngle ("Wind Z Dir", Range(-10,10)) = 2
	  _initAngle ("Initial Dir", Range(-10,10)) = 0
	  _MinY ("MinY", Float) = 0
	  _MaxY ("MaxY", Float) = 2

	  _WaveScale ("WaveScale", Range(0,100)) = 1
	  _WaveSpeed ("WaveSpeed", Range(0,100)) = 1
	  _GrassToughness ("GrassToughness", Range(-10,10)) = 0.1
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
	  Cull Off
      CGPROGRAM
      //#pragma surface surf Lambert vertex:vert addshadow
	  #pragma surface surf NoLighting vertex:vert addshadow
      struct Input {
          float2 uv_MainTex;
      };
	  float _MinY;
	  float _MaxY;
	  float2 rorateX(float angle, float radius){
		float ca = cos(angle);
		float sa = sin(angle);
		return float2(radius * sa,radius - (radius * ca));
	  }
	  float2 rorateZ(float angle, float radius){
		float ca = cos(angle);
		float sa = sin(angle);
		return float2(radius * sa,radius * ca);
	  }
      float _xAngle;
	  float _zAngle;
	  float _initAngle;
	  float _windSpeed;
	  float _WaveScale;
	  float _WaveSpeed;
	  float _GrassToughness;
      void vert (inout appdata_full v) {
		  float3 ori = v.vertex.xyz;
		  float waveMul = sin((_Time + ori.z/_WaveScale) * _WaveSpeed) * _GrassToughness;
          v.vertex.xy -= (_windSpeed * rorateX(_initAngle + waveMul + _xAngle * (v.vertex.y/_MaxY), v.vertex.y));
		  float radius = v.vertex.x - ori.x;
		  v.vertex.zx += rorateZ(_zAngle, radius);
		  v.vertex.x -= radius;
      }
	  fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
	  {
		  fixed4 c;
		  c.rgb = s.Albedo;
		  c.a = s.Alpha;
		  return c;
	  }
	  
	  float4 _Color;
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }