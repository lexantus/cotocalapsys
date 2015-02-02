using UnityEngine;
using System.Collections;

public class BGSprite : MonoBehaviour {

    private BackGroundController bgController;
    private LevelGenerator levelGenerator;

    void Awake() {
        bgController = transform.parent.GetComponent<BackGroundController>();
        if( bgController == null ) {
            Debug.Log( "Background Controller not founded!" );
        }

        levelGenerator = GameObject.FindObjectOfType<LevelGenerator>();
        if( levelGenerator == null ) {
            Debug.Log( "Level generator not founded!" );
        }
    }

    void OnBecameInvisible() {
        if( transform == bgController.BackGround[0].transform ) {
            levelGenerator.PlatformGenerate( bgController.BackGround[1] );
            bgController.Flip();
        }
    }
}
