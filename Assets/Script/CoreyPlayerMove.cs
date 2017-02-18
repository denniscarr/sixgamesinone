using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreyPlayerMove : MonoBehaviour {

	// Finds the average position of sprites for camera movement
	public Transform positionDummy;

	public float forceMultiplier;

	public Vector2 playerPosition;


	void Start () {
		
	}


	void Update() {
		Vector3 newPosition = new Vector3 (playerPosition.x, playerPosition.y, transform.position.z);
		positionDummy.position = newPosition;
	}

	
	void FixedUpdate () {

		Rigidbody2D[] childBodies = gameObject.GetComponentsInChildren <Rigidbody2D>();

		Rigidbody2D topChild = childBodies[0];
		playerPosition = new Vector2(topChild.transform.position.x, topChild.transform.position.y);

		for (int i = 1; i < childBodies.Length; i++) {
			playerPosition.x += childBodies [i].transform.position.x;
			playerPosition.y += childBodies [i].transform.position.y;
			if (childBodies [i].transform.position.y > topChild.transform.position.y) {
				topChild = childBodies [i];
			
			}
		}
		playerPosition /= childBodies.Length;
//		Camera.main.transform.position = new Vector3 (playerPosition.x, playerPosition.y, -10f);

		if (Input.GetAxis ("Horizontal") != 0f) {
			topChild.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * forceMultiplier, 0f));
			Debug.Log (Input.GetAxis ("Horizontal") * forceMultiplier);
		}

		
	}
}
