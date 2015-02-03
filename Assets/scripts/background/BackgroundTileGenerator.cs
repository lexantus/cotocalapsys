using UnityEngine;
using System.Collections;

public class BackgroundTileGenerator : MonoBehaviour {

	public GameObject bgPrefab;

	private float bgWidth = 10.24f;
	private float bgHeight = 5.12f;

	private int tilesKitCount = 0;

	public void CreateNextTiles()
	{
		CreateBgTiles (new Vector2 (bgWidth * tilesKitCount, 0f));
		CreateBgTiles (new Vector2 (bgWidth * tilesKitCount, 3 * bgHeight));
		CreateBgTiles (new Vector2 (bgWidth * tilesKitCount, -3 * bgHeight));
		
		tilesKitCount ++;
	}
	
	void CreateBgTiles(Vector2 position)
	{
		Vector3 position_1 = new Vector3 (position.x, position.y + bgHeight, 2f);
		Vector3 position_2 = new Vector3 (position.x + bgWidth, position_1.y, 2f);
		Vector3 position_3 = new Vector3 (position.x, position.y, 2f);
		Vector3 position_4 = new Vector3 (position.x + bgWidth, position.y, 2f);
		Vector3 position_5 = new Vector3 (position.x, position.y - bgHeight, 2f);
		Vector3 position_6 = new Vector3 (position.x + bgWidth, position.y - bgHeight, 2f);

		Instantiate (bgPrefab, position_1, Quaternion.identity);
		Instantiate (bgPrefab, position_2, Quaternion.identity);
		Instantiate (bgPrefab, position_3, Quaternion.identity);
		Instantiate (bgPrefab, position_4, Quaternion.identity);
		Instantiate (bgPrefab, position_5, Quaternion.identity);
		Instantiate (bgPrefab, position_6, Quaternion.identity);
	}
}
