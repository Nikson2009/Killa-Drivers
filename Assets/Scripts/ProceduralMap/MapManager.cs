using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private Dictionary<Vector3, bool> rooms = new Dictionary<Vector3, bool>();

    private Vector3 worldAnchor = new Vector3(-7.5f, 0.5f, 7.5f);

    private int currentRoom = 1;

    private void Awake()
    {
        // Adding Start Room To Rooms
        rooms.Add(new Vector3(0, 0, 0), true);
    }

    public void AddRoom(Vector3 key)
    {
        rooms.Add(key, true);

        currentRoom += 1;
    }

    public bool GetIsRoom(Vector3 key)
    {
        return rooms.ContainsKey(key);
    }

    public int GetCurrentRoom()
    {
        return currentRoom;
    }

    public Vector3 GetWorldAnchor()
    {
        return worldAnchor;
    }
}
