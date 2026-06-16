#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_Tex;

const float c_PI = 3.141592;

uniform float u_Time;
uniform sampler2D u_RGBTex;
uniform sampler2D u_CurrNumTex;
uniform sampler2D u_NumsTex;
uniform int u_InputNum;

void LinePattern()
{
	float lineCountH = 10;
	float lineCountV = 2;
	float lineWidth = 1;
	lineCountH = lineCountH / 2;
	lineCountV = lineCountV / 2;
	lineWidth = 50 / lineWidth;
	float per = -0.5*c_PI;
	float grey = pow(
			abs(sin((v_Tex.y*2*c_PI+per)*lineCountH))
					, lineWidth);

	float grey1= pow(
			abs(sin((v_Tex.x*2*c_PI+per)*lineCountV))
					, lineWidth);

	FragColor = vec4(grey+grey1);
}

void TextureQ1()
{
	float tx = v_Tex.x;
	float ty = 1-2*abs(v_Tex.y - 0.5);
	vec2 newTex = vec2(tx, ty);
	FragColor = texture(u_RGBTex, newTex);
}

void TextureQ2()
{
	float tx = fract(v_Tex.x * 3);
	float ty = v_Tex.y / 3;

	float offsetX = 0;
	float offsetY = (2 - floor(v_Tex.x * 3))/3;

	vec2 newTex = vec2(tx + offsetX, ty + offsetY);
	FragColor = texture(u_RGBTex, newTex);
}

void TextureQ3()
{
	float tx = fract(v_Tex.x * 3);
	float ty = v_Tex.y / 3;

	float offsetX = 0;
	float offsetY = floor(v_Tex.x * 3)/3;

	vec2 newTex = vec2(tx + offsetX, ty + offsetY);
	FragColor = texture(u_RGBTex, newTex);
}

void TextureQ4()
{
	float resolX = 5;
	float resolY = 5;
	float shear = 0.5 * u_Time;

	float offsetX = fract(ceil(v_Tex.y*resolY)*shear);
	float offsetY = 0;

	float tx = fract(v_Tex.x * resolX + offsetX);
	float ty = fract(v_Tex.y * resolY + offsetY);

	vec2 newTex = vec2(tx, ty);
	FragColor = texture(u_RGBTex, newTex);
}

void Num()
{
	float tx = v_Tex.x;
	float ty = v_Tex.y;

	vec2 newTex = vec2(tx, ty);
	FragColor = texture(u_CurrNumTex, newTex);
}

void Nums()
{
	float index = float(u_InputNum);

	float tx = v_Tex.x / 5;
	float ty = v_Tex.y / 2;

	float offsetX = fract(index/5.0);
	float offsetY = floor(index/5.0)/2.0;

	vec2 newTex = vec2(tx + offsetX, ty + offsetY);
	FragColor = texture(u_NumsTex, newTex);
}

void FS_Q6()
{
	float tx = fract(v_Tex.x*3);
	float ty = v_Tex.y/3;
	float offsetX = 0;
	float offsetY = abs(floor(v_Tex.x*3)/3 - 2);
	FragColor = texture(u_RGBTex, vec2(tx+offsetX, ty+offsetY));
}

void FS_Q7()
{
	float tx = v_Tex.x;
	float ty = fract(v_Tex.y*3)/3;
	float offsetX = 0;
	float offsetY = fract(ceil(v_Tex.y*3.0)/3.0);
	FragColor = texture(u_RGBTex, vec2(tx+offsetX, ty+offsetY));
}

void FS_Q8()
{
	float tx = v_Tex.x/5.0;
	float ty = v_Tex.y/2.0;
	float offsetX = 2.0/5.0;
	float offsetY = 1.0/2.0;
	FragColor = texture(u_NumsTex, vec2(tx+offsetX, ty+offsetY));
}

void FS_Q9()
{
	float tx = 2*v_Tex.x/5.0;
	float ty = v_Tex.y/2.0;
	float offsetX = 2.0/5.0;
	float offsetY = 0.0/2.0;
	FragColor = texture(u_NumsTex, vec2(tx+offsetX, ty+offsetY));
}

void FS_Q10()
{
	float index = float(8);
	float tx = v_Tex.x / 5;
	float ty = v_Tex.y / 2;
	float offsetX = fract(index/5.0);
	float offsetY = floor(index/5.0)/2.0;
	FragColor = texture(u_NumsTex, vec2(tx+offsetX, ty+offsetY));
}

void main()
{
	//LinePattern();
	//TextureQ1();
	//TextureQ2();
	//TextureQ3();
	//TextureQ4();
	//Num();
	//Nums();
	FS_Q6();
	//FS_Q7();
	//FS_Q8();
	//FS_Q9();
	//FS_Q10();
}
