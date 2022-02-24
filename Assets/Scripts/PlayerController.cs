using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IReactableObject
{
    #region Variables

	[SerializeField]
    private LayerMask obstacles;

	private Vector3 direction;
	private Vector3 currentPosition;
	private Vector3 positionToGo;

	private Rigidbody rb;
	
	[SerializeField]
	private float speed;
	[SerializeField]
	private float jumpForce;

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
    }

    #endregion Unity Functions

    #region Class Functions

    private void GetComponents()
    {
		rb = GetComponent<Rigidbody>();

		gameManager = FindObjectOfType<GameManager>();
    }

	private void SetUp()
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

			GetDirection();

			currentPosition = transform.position;

			Jump();

			currentPosition.x = Mathf.Round(currentPosition.x);
			currentPosition.z = Mathf.Round(currentPosition.z);
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

			// Player rotation
			if (direction.z == 1)
				transform.eulerAngles = new Vector3(0, 0, 0);
			else
				transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

	private void Jump()
    {
		if (direction.x != 0 || direction.z != 0)
		{
			RaycastHit hit;
			Physics.Raycast(transform.position, direction, out hit, 1, obstacles);

			if (hit.collider == null)
				rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
			else
				direction = Vector3.zero;
		}
	}

	public void React()
    {
		transform.position = gameManager.InitialPosition;

		direction = Vector3.zero;
		currentPosition = transform.position;
		transform.eulerAngles = new Vector3(0, 0, 0);
	}

	#endregion Class Functions
}
