using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private PlayerController playerController;

	private BackgroundTileGenerator bgGenerator;
	private PlatformGenerator platformGenerator;
	private FoodGenerator foodGenerator;

	void Start ()
	{
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
	}

	void Update ()
	{
		if (playerController.transform.position.y < -15) 
		{
			Application.LoadLevel("menu_scene");		
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
