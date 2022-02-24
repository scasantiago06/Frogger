using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    #region Variables

    private float speed;

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
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, speed * Time.deltaTime);

        if (transform.position.x < -20 || transform.position.x > 15)
            Destroy(this.gameObject);
    }

    #endregion Unity Functions

    #region Class Functions

    private void GetComponents()
    {
        // ...
    }

    private void SetUp()
    {
        // ...
    }

    #endregion Class Functions

    #region Properties

    public float Speed
    {
        get => speed; 
        set => speed = value;
    }

    #endregion Properties
}
