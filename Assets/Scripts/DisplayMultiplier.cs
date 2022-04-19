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
        multiplierText.text = ((int) (Utilities.hitCount / 5) * 0.25f + 1).ToString() + "x";
    }
}
