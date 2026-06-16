#version 330

uniform float u_Time;

in vec3 a_Pos;
in float a_Mass;
in vec2 a_Vel;
in float a_RV;
in float a_RV1;
in float a_RV2;
in vec2 a_Tex;
in vec3 a_RGB;

out float v_Grey;
out vec3 v_Color;
out vec2 v_Tex;

const float c_PI = 3.141592;
const float c_G = -9.8;

void Ex1()
{
	vec4 pos = vec4(0, 0, 0, 1);
	float radius = ceil(a_RV1 * 5.0)/5.0;
	pos.x = a_Pos.x + radius * sin(a_RV * 2 * c_PI);
	pos.y = a_Pos.y + radius * cos(a_RV * 2 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex2()
{
	vec4 pos = vec4(0, 0, 0, 1);
	float trans = ceil(a_RV1 * 5.0)/5.0;
	pos.x = a_Pos.x + (a_RV*2.0 - 1.0);
	pos.y = a_Pos.y + trans + 0.2*sin(a_RV*2.0 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex3()
{
	vec4 pos = vec4(0, 0, 0, 1);
	float trans = ceil(a_RV1 * 5.0)/5.0;
	pos.x = a_Pos.x + (a_RV*2.0 - 1.0);
	pos.y = a_Pos.y + trans + 0.2*sin(a_RV*2.0 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex3_2()
{
	vec4 pos = vec4(0, 0, 0, 1);
	float t = fract(u_Time / 2.0) * 2.0;
	pos.x = a_Pos.x + (t - 1.0);
	pos.y = a_Pos.y;

	v_Color = vec3(0);
	gl_Position = pos;
}

void Tex()
{
	vec4 newPosition;
	newPosition = vec4(a_Pos, 1);

	v_Tex = a_Tex;

	gl_Position = newPosition;
}

void main()
{
	//Ex1();
	//Ex2();
	Ex3();
	//Ex3_2();
	//Tex();
}
