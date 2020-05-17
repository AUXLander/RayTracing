#version 430

out vec4 FragColor;
in 	vec3 glPosition;

const float EPSILON = 0.001;
const float BIG = 1000000.0;

const int DIFFUSE    = 1;
const int REFLECTION = 2;
const int REFRACTION = 3;

const int DIFFUSE_REFLECTION = 1;
const int MIRROR_REFLECTION  = 2;

const int SPHERES_COUNT   = 2;
const int TRIANGLES_COUNT = 10;
const int MATERIAL_COUNT  = 2;

struct SSphere { 
	vec3  Center;
	float Radius;
	
	int   MaterialIdx;// --
};

struct STriangle {
	vec3 v1;
	vec3 v2;
	vec3 v3;
	
	int  MaterialIdx;
};

struct Cam {
	vec3 Position;
	vec3 View;
	vec3 Up;
	vec3 Side;
	vec2 Scale;
};

struct Ray {
	vec3 Origin;
	vec3 Direction;
};

struct SIntersection {
	float Time;
	vec3  Point;
	vec3  Normal;
	vec3  Color;
	vec4  LightCoeffs;
	
	float ReflectionCoef;
	float RefractionCoef;
	
	int   MaterialType;
};

struct SMaterial { 
	vec3  Color;
	vec4  LightCoeffs;
	
	float ReflectionCoef;
	float RefractionCoef;
	
	int MaterialType;
};

struct SLight {
	vec3 Position;
};

struct STracingRay {
	Ray   ray;
	float contribution;
	
	int   depth;
};

Ray GenerateRay( void ) {
	vec2 coords 	= glPosition.xy * uCamera.Scale;
	vec3 direction 	= uCamera.View + uCamera.Side * coords.x + uCamera.Up * coords.y;
	
	return Ray(uCamera.Position, normalize(direction));
}

Cam InitCameraDefaults() {
	Cam camera;
	
	camera.Position	= vec3(0.0, 0.0, -8.0);
	camera.View	 	= vec3(0.0, 0.0, 1.0);
	camera.Up 		= vec3(0.0, 1.0, 0.0);
	camera.Side 	= vec3(1.0, 0.0, 0.0);
	
	camera.Scale 	= vec2(1.0);
	
	return camera;
}

STriangle triangles [TRIANGLES_COUNT];
SSphere   spheres	[SPHERES_COUNT];
SMaterial materials [MATERIAL_COUNT];

SLight light;

Cam uCamera;

int Unit = 1;

int StackPTR = -1;
const int StackLEN = 100;

STracingRay Stack[StackLEN];

void StackInit() {
	StackPTR = 0;
}

bool pushRay (STracingRay tray) {
	if(StackPTR < StackLEN) {
		StackPTR += 1;
		Stack[StackPTR] = tray;
		return true;
	}
	
	return false
} 

STracingRay popRay () {
	if(StackPTR >= 0) {
		StackPTR -= 1;
		return Stack[StackPTR + 1];
	}
	
	return Stack[0];
}

bool isEmpty() {
	return !(StackPTR >= 0);
}


void initializeDefaultLightMaterials(out SLight light, out SMaterial materials[MATERIAL_COUNT]) {

	light.Position = vec3(0.0, 2.0, -4.0f);

	vec4 lightCoefs = vec4(0.4, 0.9, 0.0, 512.0);
	materials[0].Color = vec3(0.0, 1.0, 0.0);
	materials[0].LightCoeffs = vec4(lightCoefs);
	materials[0].ReflectionCoef = 0.5;
	materials[0].RefractionCoef = 1.0;
	materials[0].MaterialType = DIFFUSE;
	
	materials[1].Color = vec3(0.0, 0.0, 1.0);
	materials[1].LightCoeffs = vec4(lightCoefs);
	materials[1].ReflectionCoef = 0.5;
	materials[1].RefractionCoef = 1.0;
	materials[1].MaterialType = DIFFUSE;
}

