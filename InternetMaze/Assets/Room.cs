using UnityEngine;
using System.Collections.Generic;

public class Room {
	private float door_width;
	private int direction;
	private Vector3 room_centre;
	private List<string> referrals;

	public Room(RoomInfo info, int direction, float door_width, string origin_url, Vector3 last_edge_center) {
		this.door_width = door_width;
		this.direction = direction;

		referrals = new List<string>();
		referrals.Add (origin_url);
		referrals.AddRange (info.referrals);

		float edgeLength = door_width * (1 + 2 * referrals.Count);
		Vector3 centre_modifier = new Vector3();
		switch (direction) {
		case 0:
			centre_modifier = new Vector3(0, 0, edgeLength / 2);
			break;
		case 1:
			centre_modifier = new Vector3(edgeLength/2, 0, 0);
			break;
		case 2:
			centre_modifier = new Vector3(0, 0, -(edgeLength / 2));
			break;
		case 3:
			centre_modifier = new Vector3(-(edgeLength/2), 0, 0);
			break;
		default:
			room_centre = Vector3.zero;
			break;
		}

		room_centre = last_edge_center + centre_modifier;
		BuildFloor (edgeLength);
		BuildCeiling (edgeLength);

		int edge_index = direction;
		for (int i = 0; i < referrals.Count; i++) {
			PlaceDoorOnEdge(edge_index, i, edgeLength, door_width);
			edge_index = ++edge_index%4;
		}
	}

	//0 = N
	//1 = E
	//2 = S
	//3 = W
	private void PlaceDoorOnEdge(int edge_index, int i, float edgeLength, float door_width) {
		Vector3 origin_point;
		Vector3 direction;
		switch (edge_index) {
		case 0:
			direction = new Vector3(1, 0, 0);
			origin_point = room_centre + new Vector3(-(edgeLength/2), 0, (edgeLength/2)) + direction * Mathf.Floor(i/4) * door_width * 2;
			break;
		case 1:
			direction = new Vector3(0, 0, -1);
			origin_point = room_centre + new Vector3((edgeLength/2), 0, (edgeLength/2)) + direction * Mathf.Floor(i/4) * door_width * 2;
			break;
		case 2:
			direction = new Vector3(-1, 0, 0);
			origin_point = room_centre + new Vector3((edgeLength/2), 0, -(edgeLength/2)) + direction * Mathf.Floor(i/4) * door_width * 2;
			break;
		case 3:
			direction = new Vector3(0, 0, 1);
			origin_point = room_centre + new Vector3(-(edgeLength/2), 0, -(edgeLength/2)) + direction * Mathf.Floor(i/4) * door_width * 2;
			break;
		default:
			break;
		}

		//now spawn the door itself.
		//first spawn the wall segment.
		GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		wall.transform.localScale = new Vector3 (door_width, edgeLength, 1);
		wall.transform.position = origin_point + direction * door_width/2;

		origin_point += direction * door_width;
		Door door = new Door (referrals [i], origin_point + direction * door_width / 2);

		GameObject above = GameObject.CreatePrimitive (PrimitiveType.Cube);
		above.transform.localScale = new Vector3 (door_width, edgeLength - door.GetHeight(), 1);
		above.transform.position = origin_point + direction * door_width/2 + 
			Vector3.up * door.GetHeight() + above.transform.localScale.y /2;
	}

	private void BuildFloor(float edgeLength) {
		GameObject floor = GameObject.CreatePrimitive (PrimitiveType.Cube);
		floor.transform.localScale = new Vector3 (edgeLength, 1, edgeLength);
		floor.transform.position = new Vector3 (0, 0.5f, 0);
	}

	private void BuildCeiling(float edgeLength) {
		GameObject floor = GameObject.CreatePrimitive (PrimitiveType.Cube);
		floor.transform.localScale = new Vector3 (edgeLength, 1, edgeLength);
		floor.transform.position = new Vector3 (0, 0.5f + edgeLength, 0);
	}
}
