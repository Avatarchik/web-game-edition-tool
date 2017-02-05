using UnityEngine;
using UnityEngine.UI;

public class ColorPresets : MonoBehaviour
{
	public ColorPicker picker;
	public GameObject[] presets;
	public Image createPresetImage;
	private bool[] presetsActive = null;


	void Awake()
	{
//		picker.onHSVChanged.AddListener(HSVChanged);
		picker.onValueChanged.AddListener(ColorChanged);
		if (presetsActive == null) {
			presetsActive = new bool[presets.Length];
			for (var i = 0; i < presets.Length; i++)
			{
				if (i == 0)
					presetsActive [i] = true;
				else
					presetsActive [i] = false;
			}
		}
	}

	/*public void CreatePresetButton()
	{
		for (var i = 0; i < presets.Length; i++)
		{
			
			if (!presets[i].activeSelf)
			{
				presets[i].SetActive(true);
				presets[i].GetComponent<Image>().color = picker.CurrentColor;
				break;
			}

		}
	}*/

	public void PresetSelect(Image sender)
	{
		for (var i = 0; i < presetsActive.Length; i++)
		{
			presetsActive [i] = false;
		}
		for (var i = 0; i < presets.Length; i++)
		{
			if (sender.GetInstanceID () == presets [i].GetComponent<Image> ().GetInstanceID ()) {
				presetsActive [i] = true;
			}
		}
		picker.CurrentColor = sender.color;
	}

	// Not working, it seems ConvertHsvToRgb() is broken. It doesn't work when fed
	// input h, s, v as shown below.
//	private void HSVChanged(float h, float s, float v)
//	{
//		createPresetImage.color = HSVUtil.ConvertHsvToRgb(h, s, v, 1);
//	}
	private void ColorChanged(Color color)
	{
		var j = 0;
		createPresetImage.color = color;
		for (var i = 0; i < presetsActive.Length; i++)
		{
			if (presetsActive [i] == true)
				j = i;
		}
		presets [j].GetComponent<Image> ().color = color;
	}
}
