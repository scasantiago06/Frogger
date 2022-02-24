using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    private Vector3 initialPosition;

    [SerializeField]
    private GameObject[] characters;

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

    }

    #endregion Unity Functions

    #region Class Functions

    private void GetComponents()
    {
        // ...
    }

    private void SetUp()
    {
        initialPosition = new Vector3(0, 0.1f, 0);
    }

    #endregion Class Functions

    #region Properties

    public Vector3 InitialPosition
    {
        get => initialPosition;
    }

    #endregion Properties
}
