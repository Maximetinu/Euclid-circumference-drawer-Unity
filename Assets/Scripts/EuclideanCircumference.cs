using UnityEngine;
using System.Collections.Generic;

public class EuclideanCircumference : MonoBehaviour {

	[Header("Euclid circumference config")]
	[Tooltip("Vertices around circumference")]
	public int vertexNumber = 42;
	[Tooltip("Drawed line will go from vertex i to vertex i + jump")]
	public int jump = 5;
	[Tooltip("Check this option if you want to start with all lines already painted")]
	[Space(5)]
	public bool drawAllAtStart = false;
	public enum PaintingType { DISCRETE, CONTINUOUS }
	[Space(5)]
	[Tooltip("Check continuous if you want to perform an animation while key is pressed")]
	public PaintingType drawingType = PaintingType.DISCRETE;

	[Space(40)]
	[Header("Appearence configuration. Drag materials here")]
	[Tooltip("Vertex default material")]
	public Material vertexMaterial;
	[Tooltip("Current vertex material")]
	public Material highlightMaterial;
	[Tooltip("Next vertex material")]
	public Material nextHighlightMaterial;

	[HideInInspector]
	public List<Vector3> vertexPositions;
	[HideInInspector]
	public List<GameObject> vertexGameObjects;

	public GameObject canvasGameObject;

	private void Awake() {
		Utils.vertexNumber = this.vertexNumber;
		Utils.jump = this.jump;
	}

	// Use this for initialization
	void Start () {
		vertexPositions = new List<Vector3>();
		vertexGameObjects = new List<GameObject>();

		decimal angleGap = 360.0m / vertexNumber;

		for (decimal w = 0.0m; w <= (360.0m - 0.000001m); w += angleGap) {
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.GetComponent<Renderer>().material = vertexMaterial;
			sphere.transform.position = Utils.PointOnCircumference((75 / 2) + 0.5f, (double)w, Vector2.zero);
			sphere.name = "Vertex " + vertexPositions.Count;
			vertexPositions.Add(sphere.transform.position);
			vertexGameObjects.Add(sphere);
		}

		if (drawAllAtStart)
			this.DrawLines();
	}

	private int i = 0;
	private bool onStart = true;
	private Color usedColor = Color.red;

	private void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}

		if (drawingType == PaintingType.CONTINUOUS || Input.GetKey(KeyCode.LeftShift)) {
			mustRedraw = true;
			this.GetInputContinuous(); 
		}
		else {
			this.GetInputDiscrete();
			mustRedraw = true;
		}
			

		if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.RightArrow)) {
			jump = Utils.jump = jump + 1;
			mustRedraw = true;
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			jump = Utils.jump = jump - 1;
			if (jump <= 0) jump = 1;
			mustRedraw = true;
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			vertexNumber = Utils.vertexNumber = vertexNumber - 1;
			if (vertexNumber <= 2) vertexNumber = Utils.vertexNumber = 2;
			Reset();
			mustRedraw = true;
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			vertexNumber = Utils.vertexNumber = vertexNumber + 1;
			if (vertexNumber >= 100) vertexNumber = Utils.vertexNumber = 100;
			Reset();
			mustRedraw = true;
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			mustRedraw = true;
			Reset();
		}

		if (mustRedraw)
			HighlightVertices();
	}

	private bool mustRedraw = true;
	private void HighlightVertices() {
		mustRedraw = false;
		for (int k = 0; k < vertexNumber; k++)
			if (k != i && k != (i + jump)%vertexNumber) {
				vertexGameObjects[k].GetComponent<Renderer>().material = vertexMaterial;
				vertexGameObjects[k].transform.localScale = Vector3.one;
			} else if (k == i) {
				vertexGameObjects[k].GetComponent<Renderer>().material = highlightMaterial;
				vertexGameObjects[k].transform.localScale = new Vector3(2, 2, 2);
			} else if (k == (i + jump) % vertexNumber) {
				vertexGameObjects[k].GetComponent<Renderer>().material = nextHighlightMaterial;
				vertexGameObjects[k].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			};
		canvasGameObject.GetComponent<DrawText>().HighlightText(i);
	}

	private void Reset() {
		foreach (GameObject go in vertexGameObjects)
			Destroy(go);

		canvasGameObject.GetComponent<DrawText>().Reset();
		i = 0;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("line"))
			Destroy(go);
		Start();
	}

	private void GetInputDiscrete() {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha1)) {
			this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
			i = (i + jump) % vertexNumber;
			if (onStart) onStart = false;
			if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			for (int k = 0; k < 2; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			for (int k = 0; k < 3; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			for (int k = 0; k < 4; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			for (int k = 0; k < 5; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			for (int k = 0; k < 6; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			for (int k = 0; k < 7; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha8)) {
			for (int k = 0; k < 8; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha9)) {
			for (int k = 0; k < 9; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			for (int k = 0; k < 10; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}
	}

	private void GetInputContinuous() {
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Alpha1)) {
			this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
			i = (i + jump) % vertexNumber;
			if (onStart) onStart = false;
			if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
		}

		if (Input.GetKey(KeyCode.Alpha2)) {
			for (int k = 0; k < 2; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha3)) {
			for (int k = 0; k < 3; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha4)) {
			for (int k = 0; k < 4; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha5)) {
			for (int k = 0; k < 5; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha6)) {
			for (int k = 0; k < 6; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha7)) {
			for (int k = 0; k < 7; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha8)) {
			for (int k = 0; k < 8; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha9)) {
			for (int k = 0; k < 9; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}

		if (Input.GetKey(KeyCode.Alpha0)) {
			for (int k = 0; k < 10; k++) {
				this.DrawLineBetween(i, (i + jump) % vertexNumber, usedColor);
				i = (i + jump) % vertexNumber;
				if (onStart) onStart = false;
				if (i == 0) usedColor = ColorExtension.RandomMain(usedColor);
			}
		}
	}

	private void DrawLines() {
		bool firstLoop = true;
		for (int i = 0; i != 0 || firstLoop; i = (i + jump) % vertexNumber) {
			if (firstLoop) firstLoop = false;
			this.DrawLineBetween(i, (i + jump) % vertexNumber);
		}
	}

	private void DrawLineBetween(int vertex_a, int vertex_b) {
		Vector3 vertex_a_pos = this.vertexPositions[vertex_a];
		Vector3 vertex_b_pos = this.vertexPositions[vertex_b];

		//Debug.DrawLine(vertex_a_pos, vertex_b_pos, Color.red,9999f);
		Utils.Draw3DLine(vertex_a_pos, vertex_b_pos, this.GetComponent<MaterialsPool>().GetMaterial(Color.red));

	}

	private void DrawLineBetween(int vertex_a, int vertex_b, Color c) {
		Vector3 vertex_a_pos = this.vertexPositions[vertex_a];
		Vector3 vertex_b_pos = this.vertexPositions[vertex_b];

		//Debug.DrawLine(vertex_a_pos, vertex_b_pos, c, 9999f);
		Utils.Draw3DLine(vertex_a_pos, vertex_b_pos, this.GetComponent<MaterialsPool>().GetMaterial(c));
	}
}
