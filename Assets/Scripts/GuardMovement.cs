using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public bool isRotated;
    public FieldOfViewGuards fieldOfViewGuards;

    //Position 1 should be where they spawn in
    public Vector2 position1;
    public Vector2 position2;
    public float speed;
    private float moveTo;
    public bool canMove = true;

    //This is to check which way the guard is moving
    //MovingWay = true means the guard is moving from position 1 to position 2
    //MovingWay = false means the guard is moving from position 2 to position 1
    private bool movingWay = true;

    private bool standing = false;

    public bool isMoving;

    //Set how long you want the guard to stand for.
    public float standingDelay;

    public Sprite standingGuard;

    private float standingTimer;

    //Resets the position to their starting location
    public void ResetPosition()
    {
        transform.position = position1;
    }

    void Start()
    {
        if (isRotated)
        {
            fieldOfViewGuards.SetAimDirection(new Vector3(0, 180, 0));
        }
        else
        {
            fieldOfViewGuards.SetAimDirection(new Vector3(0, -180, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (movingWay)
            {
                Moving(position1, position2);
            }
            else
            {
                Moving(position2, position1);
            }
        }
        else
        {
            standingTimer += Time.deltaTime;
            if(standingTimer >= standingDelay)
            {
                standingTimer = 0;
                canMove = true;
                transform.GetChild(0).GetComponent<Animator>().enabled = true;
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        if (fieldOfViewGuards != null)
        {
            fieldOfViewGuards.SetOrigin(new Vector3(transform.position.x, transform.position.y, -0.1f));
        }
    }

    public void Moving(Vector2 startPosition, Vector2 endPosition)
    {
        moveTo = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, endPosition, moveTo);
        if((Vector2)transform.position == endPosition)
        {
            movingWay = !movingWay;
            if(transform.rotation.y == 180)
            {
                transform.Rotate(0, 0, 0);
            }
            else
            {
                transform.Rotate(0, 180, 0);
                
            }

            if (movingWay)
            {
                if (isRotated)
                {
                    fieldOfViewGuards.SetAimDirection(new Vector3(0, 180, 0));
                }
                else
                {
                    fieldOfViewGuards.SetAimDirection(new Vector3(0, -180, 0));
                }
            }
            else
            {
                if (isRotated)
                {
                    fieldOfViewGuards.SetAimDirection(new Vector3(0, -180, 0));
                }
                else
                {
                    fieldOfViewGuards.SetAimDirection(new Vector3(0, 180, 0));
                }
            }

            canMove = false;
            transform.GetChild(0).GetComponent<Animator>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = standingGuard;
        }
    }

    public void ResetPlayer()
    {
        Debug.Log(ItemInfo.isInvisible);
        if(ItemInfo.isInvisible != true)
        {
            GameObject.Find("Spawner Manager").GetComponent<RespawnerManager>().ResetPlayerToSpawn();
        }
    }
}
