using UnityEngine;
using System.Collections;

public class PacketAI : MonoBehaviour {

	GameObject targetDoor;

	bool swapAxis = false;

	// Use this for initialization
	void Start () {
		var doors = GameObject.FindGameObjectsWithTag ("Door");

		var r1 = Random.Range (0, doors.Length);
		var r2 = Random.Range (0, doors.Length);

		var startingDoor = doors [r1];
		targetDoor = doors [r2];

		transform.position = startingDoor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		var xDiff = targetDoor.transform.position.x - transform.position.x;
		var zDiff = targetDoor.transform.position.z - transform.position.z;

		var acc = Time.deltaTime / 6;

		var xVector = new Vector3 (xDiff, 0, 0) * acc;
		var zVector = new Vector3 (0, 0, zDiff) * acc;

		if (xDiff < 1 || xDiff > -1) {
			swapAxis = true;
		}

		if (swapAxis) {
			transform.position += xVector;
		} else {
			transform.position += zVector;
		}
	}
	
}
