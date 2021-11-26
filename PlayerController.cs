using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    private float leftRange = -8.0f;
    private float rightRange = 12.0f;
    public GameObject ballPrefab;
    public int ballsLaunched;
    public int ballScore = 1;
    public int ballLimit = 20;
    public bool isGameActive;
    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player control and speed
        if (isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
            CheckBoundaries();
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
            {
                ReleaseBall();
            }
        }
        // Sets the isGameActive variable to false if the ballLimit is reached.
        if (ballsLaunched == ballLimit)
        {
            isGameActive = false;
        }
    }

    // Releases a ball. Adds 
    void ReleaseBall()
    {
        nextFire = Time.time + fireRate;
        Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
        ballsLaunched = ballsLaunched + ballScore;

    } 

    // Repositions the player to the boundary if they move past the ranges.
    void CheckBoundaries()
    {
        if (transform.position.z < leftRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftRange);
        }
        else if (transform.position.z > rightRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rightRange);
        }
    }

    // Returns the variable "ballLaunched".
    public int GetBallsLaunched()
    {
        return ballsLaunched;
    }

}

