using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public int Score;

    void OnTriggerEnter2D( Collider2D col ) {
        if( col.name == "Player" ) {
            col.GetComponent<PlayerController>().GetScore( (long)Score );
            Destroy( this.gameObject );
        }
    }
}
