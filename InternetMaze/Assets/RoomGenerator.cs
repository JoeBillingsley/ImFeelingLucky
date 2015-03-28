using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour {
	private Room previous;
	private Room current;

	void Start() {
		MakeRoom ("whatever");
	}

	public void MakeRoom(string s) {
		RoomInfo info = new RoomInfo ();
		info.url = "google";
		List<string> urls = new List<string> ();
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.youtube.com");
		urls.Add ("www.google.com");
		urls.Add ("www.google.com");
		urls.Add ("www.youtube.com");
		info.referrals = urls;

		Room room = new Room (info, -1, 3, "helloworld", Vector3.zero);
	}
}
