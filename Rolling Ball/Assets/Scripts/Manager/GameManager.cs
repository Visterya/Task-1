using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Enemies Killed")]
    [SerializeField] TextMeshProUGUI enemiesKilledText;
    public int enemiesKilled = 0;


    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timerText;
    private float timer = 0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();
    }
}
