using UnityEngine;
using System.Collections;

public class LoadSceneWhenMouseReleased : MonoBehaviour 
{
	public string sceneToLoadName;

	void OnMouseUpAsButton()
	{
		Application.LoadLevel(sceneToLoadName);
	}

}
