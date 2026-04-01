#version 330

in vec2 v_Tex;

layout(location=0) out vec4 FragColor;

uniform float u_Time;

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

void Circles(){
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

void main()
{
    Circles();
}