using UnityEngine;
using System.Collections;

public class ShitGenerator : MonoBehaviour {

	public Player player;
	public GameObject shit;

	public float startWait;
	public float makeShitWait;

	public float distanceXFromCatAss;

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine (
	}
	
	IEnumerator MakeShit()
	{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			Vector2 shitPosition = new Vector2 (gameObject.transform.x - distanceXFromCatAss, gameObject.transform.y);
			Instantiate(shit, shitPosition);
			yield return new WaitForSeconds (makeShitWait);
		}
	}
}
