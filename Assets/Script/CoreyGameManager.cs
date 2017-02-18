using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreyGameManager : MonoBehaviour {

	public GameObject player;

	public float levelBoundsX = 40f;
	public float levelBoundsY = 30f;

	public GameObject Level;

	public GameObject[] FoodObjects;

	//[SerializeField] GameObject myFood;
	[SerializeField] int maxFood = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerPosition = player.GetComponent<CoreyPlayerMove> ().playerPosition;

		if (playerPosition.x > Level.transform.position.x + levelBoundsX) {
			Level.transform.position = new Vector3( playerPosition.x + 30f, playerPosition.y, 0f);
		} else if (playerPosition.x < Level.transform.position.x - levelBoundsX) {
			Level.transform.position = new Vector3( playerPosition.x - 30f, playerPosition.y, 0f);
		} else if (playerPosition.y > Level.transform.position.y + levelBoundsY) {
			Level.transform.position = new Vector3( playerPosition.x, playerPosition.y + 30f, 0f);
		} else if (playerPosition.y < Level.transform.position.y - levelBoundsY) {
			Level.transform.position = new Vector3( playerPosition.x, playerPosition.y - 30f, 0f);
		}

		GameObject[] myFood = GameObject.FindGameObjectsWithTag ("CoreyFood");
		if (myFood.Length > maxFood) {
			Destroy (myFood [maxFood], 2.0f);
		}

		//TESTING FUNCTION
		if (Input.GetKeyDown (KeyCode.G)) {
			JennaObjectPickup ();
		}

	}

	public void JennaObjectPickup() {
		//called when object in jenna's scene is picked up

		Vector3 playerPosition = new Vector3 (player.GetComponent<CoreyPlayerMove> ().playerPosition.x, player.GetComponent<CoreyPlayerMove> ().playerPosition.y, 0f);
		Instantiate(FoodObjects[Random.Range(0,FoodObjects.Length)], playerPosition, Quaternion.identity);


	}
}
