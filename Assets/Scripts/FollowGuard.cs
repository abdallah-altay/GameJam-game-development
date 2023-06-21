using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGuard : MonoBehaviour
{
    public Transform guard;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(guard.position.x, guard.position.y, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            guard.GetComponent<GuardMovement>().ResetPlayer();
        }
    }
}
