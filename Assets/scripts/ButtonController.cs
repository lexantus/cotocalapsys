using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{
	public float scaleOver;

	void OnMouseEnter ()
	{
		gameObject.transform.localScale = new Vector3 (scaleOver, scaleOver, scaleOver);
	}

	void OnMouseExit ()
	{
		gameObject.transform.localScale = new Vector3 (1, 1, 1);
	}
}
