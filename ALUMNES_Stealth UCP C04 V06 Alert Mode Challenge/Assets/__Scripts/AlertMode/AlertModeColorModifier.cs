using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertModeColorModifier : MonoBehaviour
{
    public Color colorToSwitchTo = Color.red;

    private Renderer rend;
    private Color originalEmissionColor;

    void Start()
    {
        rend = GetComponent<Renderer>();

        originalEmissionColor =
            rend.materials[0].GetColor("_EmissionColor");

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
            rend.materials[0].SetColor("_EmissionColor", colorToSwitchTo);
        }
        else
        {
            rend.materials[0].SetColor("_EmissionColor", originalEmissionColor);
        }
    }
}