using UnityEngine;

public static class Utils {
	public static int vertexNumber = 42;
	public static int jump = 5;
	public static int iterations = 0;

	// XZ Plane
	public static Vector3 PointOnCircumference(float radius, double angleInDegrees, Vector3 origin) {
		// Convert from degrees to radians via multiplication by PI/180        
		float x = (float)(radius * System.Math.Sin(angleInDegrees * System.Math.PI / 180F)) + origin.x;
		float z = (float)(radius * System.Math.Cos(angleInDegrees * System.Math.PI / 180F)) + origin.z;

		return new Vector3(x, 0, z);
	}

	// XY Plane
	public static Vector3 PointOnCircumferencScreen(float radius, double angleInDegrees, Vector3 origin) {
		// Convert from degrees to radians via multiplication by PI/180        
		float x = (float)(radius * System.Math.Sin(angleInDegrees * System.Math.PI / 180F)) + origin.x;
		float y = (float)(radius * System.Math.Cos(angleInDegrees * System.Math.PI / 180F)) + origin.y;

		return new Vector3(x, y, 0);
	}

	public static void Draw3DLine(Vector3 start, Vector3 end, Material mat) {
		GameObject drawedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		drawedCube.transform.position = start + (end - start) / 2;
		drawedCube.transform.localScale = new Vector3(0.2f, 1, Vector3.Distance(start, end));
		drawedCube.transform.LookAt(end);
		GameObject.Destroy(GameObject.Find(start.ToString() + end.ToString()));
		drawedCube.name = start.ToString() + end.ToString();
		drawedCube.GetComponent<Renderer>().material = mat;
		drawedCube.tag = "line";
	}
}