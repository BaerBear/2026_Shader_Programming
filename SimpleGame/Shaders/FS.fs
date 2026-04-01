#version 330

in vec2 v_Tex;

layout(location=0) out vec4 FragColor;

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

void main()
{
    Line();
}