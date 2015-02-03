using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour
{
    public SpriteRenderer[] BackGround;

    private float width;


    void Start () 
	{
        width = Mathf.FloorToInt( BackGround[0].bounds.size.x );
    }

    public void Flip ()
	{
        SpriteRenderer sp = BackGround[0];
        BackGround[0] = BackGround[1];
        BackGround[1] = sp;
        sp.transform.position += Vector3.right * width * 2.0f;
    }
}
