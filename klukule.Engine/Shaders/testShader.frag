#version 130

in vec2 pass_textureCoords;
in vec3 surfaceNormal;
in vec3 toLightVector;
in vec3 toCameraVector;


out vec4 out_Color;

uniform sampler2D textureSampler;
uniform vec3 lightColor;
uniform float shineDamper;
uniform float reflectivity;

void main(void){
	vec3 unitNormal = normalize(surfaceNormal);
	vec3 unitLightVector = normalize(toLightVector);

	float nDotl = dot(unitNormal,unitLightVector);
	float brightness = max(nDotl,0.1);
	vec3 diffuse = brightness * lightColor;

	vec3 unitVectorToCamera = normalize(toCameraVector);
	vec3 lightDirection = -unitLightVector;
	vec3 reflectedLightDirection = reflect(lightDirection,unitNormal);

	float spectacularFactor = dot(unitVectorToCamera,reflectedLightDirection);
	spectacularFactor = max(spectacularFactor,0.0);
	float dampedFactor = pow(spectacularFactor,shineDamper);

	vec3 finalSpectacular = dampedFactor * reflectivity * lightColor;
	vec4 textureColor = texture2D(textureSampler,pass_textureCoords);
	if(textureColor.a < 0.5){
		discard;
	}
	out_Color = vec4(diffuse,1.0) * textureColor + vec4(finalSpectacular,1.0);
}

