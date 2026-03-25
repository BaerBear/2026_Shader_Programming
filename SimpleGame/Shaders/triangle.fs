#version 330

in float v_t;

out vec4 FragColor;

void main()
{
    float intensity = 1.0 - v_t;

    vec3 color;

    if (intensity > 0.7)
    {
        color = vec3(1.0, 1.0, 0.3);
    }
    else if (intensity > 0.3)
    {
        color = vec3(1.0, 0.5, 0.0);
    }
    else
    {
        color = vec3(0.8, 0.1, 0.0);
    }

    float dist = length(gl_PointCoord - vec2(0.5));
    float fade = smoothstep(0.5, 0.2, dist);

    float alpha = intensity * fade;

    FragColor = vec4(color, alpha);
}