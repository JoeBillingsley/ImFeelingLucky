using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class URLHandler : MonoBehaviour {

	private RoomInfo _info;
	const string server = "http://52.17.60.90:8080?url=";

	private IDataLoadedCallback _loaded;

	private int numOfPhotos, currPhoto;

	public void init(RoomInfo info, IDataLoadedCallback loaded) {
		_info = info;
		_loaded = loaded;
		var url = info.url;
		StartCoroutine(GetLinks(url, _info));
		StartCoroutine(GetImages(url, _info));
	}

	public IEnumerator GetLinks(string url, RoomInfo info) {
		var cmd = GetCommand("GetRefDomains", url);
	
		yield return cmd;

		var text = cmd.text.Remove (0, 3);
		text = text.Remove (text.Length - 1);

		var urls = text.Split(new string[] {"', u'" }, StringSplitOptions.None);

		info.referrals.AddRange (urls);

		_loaded.LinksLoaded ();
	}

	public IEnumerator GetImages(string url, RoomInfo info) {
		var cmd = GetCommand("GetImages", url);

		yield return cmd;

		_info.images = new List<Texture2D> ();

		numOfPhotos = _info.images.Count;

		if (cmd.text != null || cmd.text != "") {
			var text = cmd.text.Remove (0, 3);
			text = text.Remove (text.Length - 1);
			
			var imageUrls = text.Split(new string[] { "', u'" }, StringSplitOptions.None);
			
			foreach(var imageUrl in imageUrls) {
				StartCoroutine(GetImage (url));
			}
			
			_loaded.ImagesLoaded ();
		}

	}

	private IEnumerator GetImage(string imageUrl) {
		var cmd = new WWW(imageUrl);

		yield return cmd;
	
		_info.images.Add (cmd.texture);
		currPhoto ++;

		if (currPhoto == numOfPhotos) {
			_loaded.ImagesLoaded();
		}

	}

	private WWW GetCommand(string command, string url) {
		var cmd = new WWW(server + url + "&command=" + command);
		return cmd;
	}
}
