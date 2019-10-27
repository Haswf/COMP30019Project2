Shader "Custom/Fog"
{
	Properties
	{
		// choose textures and color
		[Header(Textures and color)]
		_MainTex("Fog texture", 2D) = "white" {}
		// Add a mask to modify the appearence of the fog texture
		_Mask("Mask", 2D) = "white" {}
		_Color("Color", color) = (1., 1., 1., 1.)
			// velocity is used for texture moving 
			[Header(Behaviour)]
			_Velocity("Velocity", float) = 1.
	}

		SubShader
			{
				Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
				// display destination color without modify the source color
				Blend SrcAlpha OneMinusSrcAlpha
				// ZWrite Off is for drawing semitransparent effect
				ZWrite Off
				// Disable Culling, to show all faces of the object
				Cull Off

				Pass
				{
					CGPROGRAM
					#pragma vertex vert
					#pragma fragment frag

					#include "UnityCG.cginc"

					struct v2f {
						float4 pos : SV_POSITION;
						fixed4 vertColor : COLOR0;
						float2 uv : TEXCOORD0;
						float2 uv2 : TEXCOORD1;
					};

					sampler2D _MainTex;
					float4 _MainTex_ST;
					// paas position, tangent, normal and four texture coordinates and color in the vert function
					v2f vert(appdata_full v)
					{
						v2f o;
						o.pos = UnityObjectToClipPos(v.vertex);
						// TRANSFORM_TEX is used to make sure texture scale and offset is applied correctly
						// this is from UnityCG.cginc
						o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
						o.uv2 = v.texcoord;
						o.vertColor = v.color;
						return o;
					}
					// sampler2D is bound to a texture unit.
					sampler2D _Mask;
					float _Velocity;
					fixed4 _Color;
					// returns a type of fixed4 (low precision RGBA color)
					fixed4 frag(v2f i) : SV_Target
					{
						// makes uv move and return the new uv
						float2 uv = i.uv + _Velocity * _Time.x;
						// tex2D returns a 4 values(rgba) color from the texture
						fixed4 col = tex2D(_MainTex, uv) * _Color * i.vertColor;
						
						col.a *= tex2D(_Mask, i.uv2).r;
						col.a *= 1 - ((i.pos.z / i.pos.w));
						return col;
					}
					ENDCG
				}
			}
}