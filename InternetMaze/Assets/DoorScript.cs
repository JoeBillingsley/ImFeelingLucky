using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	private bool moving = false;
	private bool open = false;
	private Vector3 closedPosition;
	private Vector3 openPosition;
	private Door door;

	// Use this for initialization
	void Start () {
		closedPosition = transform.position;
		openPosition = closedPosition + transform.right * transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			ToggleOpen();
		}

		if (!moving) {
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

	public void SetDoor(Door door) {
		this.door = door;
	}
}
