using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    void OnBecameInvisible() {
        Destroy( gameObject );
    }
}
