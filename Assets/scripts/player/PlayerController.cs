using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float jumpForce;

	//Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	void Start () 
	{
		//anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		/*anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (speed));*/

		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space))
		{
			//anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
