using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AM;
    public void SetVolume(float volume)
    {
        AM.SetFloat("Volume", (Mathf.Log10(volume) * 20)+10);
        Debug.Log(volume);
    }
}
