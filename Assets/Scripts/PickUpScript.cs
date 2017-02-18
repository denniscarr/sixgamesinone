using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

	// variables for changing the size of the eaten item
	float xScale;
	float yScale;
	float zScale;
	Vector3 scaleHalf;

	// storing variables and properties for the text script
	public Vector3 location;
	public float posX;
	public float posY;
	public float posZ;

	// when it touches a collider, pick it up
	public void OnCollisionEnter (Collision other){

		// store the location of the item
		// find a way to make it permanent? maybe save it?
		locationStore(other);
		GameObject.Find ("CoreyGameManager").SendMessage ("JennaObjectPickup");
		// pick up object it touches
		if (!other.gameObject.name.Contains ("Plane")) {

			other.transform.parent = this.gameObject.transform;

			// make object smaller
			xScale = other.gameObject.transform.localScale.x;
			yScale = other.gameObject.transform.localScale.y;
			zScale = other.gameObject.transform.localScale.z;

			Vector3 scaleHalf = new Vector3 (xScale / 2, yScale / 2, zScale / 2);
		}
	}

	public void locationStore (Collision other){

		posX = other.gameObject.transform.position.x;
		posY = other.gameObject.transform.position.y;
		posZ = other.gameObject.transform.position.z;

		location = new Vector3 (posX, posY, posZ);

		Debug.Log ("STORED" + location);

	}
}
