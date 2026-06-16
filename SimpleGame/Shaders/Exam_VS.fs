#version 330

layout(location=0) out vec4 FragColor;

in float v_Grey;
in vec3 v_Color;
in vec2 v_Tex;

void Ex1()
{
	FragColor = vec4(v_Color, 1);
}

void main()
{
	Ex1();
}
