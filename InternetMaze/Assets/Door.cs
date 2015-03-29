using UnityEngine;
using System.Collections.Generic;

public class Door {
	public string url;
	private GameObject door;
	private float height;
	private int direction;

	public Door(string url, Vector3 position, Vector3 forward, int direction) {
		this.direction = direction;
		this.url = url;
		GameObject g = GameObject.CreatePrimitive (PrimitiveType.Cube);
		g.transform.localScale = new Vector3 (3, 5, 0.25f);
		g.transform.position = position;
		g.transform.forward = forward;
		g.gameObject.tag = "Door";

		DoorScript doorscript = g.AddComponent<DoorScript> ();
		doorscript.SetDoor (this);
		door = g;
		height = g.transform.localScale.y;
	}

	public float GetHeight() {
		return height;
	}

	public void OnDoorOpen() {
		RoomInfo info = new RoomInfo ();
		info.url = url;
		info.referrals = new List<string> {info.url};
		
		var go = new GameObject ();
		Room room = new Room(info, direction, 3f, door.transform.position, 10f, false);
		
		go.AddComponent <URLHandler>().init(info, room);
		info.data = go;
	}

	public void OnDoorClose() {

	}
}
