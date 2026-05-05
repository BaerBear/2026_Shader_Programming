#version 330

in vec2 v_Tex;

layout(location=0) out vec4 FragColor;

uniform float u_Time;
uniform sampler2D u_RGBTex;

const float c_PI = 3.141592;

void Simple()
{
    if (v_Tex.x < 0.5){
        FragColor = vec4(0);
    }
    else {
        FragColor = vec4(1);
    }
}

void Line()
{
    // FragColor = vec4(v_Tex.xy, 0, 1);
    float trans = c_PI / 2;     // 주기 이동 시켜서 가장자리부터 선 생기게

    float period_x = (v_Tex.x * 2 * c_PI - trans) * 5;
    float value_x = pow(abs(sin(period_x)), 16);

    float period_y = (v_Tex.y * 2 * c_PI - trans) * 5;
    float value_y = pow(abs(sin(period_y)), 16);

    FragColor = vec4(max(value_x, value_y));
}

void Circle()
{
    vec2 center = vec2(0.5, 0.5);
    vec2 currPos = v_Tex;
    
    float radius = 0.5;
    float width = 0.01;
    float dist = distance(center, currPos);

    float value = smoothstep(radius, radius - width, dist);

    /*if (dist > radius - 0.01 && dist < radius) {
        FragColor = vec4(1);
    }
    else {
        FragColor = vec4(0);
    }*/

    FragColor = vec4(value);
}

void Circles()
{
    vec2 center = vec2(0.5, 0.5);
    vec2 currPos = v_Tex;
    float count = 5;

    float radius = 0.5;
    float dist = distance(center, currPos);
    
    float grey = sin(dist);
    float period = sin(dist * 4 * c_PI * count - u_Time * 10);
    float value = pow(abs(period), 32);

    FragColor = vec4(value);
}

void Flag() 
{
    float amp = 0.5;
    float speed = 4;
    float sinInput = v_Tex.x * c_PI * 2 - u_Time * speed;   // u_Time을 빼서 깃발이 왼쪽에서 오른쪽으로 움직이는 효과
    float sinValue = v_Tex.x * amp * (((sin(sinInput) + 1) / 2) - 0.5) + 0.5;   // v_Tex.x를 곱함으로써 왼쪽 끝은 고정됨.

    float width = 0.3 * (1-v_Tex.x);                // 깃발의 오른쪽 끝이 더 얇아지도록 v_Tex.x에 반비례하는 width 계산
    float fWidth = 0.5 * mix(1, 0.0, v_Tex.x);     // 깃발의 오른쪽 끝이 더 얇아지도록 v_Tex.x에 비례하는 width 계산 (mix 함수 사용)
    // A * (1-a) + B * a == mix(A, B, a)
    float grey = 0;

    if(v_Tex.y < sinValue + fWidth / 2 && v_Tex.y > sinValue - fWidth / 2)
    {
        grey = 1;
    }
    else 
    {
        grey = 0;
        discard;
    }

    FragColor = vec4(grey);
}

void Flame() 
{
    float amp = 0.5;
    float speed = 4;
    float newY = 1 - v_Tex.y;   // y축을 뒤집어서 아래쪽이 0, 위쪽이 1이 되도록
    float sinInput = newY * c_PI * 2 - u_Time * speed;   // u_Time을 빼서 깃발이 왼쪽에서 오른쪽으로 움직이는 효과
    float sinValue = newY * amp * (((sin(sinInput) + 1) / 2) - 0.5) + 0.5;   // v_Tex.x를 곱함으로써 왼쪽 끝은 고정됨.

    float width = 0.3 * (1-newY);                // 깃발의 오른쪽 끝이 더 얇아지도록 v_Tex.x에 반비례하는 width 계산
    float fWidth = 0.5 * mix(0, 1, newY);     // 깃발의 오른쪽 끝이 더 얇아지도록 v_Tex.x에 비례하는 width 계산 (mix 함수 사용)
    // A * (1-a) + B * a == mix(A, B, a)
    float grey = 0;

    if(v_Tex.x < sinValue + fWidth / 2 && v_Tex.x > sinValue - fWidth / 2)
    {
        grey = 1;
    }
    else 
    {
        grey = 0;
        discard;
    }

    FragColor = vec4(grey);
}

void TextureSampling()
{
    FragColor = texture(u_RGBTex, v_Tex);
}

// 시험문제 2문제에서 3문제 나옴.
void TextureQ1()
{
	float tx = v_Tex.x;
	float ty = 1 - abs((v_Tex.y * 2) - 1);
	
	vec2 tex = vec2(tx, ty);
	FragColor = texture(u_RGBTex, tex);
}

void TextureQ2()
{
	float tx = fract(v_Tex.x * 3);
	float ty = v_Tex.y / 3;
	
	float offsetX = 0;
	float offsetY = (2 - floor(v_Tex.x * 3)) / 3;	// 해당 영역에 대해 소수점을 버리는 함수 floor

	vec2 tex = vec2(tx + offsetX, ty + offsetY);
	FragColor = texture(u_RGBTex, tex);
}

void TextureQ3()
{
	float tx = fract(v_Tex.x * 3);
	float ty = v_Tex.y / 3;
	
	float offsetX = 0;
	float offsetY = floor(v_Tex.x * 3) / 3;	// 해당 영역에 대해 소수점을 버리는 함수 floor

	vec2 tex = vec2(tx + offsetX, ty + offsetY);
	FragColor = texture(u_RGBTex, tex);
}

void main()
{
    TextureQ1();
}