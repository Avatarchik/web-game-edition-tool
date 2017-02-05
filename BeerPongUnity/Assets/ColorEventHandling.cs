using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorEventHandling : MonoBehaviour {

	public GameObject[] presets;
	public GameObject[] item;
	public GameObject[] item2;
	public ColorPicker picker;
	private GameObject[][] items;

	void Start () {
		items = new GameObject[2][];
		items.SetValue (item, 0);
		items.SetValue (item2, 1);
		picker.onValueChanged.AddListener(color =>
			{
				for (int i = 0; i < presets.Length; i++) {
					GameObject[] objs = items [i];
					for (int j = 0; j < objs.Length; j++) {
						objs[j].GetComponent<Renderer> ().material.color = presets[i].GetComponent<Image>().color;
					}
				}
			});
		for (int i = 0; i < presets.Length; i++) {
			GameObject[] objs = items [i];
			for (int j = 0; j < objs.Length; j++) {
				objs[j].GetComponent<Renderer> ().material.color = presets[i].GetComponent<Image>().color;
			}
		}
	}
	
	void Update () {
	
	}
}
