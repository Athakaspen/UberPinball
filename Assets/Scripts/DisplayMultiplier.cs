using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMultiplier : MonoBehaviour
{
    public Text multiplierText;
    // Update is called once per frame
    void Update()
    {
        multiplierText.text = Utilities.ScoreMultiplier.ToString() + "x";
    }
}
