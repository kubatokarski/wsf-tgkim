using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;
    [SerializeField] private TextMeshProUGUI healthElement;

    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if (state <0f)
        {
            state = 0f;
        }
        //bar.transform.localScale = new Vector3(characterDirectionX * state, 1f, 1f);
        bar.transform.localScale = new Vector3(state, 1f, 1f);
        healthElement.text = "HP: " + current + "/" + max;
    }
}
