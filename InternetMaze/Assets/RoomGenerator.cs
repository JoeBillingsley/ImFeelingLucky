using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour {
	private Room previous;
	private Room current;

	void Start() {
		MakeRoom ("google.com");
	}

	public RoomInfo MakeRoom(string url) {
		RoomInfo info = new RoomInfo ();
		info.url = url;
		info.referrals = new List<string> {info.url};

		var go = new GameObject ();

		Room room = new Room (info, -1, 3, Vector3.zero);

		go.AddComponent <URLHandler>().init(info, room);
		info.data = go;

		return info;
	}
}
