using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour {
	private Room previous;
	private Room current;

	void Start() {
		MakeRoom ("majestic.co.uk");
	}

	public void MakeRoom(string url) {
		RoomInfo info = new RoomInfo ();
		info.url = url;
		info.referrals = new List<string> {info.url};

		var go = new GameObject ();
		go.AddComponent <URLHandler>().init(info);

		info.data = go;

		Room room = new Room (info, -1, 3, Vector3.zero);
	}
}
