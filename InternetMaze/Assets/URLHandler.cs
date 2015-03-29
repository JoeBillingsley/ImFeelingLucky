using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class URLHandler : MonoBehaviour {

	private RoomInfo _info;

	const string server = "http://52.16.60.90:8080?url=";

	public void init(RoomInfo info) {
		_info = info;
		
		var url = info.url;
		StartCoroutine(GetLinks(url, _info));
	}

	public IEnumerator GetLinks(string url, RoomInfo info) {
		var cmd = GetCommand("GetRefDomains", url);

		Debug.Log (cmd.url);

		yield return cmd;

		Debug.Log (cmd.isDone);
		Debug.Log (cmd.text);

		var text = cmd.text.Remove(0, 2).Remove(cmd.text.Length - 3, 2);
		var urls = text.Split(new string[] {"', u'" }, StringSplitOptions.None);
		info.referrals.AddRange (urls);
	}

	public void GetImages(string url, RoomInfo info) {
		var cmd = GetCommand("GetImages", url);

		var text = cmd.text.Remove(0, 2).Remove(cmd.text.Length, 2);
		var urls = text.Split(new string[] { "', u'" }, StringSplitOptions.None);
	}
	
	private WWW GetCommand(string command, string url) {
		var request = new WWW(server + url + "&command=" + command);
		return request;
	}
}
