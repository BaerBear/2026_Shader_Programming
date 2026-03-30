#version 330

in float v_t;

out vec4 FragColor;

void main()
{
    float intensity = 1.0 - v_t;

    vec3 color = mix(
        vec3(1.0, 0.1, 0.0),
        vec3(1.0, 1.0, 0.0),
        intensity
    );

    float alpha = intensity * intensity;

    FragColor = vec4(color, alpha);
}