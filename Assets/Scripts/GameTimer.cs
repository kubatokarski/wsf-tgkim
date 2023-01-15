using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public bool gameOver = false;

    private float timer;
    private string timerFormatted;

    [SerializeField] private TextMeshProUGUI timerElement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;
            System.TimeSpan t = System.TimeSpan.FromSeconds(timer);
            timerElement.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }
        else
        {
            timerElement.color = Color.yellow;
        }
    }

}