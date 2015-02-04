using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private PlayerController playerController;

	private BackgroundTileGenerator bgGenerator;
	private PlatformGenerator platformGenerator;
	private FoodGenerator foodGenerator;

	public float foodCount;

	void Start ()
	{
		foodCount = 4f;

		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent <PlayerController> ();
		platformGenerator = GetComponent <PlatformGenerator> ();

		platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x + 10f, 10f), 10);
		platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x, 0f), 10);
		platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x, -10f), 10);
		
		bgGenerator = GetComponent <BackgroundTileGenerator> ();

		foodGenerator = GetComponent <FoodGenerator> ();

		StartCoroutine (MakePlatforms());
		StartCoroutine (MakeFood ());
		StartCoroutine (MakeBgs ());
		StartCoroutine (MakeHungry ());

	}

	void Update ()
	{
		if (playerController.transform.position.y < -15)
		{
			Application.LoadLevel("respawn_scene");		
		}
	}

	IEnumerator MakeBgs()
	{
		while (true)
		{
			bgGenerator.CreateNextTiles();
			
			yield return new WaitForSeconds (1.5f);
		}
	}

	IEnumerator MakeHungry()
	{
		while (true)
		{
			foodCount -= 0.3f;

			if (foodCount < 0f)
			{
				foodCount = 0f;
			}

			BoxCollider2D boxCol = playerController.GetComponent <BoxCollider2D>();
			ShitGenerator shitGenerator = playerController.GetComponent <ShitGenerator> ();

			if (foodCount > 5f)
			{
				// big
				boxCol.size = new Vector2(4.86f, 3.98f);
				boxCol.center = new Vector2(0f, 0f);

				shitGenerator.makeShitWait = 0.2f;
				shitGenerator.distanceXFromProducerAss = 0.7f;
				shitGenerator.sizeShitFactor = 0.7f;

			}
			else if(foodCount > 2f)
			{
				// med
				boxCol.size = new Vector2(4.86f, 3.6f);
				boxCol.center = new Vector2(0f, 0f);

				shitGenerator.makeShitWait = 0.3f;
				shitGenerator.distanceXFromProducerAss = 0.5f;
				shitGenerator.sizeShitFactor = 0.5f;
			}
			else
			{
				// thin
				boxCol.size = new Vector2(4.16f, 3.02f);
				boxCol.center = new Vector2(0f, -0.11f);

				shitGenerator.makeShitWait = 0.4f;
				shitGenerator.distanceXFromProducerAss = 0.3f;
				shitGenerator.sizeShitFactor = 0.3f;
			}

			Debug.Log(foodCount);

			playerController.anim.SetFloat ("foodCount", foodCount);
			
			yield return new WaitForSeconds (1f);
		}
	}
	

	IEnumerator MakePlatforms()
	{
		yield return new WaitForSeconds (15f);

		while (true)
		{
			platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x + 10f, 10f), 10);
			platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x + 10f, 0f), 10);
			platformGenerator.CreatePlatforms (new Vector2 (playerController.transform.position.x + 10f, -10f), 10);
			
			yield return new WaitForSeconds (15f);
		}

	}

	IEnumerator MakeFood()
	{
		while (true)
		{
			foodGenerator.GenerateRandomFood(new Vector2 (playerController.transform.position.x + 10f, 10f));
			
			yield return new WaitForSeconds (1.5f);
		}
	}

}
