using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    UIManager uiManager;

    private Vector3 initialPosition;

    [SerializeField]
    private GameObject[] frogs;
    private PlayerController currentFrog;
    private TimeController timeController;
    private CameraFollow cameraFollow;

    private int frogIndex;
    private int lifes;
    private int score;

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
        uiManager = FindObjectOfType<UIManager>();
        timeController = FindObjectOfType<TimeController>();
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    public void SetUp()
    {
        lifes = 3;
        score = 0;

        initialPosition = new Vector3(0, 0.1f, 0);

        frogIndex = 0;

        foreach(var frog in frogs)
        {
            frog.transform.position = initialPosition;

            frog.SetActive(true);

            PlayerController frogController = frog.GetComponent<PlayerController>();

            frogController.enabled = true;
            frogController.SetUp();

            frog.SetActive(false);
        }

        frogs[frogIndex].SetActive(true);

        currentFrog = frogs[frogIndex].GetComponent<PlayerController>();
        cameraFollow.player = currentFrog.gameObject;
    }

    public void NextGamePhase()
    {
        frogIndex++;

        if (frogIndex < frogs.Length)
        {
            frogs[frogIndex].SetActive(true);
            currentFrog = frogs[frogIndex].GetComponent<PlayerController>();
            cameraFollow.player = currentFrog.gameObject;
            timeController.Restart();
        }
        else
        {
            uiManager.Victory();
        }
    }

    public void SubtractLife()
    {
        lifes--;

        uiManager.SubtractLifeImage(lifes);
        timeController.Restart();

        if (lifes == 0)
            uiManager.Defeat();
    }

    public void SumScore()
    {
        score += 10;
        uiManager.ChangeCurrentScoreText(score);
    }

    #endregion Class Functions

    #region Properties

    public Vector3 InitialPosition
    {
        get => initialPosition;
    }

    public int Lifes
    {
        get => lifes;
    }

    #endregion Properties
}
