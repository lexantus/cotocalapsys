using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public float Speed;
    public GameObject PlatformPrefab;

    public int platformAmount;

    private Transform cameraTransform;
	
	void Update () {
        transform.position += Vector3.right * ( Speed + Time.deltaTime );
	}

    public void PlatformGenerate( SpriteRenderer sp ) {
        for( int i = 0; i < platformAmount; ++i ) {
            GameObject platform = GameObject.Instantiate( PlatformPrefab ) as GameObject;
            float width = Mathf.FloorToInt( sp.bounds.size.x );
            float height = Mathf.FloorToInt( sp.bounds.size.x );
            width -= platform.renderer.bounds.size.x;
            height -= platform.renderer.bounds.size.y;
            platform.transform.position = sp.transform.position + new Vector3( Random.Range( 0, width / 2 ), Random.Range( 0, height / 2 ) );
            platform.name = "Platform";
        }
    }
}
