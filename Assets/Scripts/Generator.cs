using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameObject objectsToInstantiate;
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float minWait;
    [SerializeField]
    private float maxWait;

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
        if (spawnPoint == null)
        {
            try
            {
                spawnPoint = transform.Find("SpawnPoint");
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Spawn Point not founded");
            }
        }
    }

    private void SetUp()
    {
        StartCoroutine(Generate());
    }

    #endregion Class Functions

    #region Coroutines
    
    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(/*Random.Range(minWait, maxWait)*/.5f);

        GameObject gameObject = Instantiate(objectsToInstantiate);

        if (spawnPoint.position.x < 0)
        {
            if (objectsToInstantiate.name == "Car")
                gameObject.GetComponent<ConstantMovement>().Speed = 0f;
            else if (objectsToInstantiate.name == "Trunk")
                gameObject.GetComponent<ConstantMovement>().Speed = 4.5f;
        }
        else
        {
            if (objectsToInstantiate.name == "Car")
                gameObject.GetComponent<ConstantMovement>().Speed = 0f;
            else if (objectsToInstantiate.name == "Trunk")
                gameObject.GetComponent<ConstantMovement>().Speed = -4.5f;
        }

        gameObject.transform.position = spawnPoint.position;
        gameObject.transform.eulerAngles = spawnPoint.eulerAngles;

        StartCoroutine(Generate());
    }

    #endregion Coroutines
}
