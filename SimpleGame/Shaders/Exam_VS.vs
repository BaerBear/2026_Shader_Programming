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

void Ex1()	// 원 여러개 그리기
{
	vec4 pos = vec4(0, 0, 0, 1);
	float radius = ceil(a_RV1 * 5.0)/5.0;
	pos.x = a_Pos.x + radius * sin(a_RV * 2 * c_PI);
	pos.y = a_Pos.y + radius * cos(a_RV * 2 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex2()	// 사인 곡선 그리기
{
	vec4 pos = vec4(0, 0, 0, 1);
	pos.x = a_Pos.x + (a_RV*2.0 - 1.0);
	pos.y = a_Pos.y + 0.2*sin(a_RV*2.0 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex3()	// 사인 곡선 위로 여러개 그리기
{
	vec4 pos = vec4(0, 0, 0, 1);
	float trans = ceil(a_RV1 * 5.0)/5.0;
	pos.x = a_Pos.x + (a_RV*2.0 - 1.0);
	pos.y = a_Pos.y + trans + 0.2*sin(a_RV*2.0 * c_PI);

	v_Color = vec3(0);
	gl_Position = pos;
}

void Ex4()	// 파티클이 오른쪽으로 움직임
{
	vec4 pos = vec4(0, 0, 0, 1);
	float t = fract(u_Time / 2.0) * 2.0;
	pos.x = a_Pos.x + (t - 1.0);
	pos.y = a_Pos.y;

	v_Color = vec3(0);
	gl_Position = pos;
}

void VS_Q1()	// 사인 곡선 그리기
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + (a_RV*2 - 1);
	newPosition.y = a_Pos.y + 0.5*sin(a_RV * 4 * c_PI);
	v_Color = vec3(0);
	gl_Position = newPosition;
}

void VS_Q2()	// 화면에 랜덤한 위치에 점 찍기
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + (a_RV * 2 - 1);
	newPosition.y = a_Pos.y + (a_RV1 * 2 - 1);
	v_Color = vec3(0);
	gl_Position = newPosition;
}

void VS_Q3()	// 좌상단 -> 우하단 대각선
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + (a_RV*2 - 1);
	newPosition.y = a_Pos.y + ((1-a_RV)*2 - 1);
	v_Color = vec3(0);
	gl_Position = newPosition;
}

void VS_Q4()	// 원 그리기
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + 0.5*sin(a_RV*2*c_PI);
	newPosition.y = a_Pos.y + cos(a_RV*2*c_PI);
	v_Color = vec3(0);
	gl_Position = newPosition;
}

void VS_Q5()
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + (a_RV*2 - 1);
	newPosition.y = a_Pos.y + fract(a_RV*2)*2 - 1;
	v_Color = vec3(0);
	gl_Position = newPosition;
}

void a()
{
	vec4 newPosition = vec4(0, 0, 0, 1);
	newPosition.x = a_Pos.x + a_RV*2-1;
	newPosition.y = a_Pos.y + fract(a_RV*4)*2 - 1;

	v_Color = vec3(0);
	gl_Position = newPosition;
}

void main()
{
	//Ex1();
	//Ex2();
	//Ex3();
	//Ex4();
	//VS_Q1();
	//VS_Q2();
	//VS_Q3();
	//VS_Q4();
	//VS_Q5();
	a();
}
