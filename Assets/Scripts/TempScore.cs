using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempScore : MonoBehaviour
{
    public Text myText;
    // Update is called once per frame
    void Update()
    {
        myText.text = Utilities.Score.ToString();
    }
}
