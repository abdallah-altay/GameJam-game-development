using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBridge : MonoBehaviour
{
	ColliderListener _listener;
	public void Initialize(ColliderListener l)
	{
		_listener = l;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		_listener.OnTriggerEnter2D(other);
	}
}
