using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatamariMoveScript : MonoBehaviour {

	public float speed = 800.0f;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}

	void Update() {
		if (transform.position.y < -20f) {
			transform.position = Vector3.up * 2f;
		}
	}

//	// get the rigidbody
//	Rigidbody rb;
//
//	// a "thrust" multiplier
//	public float thrust;
//
//	// Use this for initialization
//	void Start () {
//
//		rb = this.GetComponent<Rigidbody> ();
//
//	}
//
//	// THIS ISN'T WORKING but i almost don't care
//	// FixedUpdate is for physics things
//	void FixedUpdate () {
//
//		// make it roll
//		if (Input.GetMouseButton (0)) {
//			rb.AddForce (transform.forward * thrust, ForceMode.Acceleration);
//			Debug.Log ("it's moving " + this.transform.position.x + " + " + this.transform.position.z);
//		}
//
//		// make it roll...backwards
//		// which, by the way, is nauseating
//		if (Input.GetMouseButton (1)) {
//			rb.AddForce (transform.forward * (thrust/-2), ForceMode.Impulse);
//			Debug.Log ("it's regressing " + this.transform.position.x);
//		}
//
//		if (Input.GetKeyDown (KeyCode.A)) {
//			rb.AddForce (transform.right * (thrust/-), ForceMode.Acceleration);
//		}
//
//		if (Input.GetKeyDown (KeyCode.D)) {
//			rb.AddForce (transform.right * (thrust), ForceMode.Acceleration);
//		}
//		
//	}
}
