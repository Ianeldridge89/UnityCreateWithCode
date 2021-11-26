using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Movement : MonoBehaviour
{
    private int movementSpeed = 10;
    private float leftRange;
    private float rightRange;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        SetBoundaries(-8.0f, 12.0f, false);
    }

    // Update is called once per frame
    void Update()
    {

        if (movingRight)
        {
            MoveRight();
            if (transform.position.z > rightRange)
            {
                movingRight = false;
            }
        }
        else if (!movingRight)
        {
            MoveLeft();
            if (transform.position.z < leftRange)
            {
                movingRight = true;
            }
        }

    }

    // Moves the player left based on movement speed.
    void MoveLeft()
    {
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }

    // Moves the player left based on movement speed.
    void MoveRight()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    // Takes the left and right ranges as arguments aswell as the direction the object is initially moving in.
    void SetBoundaries(float lRange, float rRange, bool rightCondition)
    {
        leftRange = lRange;
        rightRange = rRange;
        movingRight = rightCondition;
    }
}


