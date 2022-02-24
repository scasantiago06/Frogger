using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables

	// Public...
	public GameObject player;

	// Private...
    private Vector3 offset;

    #endregion Variables

    #region Unity Functions

    void Start()
	{
		offset = transform.position;
	}

	void Update()
	{
		if (player != null)
			transform.position = offset + new Vector3(0, 0, player.transform.position.z);
	}

    #endregion Unity Functions

    #region Class Functions

	// ...

    #endregion Class Functions
}