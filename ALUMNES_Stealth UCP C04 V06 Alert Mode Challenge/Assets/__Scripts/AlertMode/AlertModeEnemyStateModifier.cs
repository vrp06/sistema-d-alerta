using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertModeEnemyStateModifier : MonoBehaviour
{
    private EnemyNav enemy;

    void Start()
    {
        enemy = GetComponent<EnemyNav>();

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
            enemy.mode = EnemyNav.eMode.chase;
        }
        else
        {
            enemy.mode = EnemyNav.eMode.stopChase;
        }
    }
}