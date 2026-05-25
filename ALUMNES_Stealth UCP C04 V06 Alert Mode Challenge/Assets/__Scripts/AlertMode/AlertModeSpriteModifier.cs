using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertModeSpriteModifier : MonoBehaviour
{
    public Color colorToSwitchTo = Color.red;
    public Sprite spriteToSwitchTo;

    [Tooltip("0 = None of new color | 1 = All new color")]
    public float colorBlend = 1;

    private SpriteRenderer[] spriteRenderers;

    private Color[] originalColors;
    private Sprite[] originalSprites;

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        originalColors = new Color[spriteRenderers.Length];
        originalSprites = new Sprite[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
            originalSprites[i] = spriteRenderers[i].sprite;
        }

        AlertModeManager.alertModeStatusChangeDelegate += AlertModeStatusChange;
    }

    private void OnDestroy()
    {
        AlertModeManager.alertModeStatusChangeDelegate -= AlertModeStatusChange;
    }

    void AlertModeStatusChange(bool alertMode)
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            if (alertMode)
            {
                spriteRenderers[i].color =
                    Color.Lerp(originalColors[i], colorToSwitchTo, colorBlend);

                spriteRenderers[i].sprite = spriteToSwitchTo;
            }
            else
            {
                spriteRenderers[i].color = originalColors[i];
                spriteRenderers[i].sprite = originalSprites[i];
            }
        }
    }
}