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

    void Start()
    {
        SetUp();
    }

    void Update()
    {

    }

    #endregion Unity Functions

    #region Class Functions

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
