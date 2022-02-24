using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Vector3 offset;

	public GameObject player;

	float maxPos;
	// Use this for initialization
	void Start()
	{
		offset = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (player != null)
			transform.position = offset + new Vector3(0, 0, player.transform.position.z);
	}
}
