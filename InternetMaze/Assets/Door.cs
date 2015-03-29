using UnityEngine;
using System.Collections;

public class Door {
	private string url;
	private GameObject door;
	private float height;

	public Door(string url, Vector3 position, Vector3 right) {
		this.url = url;
		GameObject g = GameObject.CreatePrimitive (PrimitiveType.Cube);
		g.transform.localScale = new Vector3 (3, 5, 0.25f);
		g.transform.position = position;
		g.transform.right = right;
		g.gameObject.tag = "Door";

		DoorScript doorscript = g.AddComponent<DoorScript> ();
		doorscript.SetDoor (this);
		height = g.transform.localScale.y;
		g.transform.position += Vector3.up * height / 2;
	}

	public float GetHeight() {
		return height;
	}

	public void OnDoorOpen() {

	}

	public void OnDoorClose() {

	}
}
