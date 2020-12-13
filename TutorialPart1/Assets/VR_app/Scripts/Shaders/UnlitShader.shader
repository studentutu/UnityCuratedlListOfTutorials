Shader "Unlit/CustomUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",  Color)= (1,0,1,1)
    }
    SubShader
    {
        Tags 
		{ 
			"RenderType" = "Opaque"  // Opaque  transparent tranparentcutout
			"Queue" = "Geometry+10"  // Geometry  
			"PreviewType" = "cube"
			"DisableBatching" = "false"
			// "ForceNoShadowCasting" = "true"
			// "IgnoreProjector" = "true"
			"CanUseSpriteAtlas" = "false"
			"IsEmissive" = "true" 
			"LightMode" = "ForwardBase" // Meta ShadowCaster Deferred ForwardBase
		}
		//Blend SrcAlpha OneMinusSrcAlpha
			//Blend Zero One


        Pass
        {
            CGPROGRAM
            #pragma vertex vertexcustom
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            // Data from object 
            struct appdatacustom
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0; //  vector2(0-1,0-1)
                float3 worldnormal: NORMAL;
                float4 bakedLight : TEXCOORD1;
             };

            struct vertxToFragment
            {
                float3 worldnormal : TEXCOORD1;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            
            vertxToFragment vertexcustom (appdatacustom v)
            {
                vertxToFragment o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldnormal = v.worldnormal;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            // surface shader


            fixed4 frag (vertxToFragment i) : SV_Target
            {
                // sample the texture
                fixed4 col = float4(i.worldnormal, 1) ; //tex2D(_MainTex, i.uv)*_Color;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
