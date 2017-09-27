using UnityEngine;

public class MaterialsPool : MonoBehaviour {

	public Material red;
	public Material green;
	public Material blue;
	public Material yellow;
	public Material cyan;
	public Material magenta;
	public Material black;

	public Material GetMaterial(Color c) {
		if (c == Color.red)
			return red;
		else if (c == Color.green)
			return green;
		else if (c == Color.blue)
			return blue;
		else if (c == Color.yellow)
			return yellow;
		else if (c == Color.cyan)
			return cyan;
		else if (c == Color.magenta)
			return magenta;
		else
			return black;
	}
}
