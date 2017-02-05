using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using WWWDic = System.Collections.Generic.Dictionary<string, string>;
using System.Runtime.InteropServices;

public class ValidateAndPost : MonoBehaviour {

	public GameObject picker1;
	public GameObject picker2;
	public InputField input;

	public void onClick() {
		StartCoroutine(getGameFromServer());
	}

	private IEnumerator getGameFromServer() {
		string id_token = GetIdToken();
		string id_game = GetIdGame();
		string strColor1 = ColorUtility.ToHtmlStringRGB (picker1.GetComponent<Image>().color);
		string strColor2 = ColorUtility.ToHtmlStringRGB (picker2.GetComponent<Image>().color);
		string customText = input.text;

		WWWForm form = new WWWForm();
		WWWDic header1 = form.headers;
		header1["Authorization"] = id_token;
		Debug.Log ("try to get on : " + "http://api.playarshop.com/games/" + id_game);
		string url1 = "http://api.playarshop.com/games/" + id_game;
		WWW www = new WWW(url1, null, header1);
		yield return www;
		Debug.Log("JSON got " + www.text);
		var N = JSON.Parse(www.text);

		JSONClass rootClass = new JSONClass();
		rootClass.Add("game_ref", new JSONData(id_game));
		JSONClass secondClass = new JSONClass();
		secondClass.Add("ref", new JSONData("3"));

		if (N["game"][0]["name"] != null)
			secondClass.Add("name", new JSONData(N["game"][0]["name"]));
		else
			secondClass.Add("name", new JSONData(""));
		
		if (N["game"][0]["description"] != null)
			secondClass.Add("description", new JSONData(N["game"][0]["description"]));
		else
			secondClass.Add("description", new JSONData(""));
		
		secondClass.Add("color1", new JSONData (strColor1));
		secondClass.Add("color2", new JSONData (strColor2));

		if (N["game"][0]["perso1"] != null)
			secondClass.Add("perso1", new JSONData(N["game"][0]["perso1"]));
		else
			secondClass.Add("perso1", new JSONData(""));
		if (N["game"][0]["perso2"] != null)
			secondClass.Add("perso2", new JSONData(N["game"][0]["perso2"]));
		else
			secondClass.Add("perso2", new JSONData(""));
		
		secondClass.Add("custom", new JSONData (customText));
		rootClass.Add("game", secondClass);
		JSONNode rootNode = (JSONNode)rootClass;
		Debug.Log (rootNode.ToString ());
		byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rootNode.ToString());

		string url = "http://api.playarshop.com/games";
		WWWDic headers = new WWWDic();
		headers["Accept"] = "application/json";
		headers["Content-Type"] = "application/json";
		headers["Authorization"] = id_token;
		StartCoroutine(sendRequest (url, rawData, headers));
	}

	public IEnumerator sendRequest(string url, byte[]rawData, WWWDic headers) {
		WWW www = new WWW(url, rawData, headers);
		yield return www;
		RedirectToHome ();
	}

	[DllImport("__Internal")]
	private static extern string GetIdToken();

	[DllImport("__Internal")]
	private static extern string GetIdGame();

	[DllImport("__Internal")]
	private static extern void RedirectToHome();
}