using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        GetUserMovement();
    }

    void GetUserMovement()
    {
        Vector2 pos = transform.position;
        bool xplusz = CheckIfDiagonal();
        var speedToUse = GetCurrentMovementSpeed();
        if (xplusz)
            speedToUse *= DividedByHipotnouse(speedToUse);

        if ((Input.GetKey("w") || Input.GetKey("up")))
        {
            pos.y += speedToUse * Time.deltaTime;
        }
        if ((Input.GetKey("s") || Input.GetKey("down")))
        {
            pos.y -= speedToUse * Time.deltaTime;
        }
        if ((Input.GetKey("d") || Input.GetKey("right")))
        {
            pos.x += speedToUse * Time.deltaTime;
        }
        if ((Input.GetKey("a") || Input.GetKey("left")))
        {
            pos.x -= speedToUse * Time.deltaTime;
        }
        transform.position = pos;
        //Make player sprite go all sides (8 to be exact)
    }

    bool CheckIfDiagonal()
    {
        if (Input.GetKey("w") && Input.GetKey("d") || Input.GetKey("w") && Input.GetKey("a") || Input.GetKey("s") && Input.GetKey("d") || Input.GetKey("s") && Input.GetKey("a") ||
            Input.GetKey("up") && Input.GetKey("right") || Input.GetKey("up") && Input.GetKey("left") || Input.GetKey("down") && Input.GetKey("right") || Input.GetKey("down") && Input.GetKey("left"))
            return true;
        return false;
    }

    float DividedByHipotnouse(float catetos)
    {
        float resultSpeed = catetos / Mathf.Sqrt(catetos * catetos * 2);
        return resultSpeed;
    }

    float GetCurrentMovementSpeed()
    {
        return PlayerStats.instance.MovementSpeed.Value;
    }
}