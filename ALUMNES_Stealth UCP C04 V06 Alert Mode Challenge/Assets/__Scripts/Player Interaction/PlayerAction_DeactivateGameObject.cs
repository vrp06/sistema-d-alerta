using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_DeactivateGameObject : PlayerAction
{
    public GameObject gameObjectToDeactivate;

    public override void Action()
    {
        if (gameObjectToDeactivate != null)
        {
            // Aturar el so si hi ha AudioSource
            AudioSource audioSource =
                gameObjectToDeactivate.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Stop();
            }

            // Desactivar objecte
            gameObjectToDeactivate.SetActive(false);
        }
    }
}