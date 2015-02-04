using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour 
{
	public int Score;
	
	void OnTriggerEnter2D( Collider2D col ) 
	{
		if( col.name == "Player" ) 
		{
			col.GetComponent<PlayerController>().GetScore( (long)Score );
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().foodCount += 1f;
			Destroy( this.gameObject );
		}
	}
}