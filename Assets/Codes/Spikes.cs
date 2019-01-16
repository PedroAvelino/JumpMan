using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	public GameObject Spike;
	float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 4f;
	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-4.0f, 4.0f);
			whereToSpawn = new Vector2 (randX, transform.position.y);
			Instantiate (Spike, whereToSpawn, Quaternion.identity);
		}

	}
}
