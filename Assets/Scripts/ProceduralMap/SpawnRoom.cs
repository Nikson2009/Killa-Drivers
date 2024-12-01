using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnRoom : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject room;
    [SerializeField] BoxCollider selfBoxCollider;

    [Header("RoomTypes")]
    [SerializeField] List<GameObject> toForward;

    [Header("PartsForAnimation")]
    [SerializeField] GameObject upperLeft;
    [SerializeField] GameObject upperRight;
    [SerializeField] GameObject downLeft;
    [SerializeField] GameObject downRight;

    MapManager mapManager;
    GameObject mapObject;

    private void Start()
    {
        mapObject = GameObject.Find("Map");
        mapManager = mapObject.GetComponent<MapManager>();
    }

    private void OpenAnimation()
    {
        upperLeft.transform.DOLocalMove(new Vector3(5, 5, 0), 3.25f);
        upperRight.transform.DOLocalMove(new Vector3(-5, 5, 0), 3.25f);
        downLeft.transform.DOLocalMove(new Vector3(5, -5, 0), 3.25f);
        downRight.transform.DOLocalMove(new Vector3(-5, -5, 0), 3.25f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(selfBoxCollider);

            Vector3 futureRoomPos = room.transform.localPosition / 30 + -transform.forward;

            futureRoomPos = new Vector3(Mathf.Round(futureRoomPos.x), Mathf.Round(futureRoomPos.y), Mathf.Round(futureRoomPos.z));

            mapManager.AddRoom(futureRoomPos);

            int index = Random.RandomRange(0, toForward.Count);

            print(index);

            GameObject newRoom = Instantiate(toForward[index], futureRoomPos * 30 + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
            newRoom.transform.parent = mapObject.transform;

            OpenAnimation();
        }
    }
}
