#version 430

out vec4 FragColor;
in 	vec3 glPosition;



struct Cam
{
	vec3 Position;
	vec3 View;
	vec3 Up;
	vec3 Side;
	vec2 Scale;
};

struct Ray
{
	vec3 Origin;
	vec3 Direction;
};

Ray GenerateRay(Cam uCamera)
{
	vec2 coords 	= glPosition.xy * uCamera.Scale;
	vec3 direction 	= uCamera.View + uCamera.Side * coords.x + uCamera.Up * coords.y;
	
	return Ray(uCamera.Position, normalize(direction));
}

Cam InitCameraDefaults()
{
	Cam camera;
	camera.Position	= vec3(0.0, 0.0, -8.0);
	camera.View	 	= vec3(0.0, 0.0, 1.0);
	camera.Up 		= vec3(0.0, 1.0, 0.0);
	camera.Side 	= vec3(1.0, 0.0, 0.0);
	
	camera.Scale 	= vec2(1.0);
	
	return camera;
}

void main ( void ) {
	Cam uCam = InitCameraDefaults();
	Ray uRay = GenerateRay(uCam);
	
	FragColor = vec4(abs(uRay.Direction.xy), 0, 1.0);
}