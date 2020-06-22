using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//Пихаем всю логику управления персонажем в один класс. Да за такое ломают руки, но всё же почему бы и нет?
public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float PowerJump;
	public Transform SpawnPoint;

	[SerializeField] private bool isGrounded;
	[SerializeField] private bool FaceLeft = false;

	[Header("Зависимости")]
	[SerializeField] private Animator animator;
	[SerializeField] private PlayerData Data;
	[SerializeField] private SpriteRenderer Sprite;
	[SerializeField] private Rigidbody2D RigidBody;
	[SerializeField] private CircleCollider2D Circle;
	[SerializeField] private BoxCollider2D Box;
	[Header("Костыли")]
	[SerializeField] private List<Collider2D> GroundColliders;
	Transform PlayerTransform;
	void Start()
	{
		Box = GetComponent<BoxCollider2D>();
		Circle = GetComponent<CircleCollider2D>();
		RigidBody = GetComponent<Rigidbody2D>();
		Sprite = GetComponent<SpriteRenderer>();
		PlayerTransform = GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (Data.Life <= 0)
		{
			Death();
		}

		if (GroundColliders.Count > 0)
		{
			foreach(var coll in GroundColliders)
			{
				if(coll.tag == "Ground")
					isGrounded = true;
			}
			
		}
		else
		{
			isGrounded = false;
		}
			
		if (Input.GetButton("Horizontal"))
		{
			animator.SetBool("PerformRun", true);
			animator.SetBool("PerformIdle", false);
			Move();
		}
		else
		{
			animator.SetBool("PerformRun", false);
			animator.SetBool("PerformIdle", true);
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Sprite.flipX = true;
			FaceLeft = true;
		}

		if(Input.GetKey(KeyCode.D))
		{
			Sprite.flipX = false;
			FaceLeft = false;
		}

		if (Input.GetKeyDown("space"))
		{
			Jump();
		}
		
		if (Input.GetKey("space"))
		{
			animator.SetBool("PerformIdle", false);
			animator.SetBool("PerformJump", true);
		}
		else
		{
			animator.SetBool("PerformJump", false);
		}

		if (isGrounded)
		{
			Data.CountJump = Data.MaxJump;
		}

		if (Input.GetKey(KeyCode.Q))
		{
			Application.Quit();
		}
	}

	void FixedUpdate()
	{
		
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (!GroundColliders.Contains(coll.collider))
			foreach (var p in coll.contacts)
				if (p.point.y < Box.bounds.min.y)
				{
					GroundColliders.Add(coll.collider);
					break;
				}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (GroundColliders.Contains(coll.collider))
			GroundColliders.Remove(coll.collider);
	}
	void Move()
	{
		Vector3 vector = Vector3.right * Input.GetAxis("Horizontal");
		transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, Speed * Time.deltaTime);
	}

	void Jump()
	{
		if (Data.CountJump > 0)
		{
			Data.CountJump--;
			RigidBody.velocity = Vector2.up * PowerJump;
		}
	}

	public void Death()
	{
		Data.Score = 0;
		Data.MaxJump = 1;
		Data.CountJump = 1;
		Data.Life = Data.MaxLife;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Damage()
	{
		Data.Life--;
		PlayerTransform.position = SpawnPoint.position;
	}

	public void SetSpawn(Transform point)
	{
		SpawnPoint = point;
	}
}
