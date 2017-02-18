using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreyFoodScript : MonoBehaviour {

	public AudioClip mySFX;

	float cooldown = 0.4f;

	public float minSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		cooldown += Time.deltaTime;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (cooldown >= 0.4f && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > minSpeed) {
			CoreySoundManager.Instance.PlaySFX (mySFX);
			cooldown = 0f;
		}
	}
}
