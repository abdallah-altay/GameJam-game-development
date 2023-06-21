using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.position = transform.parent.position;
    }
}
