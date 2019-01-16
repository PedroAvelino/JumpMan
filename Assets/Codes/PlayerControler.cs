using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    
	public bool onAir = false;
    public float velocidade = 0;
    

    public Rigidbody2D rigbody;

    //Detecta se está na parede ou não\\
	float raioWall = 0.5f;
	public bool onWall = false;
	public bool onOtherWall = false;
	public Transform wallCheck;
	public LayerMask isOnOtherWall;
    public LayerMask isOnWall;


	//GameMaster\\
	public gameMaster gm;


	public float jumpForce = 0;


	//Vida\\
	public int curHealth;
	public int maxHealth;


    // Use this for initialization
	void Awake()
    {

		curHealth = maxHealth;

        rigbody = GetComponent<Rigidbody2D>();
		gm = FindObjectOfType<gameMaster>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");



		onWall = Physics2D.OverlapCircle(wallCheck.position, raioWall, isOnWall);
		onOtherWall = Physics2D.OverlapCircle (wallCheck.position, raioWall, isOnOtherWall);
       


		Movement (h, v);
            

		//if (jumping) 
		//{
	//		jumping = false;
	//	}
    }


	void Update()
	{

		//Pulo do Personagem\\

		if(onWall && Input.GetButtonDown("Jump"))
		{

			GetComponent<Rigidbody2D>().velocity = new Vector2(jumpForce, 0f);
			//jumping = true;
		}

		if(onOtherWall && Input.GetButtonDown("Jump"))
		{

			GetComponent<Rigidbody2D>().velocity = new Vector2(-jumpForce, 0f);
		//	jumping = true;



			//switch (curHealth)
		//	{
		//	case curHealth = 0:
		//			Application.LoadLevel (Application.);
		//		break;
		//	case valor2:
				// código 2
		//		break;
		//	}



		}



		if (!onWall && !onOtherWall) 
		{
			onAir = true;
		}

		if (curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}

		if (curHealth <= 0) 
		{
			Morte ();
		}


	}


	void Movement(float h, float v)
	{

		if (onWall || onOtherWall) 
		{
			rigbody.velocity = new Vector2 (rigbody.velocity.x , v * velocidade);


			onAir = false;
		}



	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Coin")) 
		{
			Destroy (col.gameObject);
			gm.points += 1;
		}

		if (col.CompareTag ("Spike")) 
		{
			Destroy (col.gameObject);
			Dano (1);
		}


		//if (col.CompareTag ("Respawn"))
		//{
		//	Application.LoadLevel (Application.loadedLevel);
		//}

	}

	void Morte()
	{
		//Restart\\
		Application.LoadLevel (Application.loadedLevel);
	}


	public void Dano(int dmg)
	{
		curHealth -= dmg;
	}

}
