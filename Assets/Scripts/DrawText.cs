using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawText : MonoBehaviour {

	public GameObject textPrefab;

	private float screenRadious = 290f;
	private int vertexNumber;

	public Color highlightColor;
	public Color nextColor;
	public Color defaultColor;

	[HideInInspector]
	public List<Text> vertexTexts;

	public void Reset() {
		for (int k = 0; k < transform.childCount; k++)
			Destroy(transform.GetChild(k).gameObject);
		this.Start();
	}

	void Start() {
		Instantiate(textPrefab,transform);
		this.vertexNumber = Utils.vertexNumber;
		this.vertexTexts = new List<Text>();

		decimal angleGap = 360.0m / vertexNumber;

		for (decimal w = 0.0m; w <= (360m - 0.000001m); w += angleGap) {
			GameObject newText = Instantiate(this.transform.GetChild(0).gameObject);
			newText.transform.SetParent(this.transform);
			newText.GetComponent<RectTransform>().localPosition = Utils.PointOnCircumferencScreen(screenRadious, (double)w, Vector3.zero);
			newText.name = "Text " + vertexTexts.Count;
			vertexTexts.Add(newText.GetComponent<Text>());
			newText.GetComponent<Text>().text = (vertexTexts.Count - 1).ToString();
			newText.GetComponent<Text>().color = Color.black;
			newText.GetComponent<Text>().enabled = true;
		}

		Destroy(this.transform.GetChild(0).gameObject);

	}

	public void HighlightText(int i) {
		for (int k = 0; k < vertexNumber; k++)
			if (k != i && k != (i + Utils.jump) % vertexNumber) {
				vertexTexts[k].color = defaultColor;
				vertexTexts[k].fontStyle = FontStyle.Normal;
			}
			else if (k == i) {
				vertexTexts[k].color = highlightColor;
				vertexTexts[k].fontStyle = FontStyle.Bold;
			}
			else if (k == (i + Utils.jump) % vertexNumber) {
				vertexTexts[k].color = nextColor;
				vertexTexts[k].fontStyle = FontStyle.Bold;
			};
	}
}
