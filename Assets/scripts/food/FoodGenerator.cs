using UnityEngine;
using System.Collections;

public class FoodGenerator : MonoBehaviour
{
	public GameObject whiskasPrefab;
	public GameObject meatPrefab;
	public GameObject fishPrefab;


	public void GenerateRandomFood (Vector2 position)
	{
		float rnd = Random.Range (0f, 1f);

		if (rnd < 0.3)
		{
			GenerateFish (position);
		} 
		else if (rnd >= 0.3 && rnd < 0.6) 
		{
			GenerateMeat (position);
		} 
		else
		{
			GenerateWhiskas(position);
		}
	}

	private void GenerateWhiskas (Vector2 position)
	{
		Instantiate (whiskasPrefab, position, Quaternion.identity);
	}

	private void GenerateMeat (Vector2 position)
	{
		Instantiate (meatPrefab, position, Quaternion.identity);
	}

	private void GenerateFish (Vector2 position)
	{
		Instantiate (fishPrefab, position, Quaternion.identity);
	}
}
