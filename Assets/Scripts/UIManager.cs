using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private GameObject[] lifesImages;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject victoryPanel;

    [SerializeField]
    private GameObject defeatPanel;

    [SerializeField]
    private TextMeshProUGUI currentScore;

    [SerializeField]
    private TextMeshProUGUI finalScore;

    #endregion Properties

    #region Unity Functions

    #endregion Unity Functions

    #region Class Functions

    public void SubtractLifeImage(int imageIndex)
    {
        lifesImages[imageIndex].SetActive(false);
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);
    }

    public void ChangeCurrentScoreText(int scoreValue)
    {
        currentScore.text = "Score: " + scoreValue.ToString();
    }

    public void ChangeFinalScoreText()
    {
        finalScore.text = currentScore.text;
    }

    #endregion Class Functions
}
