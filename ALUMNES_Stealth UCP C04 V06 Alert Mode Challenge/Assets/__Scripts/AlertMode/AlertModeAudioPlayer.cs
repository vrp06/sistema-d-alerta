using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertModeAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AlertModeManager.alertModeStatusChangeDelegate += AlertModeStatusChange;
    }

    private void OnDestroy()
    {
        AlertModeManager.alertModeStatusChangeDelegate -= AlertModeStatusChange;
    }

    void AlertModeStatusChange(bool alertMode)
    {
        if (alertMode)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}