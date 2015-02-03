using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour 
{
	public GameObject platformPrefab;

	public int minNumPlatformSegments = 1;
	public int maxNumPlatformSegmants = 3;

	public float prefabWidth = 10f;

	public void CreatePlatforms(Vector2 position, int platformsNum)
	{
		for (int i = 0; i < platformsNum; i++)
		{
			int numSegments = Random.Range(minNumPlatformSegments, maxNumPlatformSegmants);

			int rndOffsetUpY;
			int rndOffsetDownY;

			rndOffsetUpY = Random.Range(2, 3);
			rndOffsetDownY = Random.Range(2, 3);

			int rndForDecideDirection = Random.Range(0, 10);
			
			if (rndForDecideDirection > 5)
			{
				position.y -= rndOffsetDownY;
				
			}else
			{	
				position.y += rndOffsetUpY;
			}
			
			CreatePlatformAt(position, numSegments);
			position.x += 0.4f * numSegments;
		}
	}

	private void CreatePlatformAt(Vector2 position, int numOfSefments)
	{
		for (int i = 0; i < numOfSefments; i++) 
		{
			if (i != 0)
			{
				 position.x += 0.5f;
			}

			Instantiate (platformPrefab, position, Quaternion.identity);
		}
	}
}
