using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IReactableObject
{
	#region Variables

	public int maxLineReached;
	public int currentline;

	[SerializeField]
	private float speed;
	[SerializeField]
	private float jumpForce;
	public float logOffset;

	private bool onPlatform;

	private GameObject platformPivot;

	private Rigidbody frogRigidBody;

	private Vector3 direction;
	private Vector3 currentPosition;
	private Vector3 positionToGo;

	[SerializeField]
    private LayerMask obstacles;
	
	private GameManager gameManager;

	#endregion Variables

	#region Unity Functions

	private void Awake()
    {
		GetComponents();
    }

	private void Start()
    {
		SetUp();
    }

	private void Update()
    {
		Movement();
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dangerous"))
        {
			React();
        }
		if (other.CompareTag("Next"))
		{
			gameManager.NextGamePhase();

			GetComponent<PlayerController>().enabled = false;

			gameObject.SetActive(false);
		}
	}

	private void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.CompareTag("Platform"))
		{
			SetPivotToFollow(collision.gameObject);
			onPlatform = true;
		}
	}
    private void OnCollisionExit(Collision collision)
    {
		if (collision.collider.CompareTag("Platform"))
		{
            platformPivot = null;
            onPlatform = false;
        }
	}

    #endregion Unity Functions

    #region Class Functions

    private void GetComponents()
    {
		frogRigidBody = GetComponent<Rigidbody>();

		gameManager = FindObjectOfType<GameManager>();
    }

	public void SetUp()
    {
		// ...
    }

	private void Movement()
    {
		if (transform.position != new Vector3(currentPosition.x + direction.x, transform.position.y, currentPosition.z + direction.z))
		{
			positionToGo = new Vector3(currentPosition.x + direction.x, transform.position.y, currentPosition.z + direction.z);

			transform.position = Vector3.MoveTowards(transform.position, positionToGo, speed * Time.deltaTime);
		}
		else
		{
			direction = Vector3.zero;

            if (gameManager.Lifes > 0)
				GetDirection();

			currentPosition = transform.position;

			Jump();

			if (onPlatform)
			{
				currentPosition = platformPivot.transform.position;
			}
			else
            {
				currentPosition.x = Mathf.Round(currentPosition.x);
				currentPosition.z = Mathf.Round(currentPosition.z);
            }
		}
	}

	private void GetDirection()
    {
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			direction.x = Input.GetAxisRaw("Horizontal");

			// Player rotation
			if (direction.x == 1)
				transform.eulerAngles = new Vector3(0, 90, 0);
            else
				transform.eulerAngles = new Vector3(0, -90, 0);
		}
		else if (Input.GetAxisRaw("Vertical") != 0)
		{
			direction.z = Input.GetAxisRaw("Vertical");

			// Player rotation and line control
			if (direction.z == 1)
			{
				currentline++;

				LineControl();
				
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
            else
            {
				currentline--;
				transform.eulerAngles = new Vector3(0, 180, 0);
			}
		}
	}

	private void LineControl()
    {
		if (currentline > maxLineReached)
		{
			maxLineReached = currentline;

			gameManager.SumScore();
		}
	}

	private void Jump()
    {
		if (direction.x != 0 || direction.z != 0)
		{
			RaycastHit hit;
			Physics.Raycast(transform.position, direction, out hit, 1, obstacles);

			if (hit.collider == null)
				frogRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
			else
				direction = Vector3.zero;
		}
	}

	// Interface...
	public void React()
    {
		// Frog Setup
		transform.position = gameManager.InitialPosition;

		direction = Vector3.zero;

		currentPosition = transform.position;

		transform.eulerAngles = new Vector3(0, 0, 0);

		// Other Setups
		gameManager.SubtractLife();

		currentline = 0;
	}

	public void SetPivotToFollow(GameObject pivots)
	{
		float closestPosition = 100;

		foreach (Transform pivot in pivots.transform)
		{
			float distance = (pivot.position - transform.position).magnitude;

			if (distance < closestPosition)
			{
				closestPosition = distance;
				platformPivot = pivot.gameObject;
			}
		}

		positionToGo = platformPivot.transform.position;
	}

	#endregion Class Functions
}
