using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimeController : MonoBehaviour
{
    #region Properties

    [Tooltip("Time in seconds"), SerializeField]
    private int initialTime;
    [Tooltip("Time scale"), SerializeField, Range(-10.0f, 10.0f)]
    private float timeScale;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private bool paused;
    [SerializeField]
    private UnityEvent timeFinished;

    private float frameTimeWithTimeScale;
    private float timeInSecondsToShow;
    private float timeScaleInPause;
    private float initialTimeScale;

    #endregion Properties

    #region Unity Functions

    // Start is called before the first frame update
    void Start()
    {
        initialTimeScale = timeScale;
        timeInSecondsToShow = initialTime;

        UpdateTime(initialTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            frameTimeWithTimeScale = Time.deltaTime * timeScale;
            timeInSecondsToShow += frameTimeWithTimeScale;

            UpdateTime(timeInSecondsToShow);
        }
    }

    #endregion Unity Functions

    #region Class Functions

    private void UpdateTime(float timeInSeconds)
    {
        int minutes = 0;
        int seconds = 0;

        string timeString;

        if (timeInSeconds <= 0)
        {
            Pause();
            timeFinished?.Invoke();

            timeInSeconds = 0;
        }

        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        if (initialTime > 60)
            timeString = minutes.ToString("00") + "    " + seconds.ToString("00");
        else
            timeString = seconds.ToString();

        timeText.text = timeString;
    }

    public void StartTimeCount()
    {
        paused = false;
    }

    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            timeScaleInPause = timeScale;
            timeScale = 0;
        }
    }

    public void Continue()
    {
        if (paused)
        {
            paused = false;
            timeScale = timeScaleInPause;
        }
    }

    public void Restart()
    {
        paused = false;
        timeScale = initialTimeScale;
        timeInSecondsToShow = initialTime;

        UpdateTime(timeInSecondsToShow);
    }

    #endregion Class Functions
}