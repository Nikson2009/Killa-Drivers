using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesSpawners;

    int thisRoomNumber;

    MapManager mapManager;
    GameObject mapObject;
    void Start()
    {
        mapObject = GameObject.Find("Map");
        mapManager = mapObject.GetComponent<MapManager>();

        thisRoomNumber = mapManager.GetCurrentRoom();

        StartCoroutine(CheckRoomCount());
    }

    IEnumerator CheckRoomCount()
    {
        yield return new WaitForSeconds(0.5f);

        if (mapManager.GetCurrentRoom() >= thisRoomNumber + 4)
        {
            Destroy(transform.gameObject);
        }

        StartCoroutine(CheckRoomCount());
    }
}
