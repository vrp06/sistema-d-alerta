using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertModeLightConeModifier : MonoBehaviour
{
    public Color colorToSwitchTo = Color.red;

    private LightCone[] lightCones;
    private Color[] originalColors;

    void Start()
    {
        lightCones = GetComponentsInChildren<LightCone>();

        originalColors = new Color[lightCones.Length];

        for (int i = 0; i < lightCones.Length; i++)
        {
            originalColors[i] = lightCones[i].color;
        }

        AlertModeManager.alertModeStatusChangeDelegate += AlertModeStatusChange;
    }

    private void OnDestroy()
    {
        AlertModeManager.alertModeStatusChangeDelegate -= AlertModeStatusChange;
    }

    void AlertModeStatusChange(bool alertMode)
    {
        for (int i = 0; i < lightCones.Length; i++)
        {
            if (alertMode)
            {
                Color newColor = colorToSwitchTo;
                newColor.a = originalColors[i].a;

                lightCones[i].color = newColor;
            }
            else
            {
                lightCones[i].color = originalColors[i];
            }
        }
    }
}