void initializeDefaultScene( out STriangle triangles[10], out SSphere spheres[SPHERES_COUNT] ) {
	/** TRIANGLES **/
	
	/* left wall */
	triangles[0].v1 = vec3(-5.0,-5.0,-5.0);
	triangles[0].v2 = vec3(-5.0, 5.0, 5.0);
	triangles[0].v3 = vec3(-5.0, 5.0,-5.0);
	triangles[0].MaterialIdx = 0;
	
	triangles[1].v1 = vec3(-5.0,-5.0,-5.0);
	triangles[1].v2 = vec3(-5.0,-5.0, 5.0);
	triangles[1].v3 = vec3(-5.0, 5.0, 5.0);
	triangles[1].MaterialIdx = 0;
	
	/* back wall */
	triangles[2].v1 = vec3(-5.0,-5.0,-5.0);
	triangles[2].v2 = vec3( 5.0,-5.0,-5.0);
	triangles[2].v3 = vec3(-5.0, 5.0,-5.0);
	triangles[2].MaterialIdx = 0;
	
	triangles[3].v1 = vec3( 5.0, 5.0,-5.0);
	triangles[3].v2 = vec3(-5.0, 5.0,-5.0);
	triangles[3].v3 = vec3( 5.0,-5.0,-5.0);
	triangles[3].MaterialIdx = 0;
	
	/* right wall */
	triangles[4].v1 = vec3( 5.0,-5.0,-5.0);
	triangles[4].v2 = vec3( 5.0, 5.0,-5.0);
	triangles[4].v3 = vec3( 5.0,-5.0, 5.0);
	triangles[4].MaterialIdx = 0;
	
	triangles[5].v1 = vec3( 5.0, 5.0, 5.0);
	triangles[5].v2 = vec3( 5.0, 5.0,-5.0);
	triangles[5].v3 = vec3( 5.0,-5.0, 5.0);
	triangles[5].MaterialIdx = 0;
	
	/* bottom wall */
	triangles[6].v1 = vec3(-5.0,-5.0,-5.0);
	triangles[6].v2 = vec3( 5.0,-5.0,-5.0);
	triangles[6].v3 = vec3(-5.0,-5.0, 5.0);
	triangles[6].MaterialIdx = 0;
	
	triangles[7].v1 = vec3(-5.0,-5.0, 5.0);
	triangles[7].v2 = vec3( 5.0,-5.0,-5.0);
	triangles[7].v3 = vec3( 5.0,-5.0, 5.0);
	triangles[7].MaterialIdx = 0;
	
	/* top wall */
	triangles[8].v1 = vec3( 5.0, 5.0,-5.0);
	triangles[8].v2 = vec3(-5.0, 5.0,-5.0);
	triangles[8].v3 = vec3( 5.0, 5.0, 5.0);
	triangles[8].MaterialIdx = 0;
	
	triangles[9].v1 = vec3(-5.0, 5.0,-5.0);
	triangles[9].v2 = vec3( 5.0, 5.0, 5.0);
	triangles[9].v3 = vec3(-5.0, 5.0,-5.0);
	triangles[9].MaterialIdx = 0;
	
	/* front wall */
	//triangles[10].v1 = vec3(-5.0,-5.0, 5.0);
	//triangles[10].v2 = vec3( 5.0,-5.0, 5.0);
	//triangles[10].v3 = vec3(-5.0, 5.0, 5.0);
	//triangles[10].MaterialIdx = 0;
	
	//triangles[11].v1 = vec3( 5.0, 5.0, 5.0);
	//triangles[11].v2 = vec3(-5.0, 5.0, 5.0);
	//triangles[11].v3 = vec3( 5.0,-5.0, 5.0);
	//triangles[11].MaterialIdx = 0;
	
	/** SPHERES **/
	spheres[0].Center = vec3(-1.0,-1.0,-2.0);
	spheres[0].Radius = 2.0;
	spheres[0].MaterialIdx = 0;
	
	spheres[1].Center = vec3(2.0,1.0,2.0);
	spheres[1].Radius = 1.0;
	spheres[1].MaterialIdx = 0;
}

bool IntersectSphere( SSphere sphere, Ray ray, float start, float final, out float time ) {
	ray.Origin -= sphere.Center;
	
	float A = dot(ray.Direction, ray.Direction);
	float B = dot(ray.Direction, ray.Origin);
	float C = dot(ray.Origin, ray.Origin) - sphere.Radius * sphere.Radius;
	float D = B * B - A * C;
	
	if (D > 0.0) {
		D = sqrt(D);
		
		float t1 = (-B - D) / A;
		float t2 = (-B + D) / A;
		
		if(t1 < 0 && t2 < 0) {
			return false;
		}
		
		if(min(t1, t2) < 0) {
			time = max(t1, t2);
		}
		else {
			time = min(t1, t2);
		}
		
		return true;		
	}
	
	return false;
}

bool IntersectTriangle(Ray ray, vec3 v1, vec3 v2, vec3 v3, out float time) {
	time = -1;
	vec3 A = v2 - v1;
	vec3 B = v3 - v1;
	vec3 N = cross(A, B);
	
	float NdotRayDirection = dot(N, ray.Direction);
	
	if (abs(NdotRayDirection) < EPSILON) {
		return false;
	}
	
	float d = dot(N, v1);
	float t = -(dot(N, ray.Origin) - d) / NdotRayDirection;
	
	if (t < 0) {
		return false;
	}
	
	vec3 P = ray.Origin + t * ray.Direction;
	vec3 C;
	
	C = cross(v2 - v1, P - v1);
	if (dot(N, C) < 0) {
		return false;
	}
	
	C = cross(v3 - v2, P - v2);
	if (dot(N, C) < 0) {
		return false;
	}
	
	C = cross(v1 - v3, P - v3);
	if (dot(N, C) < 0) {
		return false;
	}
	
	time = t;
	return true;
}

