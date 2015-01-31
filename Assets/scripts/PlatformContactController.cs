using UnityEngine;
using System.Collections;

public class PlatformContactController : MonoBehaviour
{
	private BoxCollider2D platformCollider;
	private CircleCollider2D playerCollider;

	// Use this for initialization
	void Start () 
	{
		platformCollider = GetComponent <BoxCollider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		HandlePlatformCollider (other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		HandlePlatformCollider (other);
	}

	void HandlePlatformCollider(Collider2D other)
	{
		if (other.tag == "Player")
		{
			playerCollider = other.gameObject.GetComponent <CircleCollider2D> ();
			
			if (playerCollider.transform.position.y < platformCollider.transform.position.y)
			{
				if (!platformCollider.isTrigger)
				{
					platformCollider.isTrigger = true;
				}
				
			}else
			{
				if (platformCollider.isTrigger)
				{
					platformCollider.isTrigger = false;
				}
			}
		}

	}
}
