using UnityEngine;
using System.Collections;

public class ShitGenerator : MonoBehaviour
{
	public GameObject shit;
//	public Camera camera;

	public float startWait;
	public float makeShitWait;

	public float distanceXFromProducerAss;
	public float sizeShitFactor;

	private float shitScale;

	void Start ()
	{
		StartCoroutine (MakeShit ());
	}

	IEnumerator MakeShit()
	{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			Vector2 shitPosition = new Vector2 (gameObject.transform.position.x - distanceXFromProducerAss, gameObject.transform.position.y);
			Instantiate(shit, shitPosition, Quaternion.identity);
			shitScale = sizeShitFactor * 0.5f;
			shit.transform.localScale = new Vector3(shitScale, shitScale, shitScale);
			yield return new WaitForSeconds (makeShitWait);
		}
	}
}
