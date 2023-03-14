using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private GameObject throwable;
    private Transform spawnpoint;

    private void Start()
    {
        //Find spawnpoint position located on Marker_1
        GameObject spawnTile = GameObject.Find("Marker_1");
        spawnpoint = spawnTile.transform.Find("Spawnpoint");
    }

    public void SpawnObject()
    {
        Debug.Log("Spawning object");
        //Spawn object at spawnpoint position
        GameObject thrownObject = Instantiate(
            throwable,
            spawnpoint.position,
            spawnpoint.rotation);
    }
}
