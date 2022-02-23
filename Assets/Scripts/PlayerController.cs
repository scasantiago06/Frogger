using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

	[SerializeField]
    private LayerMask obstacles;

	private Vector3 direction;
	private Vector3 currentPosition;
	private Vector3 positionToGo;
	
	[SerializeField]
	private float speed;
	[SerializeField]
	private float jumpForce;

	private Rigidbody rb;

    #endregion Variables

    #region Unity Functions

    void Update()
    {
		if (transform.position != new Vector3(currentPosition.x + direction.x, transform.position.y, currentPosition.z + direction.z))
		{
			positionToGo = new Vector3(currentPosition.x + direction.x, transform.position.y, currentPosition.z + direction.z);

			transform.position = Vector3.MoveTowards(transform.position, positionToGo, speed * Time.deltaTime);
		}
		else
		{
			direction = Vector3.zero;

			if (Input.GetAxisRaw("Horizontal") != 0)
				direction.x = Input.GetAxisRaw("Horizontal");
			else if (Input.GetAxisRaw("Vertical") != 0)
				direction.z = Input.GetAxisRaw("Vertical");

			currentPosition = transform.position;

			if (direction.x != 0 || direction.z != 0)
			{
				RaycastHit hit;
				Physics.Raycast(transform.position, direction, out hit, 1, obstacles);

				if (hit.collider == null)
					rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
				else
					direction = Vector3.zero;
			}

            //if not on platform then normalize it
            currentPosition.x = Mathf.Round(currentPosition.x);
            currentPosition.z = Mathf.Round(currentPosition.z);
		}
	}

	#endregion Unity Functions

	#region Class Functions

	// ***

	#endregion Class Functions
}