bool Raytrace(Ray ray, float start, float final, inout SIntersection intersect ) {
	bool  result = false;
	float test   = start;
	
	int	MaterialIdx;
	SSphere sphere;
	STriangle triangle;
	
	intersect.Time = final;
	
	for (int i = 0; i < SPHERES_COUNT; i++) {
		sphere 		= spheres[i];
		MaterialIdx = sphere.MaterialIdx;
		
		if (IntersectSphere(sphere, ray, start, final, test) && test < intersect.Time) {
			intersect.Time 	 = test;
			intersect.Point  = ray.Origin + ray.Direction * test;
			intersect.Normal = normalize(intersect.Point - spheres[i].Center);
			
			intersect.Color  		 = materials[MaterialIdx].Color;
			intersect.LightCoeffs 	 = materials[MaterialIdx].LightCoeffs;
			intersect.ReflectionCoef = materials[MaterialIdx].ReflectionCoef;
			intersect.RefractionCoef = materials[MaterialIdx].RefractionCoef;
			intersect.MaterialType	 = materials[MaterialIdx].MaterialType;
			
			result = true;
		}
	}
	
	for (int i = 0; i < TRIANGLES_COUNT; i++) {
		triangle 	= triangles[i];
		MaterialIdx = triangle.MaterialIdx;
		
		if (IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test) && test < intersect.Time ) {
			intersect.Time   = test;
			intersect.Point  = ray.Origin + ray.Direction * test;
			intersect.Normal = normalize(cross(triangle.v1 - triangle.v2, triangle.v3 - triangle.v2));
			
			intersect.Color  		 = materials[MaterialIdx].Color;
			intersect.LightCoeffs    = materials[MaterialIdx].LightCoeffs;
			intersect.ReflectionCoef = materials[MaterialIdx].ReflectionCoef;
			intersect.RefractionCoef = materials[MaterialIdx].RefractionCoef;
			intersect.MaterialType	 = materials[MaterialIdx].MaterialType;;
			result = true;
		}
	}
		
	return result;
}

float Shadow(SLight currLight, SIntersection intersect) {
	float shadowing = 1.0;
	vec3  direction = normalize(currLight.Position - intersect.Point);

	float distanceLight = distance(currLight.Position, intersect.Point);

	Ray shadowRay = Ray(intersect.Point + direction * EPSILON, direction);

	SIntersection shadowIntersect;
	shadowIntersect.Time = BIG;

	if(Raytrace(shadowRay, spheres, triangles, materials, 0, distanceLight, shadowIntersect)) {
		shadowing = 0.0;
	}

	return shadowing;
}

vec3 Phong(SIntersection intersect, SLight currLight, float shadow) {
	vec3  light     = normalize(currLight.Position - intersect.Point);
	vec3  view 	    = normalize(uCamera.Position   - intersect.Point);
	float diffuse   = max(dot(light, intersect.Normal), 0);
	
	vec3  reflected = reflect(-view, intersect.Normal);
	
	float specular = pow(max(dot(reflected, light), 0), intersect.LightCoeffs.w);
	
	return intersect.LightCoeffs.x * intersect.Color +
		   intersect.LightCoeffs.y * diffuse * intersect.Color * shadow +
		   intersect.LightCoeffs.z * specular * Unit;
}

void main ( void ) {
	float start = 0;
	float final = BIG;
	vec3  resultColor = vec3(0,0,0);
	
	uCamera = InitCameraDefaults();
	Ray ray = GenerateRay();
	
	initializeDefaultScene(triangles, spheres);
	initializeDefaultLightMaterials(light, materials);
	
	STracingRay sray = STracingRay(ray, 1, 0);
	pushRay(sray);
	
	while (!isEmpty()) {
		STracingRay sray = popRay();
		ray = sray.ray;
		SIntersection intersect;
		intersect.Time = BIG;
		start = 0;
		final = BIG;
		
		if (Raytrace(ray, start, final, intersect)) {
			switch (intersect.MaterialType) {
				case DIFFUSE_REFLECTION: {
					float shadow = Shadow(light, intersect);
					resultColor += sray.contribution * Phong(intersect, light, shadow);
					break;
				}
				
				case MIRROR_REFLECTION: {
					if (intersect.ReflectionCoef < 1) {
						float contribution = sray.contribution * (1 - intersect.ReflectionCoef);
						
						float shadow = Shadow(light, intersect);
						
						resultColor += contribution * Phong(intersect, light, shadow);
					}
					
					vec3 reflectDirection = reflect(ray.Direction, intersect.Normal);
					
					float contribution = sray.contribution * intersect.ReflectionCoef;
					STracingRay reflectRay = STracingRay(Ray(intersect.Point + reflectDirection * EPSILON, reflectDirection), contribution, sray.depth + 1);
					
					pushRay(reflectRay);
					
					break;
				}
			}
		}
	}
	
	FragColor = vec4 (resultColor, 1.0);
}

/*
void main ( void ) {
	float start = 0;
	float final = BIG;
	
	uCam = InitCameraDefaults();
	Ray uRay = GenerateRay(uCam);
	
	SIntersection intersect;

	intersect.Time = BIG;
	vec3 resultColor = vec3(0,0,0);

	initializeDefaultScene( triangles, spheres );
	
	if (Raytrace(uRay, spheres, triangles, materials, start, final, intersect)) {
		resultColor = vec3(1,0,0);
	}

	FragColor = vec4 (resultColor, 1.0);
}
*/