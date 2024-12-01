using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesSpawners;
    [SerializeField] GameObject door;

    int thisRoomNumber;

    int maxEnemiesInRoom = 0;

    MapManager mapManager;
    GameObject mapObject;
    void Start()
    {
        mapObject = GameObject.Find("Map");
        mapManager = mapObject.GetComponent<MapManager>();

        thisRoomNumber = mapManager.GetCurrentRoom();

        foreach (GameObject spawner in enemiesSpawners)
        {
            EnemySpawner spawnerScript = spawner.GetComponent<EnemySpawner>();
            spawnerScript.SpawnEnemies(Mathf.RoundToInt(thisRoomNumber / 5) + 1, Mathf.Clamp(Mathf.RoundToInt(thisRoomNumber / 5), 0, 4));

            maxEnemiesInRoom += Mathf.RoundToInt(thisRoomNumber / 5) + 1;
        }

        StartCoroutine(CheckRoomCount());
    }

    IEnumerator CheckRoomCount()
    {
        yield return new WaitForSeconds(2f);

        if (mapManager.GetCurrentRoom() >= thisRoomNumber + 3)
        {
            SpawnRoom doorScript = door.GetComponent<SpawnRoom>();
            doorScript.CloseAnimation();
        }
        else if (mapManager.GetCurrentRoom() >= thisRoomNumber + 4)
        {
            Destroy(transform.gameObject);
        }

        StartCoroutine(CheckRoomCount());
    }
}
