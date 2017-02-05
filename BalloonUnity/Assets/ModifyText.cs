using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModifyText : MonoBehaviour {

	public InputField input;

	void Start () {
		GetComponent<TextMesh>().text = input.text;
	}
	
	void Update () {
		GetComponent<TextMesh>().text = input.text;
	}
}
