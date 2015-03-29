using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	private bool moving = false;
	private bool open = false;
	private Vector3 closedPosition;
	private Vector3 openPosition;
	private Door door;
	private GameObject player;
	
	private URLHandler data;

	// Use this for initialization
	void Start () {
		closedPosition = transform.position;
		openPosition = closedPosition + transform.right * transform.localScale.x;
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.GetComponent<Renderer> ().material.color = new Color (0.3294117647f, 0.4588235294f, 0.4235294118f);
	


		// Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonUp ("Jump")) {
			if (Vector3.Distance (transform.position, player.transform.position) < 5) {
				ToggleOpen();
			}
		}

		if(!moving) {
			return;
		}

		if (open) {
			openPosition = closedPosition + transform.right * transform.localScale.x;
			transform.position = Vector3.Lerp (transform.position, openPosition, 0.5f);
			if (Vector3.Distance (openPosition, transform.position) < 0.1f) {
				transform.position = openPosition;
				moving = false;
				door.OnDoorOpen();
			}
		} else {
			closedPosition = openPosition - transform.right * transform.localScale.x;
			transform.position = Vector3.Lerp (transform.position, closedPosition, 0.5f);
			if (Vector3.Distance (closedPosition, transform.position) < 0.1f) {
				transform.position = closedPosition;
				moving = false;
				door.OnDoorClose();
			}
		}
	}

	public void ToggleOpen() {
		open = !open;
		moving = true;
	}

	private void Load() {
		var a = new GameObject ();
		a.AddComponent<RoomGenerator> ();
		var b = a.GetComponent<RoomGenerator> (); // This is stupid, is there not a better way?
		
		var info = b.MakeRoom (door.url);
		
		data = info.data.GetComponent<URLHandler> ();
	}

	public void SetDoor(Door door) {
		this.door = door;
	}
}
