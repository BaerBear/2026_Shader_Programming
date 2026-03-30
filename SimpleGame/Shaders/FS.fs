#version 330

in vec2 v_Tex;

layout(location=0) out vec4 FragColor;

void main()
{
    /*if (v_Tex.x < 0.5){
        FragColor = vec4(0);
    }
    else {
        FragColor = vec4(1);
    }*/

    FragColor = vec4(sin(v_Tex.x * 10 * 3.141592));
}