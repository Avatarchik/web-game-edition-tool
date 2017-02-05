using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using WWWDic = System.Collections.Generic.Dictionary<string, string>;
using SimpleJSON;

public class TextureScript : MonoBehaviour {

	public GameObject logoPlane;
	public Texture2D[] texTab;
	public int i = 0;

	IEnumerator Start() {
		string id_token = GetIdToken();
		string id_game = GetIdGame();
		WWWForm form = new WWWForm();

		WWWDic headers = form.headers;
		headers ["Authorization"] = id_token;
		Debug.Log ("try to get on : " + "http://api.playarshop.com/games/" + id_game + "/editor");
		string url = "http://api.playarshop.com/games/" + id_game + "/editor";

		WWW www = new WWW(url, null, headers);
		yield return www;
		var N = JSON.Parse(www.text);

		Debug.Log ("JSON got : " + www.text);

		texTab = new Texture2D[N["targets"].Count];
		for (int i = 0; i < N["targets"].Count; i++) {
			Debug.Log ("try to get texture : " + "http://api.playarshop.com" + N ["targets"] [i] ["image"] ["url"]);
			WWW www1 = new WWW("http://api.playarshop.com" + N["targets"][i]["image"]["url"]);
			yield return www1;
			texTab[i] = www1.texture;
		}
		Renderer renderer1 = GetComponent<Renderer>();
		renderer1.material.mainTexture = texTab[0];

		Debug.Log ("try to get logo : " + "http://api.playarshop.com" + N["company"]["logo"]["url"]);
		WWW www2 = new WWW("http://api.playarshop.com" + N["company"]["logo"]["url"]);
		yield return www2;
		Renderer renderer2 = logoPlane.GetComponent<Renderer>();
		renderer2.material.mainTexture = www2.texture;
	}

	public void ChangePlaneTextureMinus() {
		i--;
		if (i <= -1)
			i = texTab.Length - 1;
		GetComponent<Renderer>().material.mainTexture = texTab[i];
	}

	public void ChangePlaneTexturePlus() {
		i++;
		if (i >= texTab.Length)
			i = 0;
		GetComponent<Renderer>().material.mainTexture = texTab[i];
	}

	[DllImport("__Internal")]
	private static extern string GetIdToken();

	[DllImport("__Internal")]
	private static extern string GetIdGame();

	void Update () {
		
	}
}
