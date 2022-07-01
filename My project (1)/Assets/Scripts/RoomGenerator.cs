using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>();
    public GameObject currentRoom;

    private List<GameObject> instantiated = new List<GameObject>();

    public void Deinstanciate()
    {
        foreach (var i in instantiated)
        {
            if (currentRoom == i)
                continue;
            Destroy(i);
        }
    }

    public void InstantiateOnLocation(Vector3 location)
    {
        int i = Random.Range(0, rooms.Count);
        GameObject go = Instantiate(rooms[i], location, Quaternion.identity);
        instantiated.Add(go);
    }

    public void InstantiateAroundRoom(Room room)
    {
        foreach (var i in room.spawnLocations)
        {
            int rand = Random.Range(0, rooms.Count);
            Vector3 spawnShift = rooms[rand].GetComponent<Room>().spawnShift;
            instantiated.Add(Instantiate(rooms[rand], spawnShift + i, Quaternion.identity));
        }
    }

    void Start()
    {
        InstantiateOnLocation(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
