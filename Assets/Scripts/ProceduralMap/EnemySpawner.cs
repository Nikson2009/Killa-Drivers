using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Difficult
{
    public List<GameObject> difficult;
}
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Difficult> enemiesDifficults;
    public void SpawnEnemies(int count, int difficultLevel)
    {
        for (int i = 0;i < count; i++)
        {
            int length = enemiesDifficults[difficultLevel].difficult.Count;

            Instantiate(enemiesDifficults[difficultLevel].difficult[Random.RandomRange(0, length)], transform.position, Quaternion.identity);
        }
    }

}
