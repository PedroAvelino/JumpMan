using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Image HeartUi;
	private PlayerControler player;



	// Use this for initialization
	void Awake () {

		player = GameObject.FindObjectOfType<PlayerControler> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		HeartUi.sprite = HeartSprites[player.curHealth];
		
	}
}
