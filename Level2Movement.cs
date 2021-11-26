using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Movement : MonoBehaviour
{
    private int movementSpeed = 8;
    private float leftRange;
    private float rightRange;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Level2Block1"))
        {
            SetBoundaries(-8.0f, 1.0f, false);
        }
        else if (gameObject.CompareTag("Level2Block2"))
        {
            SetBoundaries(3.0f, 12.0f, true);
        }

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

    // Takes the left and right ranges as arguments aswell as the direction the object is initially moving in.
    void SetBoundaries(float lRange, float rRange, bool rightCondition)
    {
        leftRange = lRange;
        rightRange = rRange;
        movingRight = rightCondition;
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

}
