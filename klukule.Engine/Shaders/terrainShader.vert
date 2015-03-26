﻿#version 130

in vec3 position;
in vec2 textureCoords;
in vec3 normals;

out vec2 pass_textureCoords;
out vec3 surfaceNormal;
out vec3 toLightVector;
out vec3 toCameraVector;

uniform mat4 transformationMatrix;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 inverseViewMatrix;
uniform vec3 lightPosition;

void main(void){
	vec4 worldPosition = transformationMatrix  * vec4(position,1.0);
	gl_Position = projectionMatrix * viewMatrix * worldPosition;
	pass_textureCoords = textureCoords;
	surfaceNormal = (transformationMatrix * vec4(normals,0.0)).xyz;
	toLightVector = lightPosition - worldPosition.xyz;
	toCameraVector = (inverseViewMatrix * vec4(0.0,0.0,0.0,1.0)).xyz - worldPosition.xyz;
}
