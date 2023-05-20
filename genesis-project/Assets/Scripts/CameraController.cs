using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private float yInfLimit = -12.83f;
    private float ySupLimit = 11.84f;
    private float xLeftLimit = -16.35f;
    private float xRightLimit = -0.78f;


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        LimitMovement();
    }

    private void LimitMovement() 
    {
        if (transform.position.x < xLeftLimit && transform.position.y < yInfLimit)
        {
            transform.position = new Vector3(xLeftLimit, yInfLimit, transform.position.z);
        }
        else if (transform.position.x > xRightLimit && transform.position.y < yInfLimit)
        {
            transform.position = new Vector3(xRightLimit, yInfLimit, transform.position.z);
        }
        else if (transform.position.x < xLeftLimit && transform.position.y > ySupLimit)
        {
            transform.position = new Vector3(xLeftLimit, ySupLimit, transform.position.z);
        }
        else if (transform.position.x > xRightLimit && transform.position.y > ySupLimit)
        {
            transform.position = new Vector3(xRightLimit, ySupLimit, transform.position.z);
        }
        else if (transform.position.x < xLeftLimit && VerticalMoveIsValid()) 
        {
            transform.position = new Vector3(xLeftLimit, target.transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRightLimit && VerticalMoveIsValid())
        {
            transform.position = new Vector3(xRightLimit, target.transform.position.y, transform.position.z);
        }
        else if (transform.position.y < yInfLimit && HorizontalMoveIsValid())
        {
            transform.position = new Vector3(target.transform.position.x, yInfLimit, transform.position.z);
        }
        else if (transform.position.y > ySupLimit && HorizontalMoveIsValid())
        {
            transform.position = new Vector3(target.transform.position.x, ySupLimit, transform.position.z);
        }
    }

    private Boolean VerticalMoveIsValid() {
        return transform.position.y > yInfLimit && transform.position.y < ySupLimit;
    }

    private Boolean HorizontalMoveIsValid() 
    {
        return transform.position.x > xLeftLimit && transform.position.x < xRightLimit;
    }

}
