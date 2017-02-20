﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	public GameObject explosion;

	Rigidbody rb;
	MeshRenderer meshRenderer;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		meshRenderer = GetComponentInChildren<MeshRenderer> ();
	}
	
	void Update ()
	{
		// Movement
		Vector3 newPosition = transform.position;
		newPosition = newPosition + transform.forward * speed * Time.deltaTime;
		rb.MovePosition (newPosition);

		// Texture Stuff
		float offset = Time.time*-1f;
		meshRenderer.material.SetTextureOffset ("_MainTex", new Vector2 (offset, offset));

		// See if I've gone really far & then delete me.
		if (transform.position.x > 500f || transform.position.x < -500f || 
			transform.position.y > 500f || transform.position.y < -500f || 
			transform.position.z > 500f || transform.position.z < -500f)
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
			collision.gameObject.GetComponent<Enemy> ().Health -= 1;
		}
	}
}
