using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemyController : MonoBehaviour
{
	public float normalSpeed;
	public int health;
	public int damage;
	public float startStopTime;
	public float startTimeBtwAttack;

	private Player player;
	private Animator anim;

	private float speed;
	private float timeBtwAttack;
	private float stopTime;

	//
	/*private MoveState _moveState = MoveState.Idle;
	//private DirectionState _directionState = DirectionState.Right;

	enum DirectionState
	{ 
		Right,
		Left
	}

	enum MoveState
	{ 
		Idle,
		Run,
		Attack
	}*/





	private Transform target;
	/*[SerializeField]
	//private float speed;
	//[SerializeField]
	private float range;*/

	private void Start()
	{
		anim = GetComponent<Animator>();
		//target = FindObjectOfType<Player_TopDownMovement>().transform;
		target = FindObjectOfType<Player_Boss>().transform;
		player = FindObjectOfType<Player>();
		
	}


	private void Update()
	{
		if (stopTime <= 0)
		{
			speed = normalSpeed;
		}
		else
		{
			speed = 0;
			stopTime -= Time.deltaTime;
		}
		if (health <= 0)
		{
			ScoreScript.scoreValue += 10;
			Destroy(gameObject);
		}
		//if (player.transform.position.x > transform.position.x)
		if (target.transform.position.x > transform.position.x)
		{
			transform.eulerAngles = new Vector3(0, 180, 0); 
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		//transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

	public void TakeDamage(int damage)
	{
		stopTime = startStopTime;
		health -= damage;
	}

	//public void OnTriggerStay(Collider2D other)
	//public void OnTriggerStay(Collider2D collision)
	private void OnTriggerEnter2D(Collider2D other)

	{
		//if (other.CompareTag("Player_Boss"))
		if (other.CompareTag("Player"))
		//if (other.CompareTag("Player_Boss"))

		{
			if (timeBtwAttack <= 0)
			{
				anim.SetTrigger("attack");
			}
			else
			{
				timeBtwAttack -= Time.deltaTime;
			}
		}

	}




	/*public Animation attack;
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collider Entered.");
		if (other.tag == "Player")
		{
			attack.gameObject.GetComponent<KnucklesAnimation>().PlayAnimation();
			//attack.GetComponent<Player_Boss>().PlayAnimation();
			//Destroy(this);
		}

		public void PlayAnimation()
		{
			attack.Play();
		}

	}

}*/

	public Animation attack;

	private void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.GetComponent<MiniEnemyController>().PlayAnimation();
	}

	public void PlayAnimation()
	{
		attack.Play();
	}






	/*
	public void OnEnemyAttack()
	{
		player.ChangeHealth(-damage);
		timeBtwAttack = startTimeBtwAttack;
	}*/


	public void FollowPlayer()
	{
		//anim.SetBool("isMoving", true);
		anim.SetBool("isMoving", true);
		anim.SetFloat("moveX", (target.position.x - transform.position.x));
		anim.SetFloat("moveY", (target.position.y - transform.position.y));
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

}
