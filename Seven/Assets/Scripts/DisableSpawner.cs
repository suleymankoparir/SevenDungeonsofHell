using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawner : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public void destroyEnemySpawner()
    {
        Destroy(enemySpawner);
    }
}
