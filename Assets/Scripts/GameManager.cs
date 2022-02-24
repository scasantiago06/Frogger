using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    private Vector3 initialPosition;

    [SerializeField]
    private GameObject[] frogs;

    private int frogIndex;

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

    public void SetUp()
    {
        initialPosition = new Vector3(0, 0.1f, 0);

        frogIndex = 0;

        foreach(var frog in frogs)
        {
            frog.transform.position = initialPosition;

            PlayerController frogController = frog.GetComponent<PlayerController>();

            frogController.enabled = true;
            frogController.SetUp();

            frog.SetActive(false);
        }

        frogs[frogIndex].SetActive(true);
    }

    public void NextGamePhase()
    {
        frogIndex++;

        if (frogIndex < frogs.Length)
        {
            frogs[frogIndex].SetActive(true);
        }
        else
        {
            // ToDo Victory
        }
    }

    #endregion Class Functions

    #region Properties

    public Vector3 InitialPosition
    {
        get => initialPosition;
    }

    #endregion Properties
}
