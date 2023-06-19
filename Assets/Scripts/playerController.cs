using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite idlePlayer;
    public float moveSpeed = 5;
    public bool speedBuff = false;
    private bool powerUpActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animate();
    }

    private void Movement()
    {
        if (speedBuff)
        {
            StartCoroutine(PowerUp());
        }
        else if (!speedBuff && powerUpActive)
        {
            powerUpActive = false;
            StopCoroutine(PowerUp());
        }
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(horizontal, vertical);
    }

    private void Animate()
    {
        if (rb.velocity.magnitude > 0)
        {
            transform.GetComponent<Animator>().enabled = true;
        } else
        {
            transform.GetComponent<Animator>().enabled = false;
            transform.GetComponent<SpriteRenderer>().sprite = idlePlayer;
        }
    }

    IEnumerator PowerUp()
    {
        moveSpeed = 8;
        powerUpActive = true;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
        speedBuff = false;
    }
}
