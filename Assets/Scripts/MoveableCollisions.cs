using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCollisions : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 9)
        {
           // gameObject.GetComponent<>     (col.gameObject.GetComponent<Damage>().value)
        }
    }
}
