﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {

			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other) {

		if (other.tag != "Boundary") {

			Instantiate (explosion, transform.position, transform.rotation);

			if (other.tag == "Player") {

				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			}

			gameController.AddScore (scoreValue);

			Destroy (other.gameObject);
			Destroy (gameObject);
		} 
	}
}
