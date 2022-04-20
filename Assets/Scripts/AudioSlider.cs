using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            Save();
        } else {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volume.value;
        Save();
    }

    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("gameVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("gameVolume", volume.value);
    }
}
