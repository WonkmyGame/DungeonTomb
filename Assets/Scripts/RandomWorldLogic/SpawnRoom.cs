using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public int openingDirection;
    private int rand;
    private RoomTemplateData roomTemp;

    private List<GameObject> rooms;

    GameObject tempRoom;

    public bool spawned = false;

    private void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("template").GetComponent<RoomTemplateData>();

        rooms = new List<GameObject>();

        StartCoroutine(Spwan());
    }

    private void Update()
    {

    }
    IEnumerator Spwan()
    {
        if(spawned==false)
        {
            //for (int i = 0; i < roomTemp.mapWidth; i++)
            //{
            //    for (int j = 0; j < roomTemp.mapHeight; j++)
            //    {
                    if (openingDirection == 4)
                    {
                        // Need to spawn a room with a BOTTOM door.
                        rand = Random.Range(0, roomTemp.BottomTilemapInfos.Length);
                        tempRoom = Instantiate(roomTemp.BottomTilemapInfos[rand].tm.gameObject, new Vector3(transform.position.x * 8, transform.position.y * 8), transform.rotation);
                        tempRoom.transform.SetParent(GameObject.Find("Map").transform);
                        rooms.Add(tempRoom);
                    }
                    else if (openingDirection == 1)
                    {
                        // Need to spawn a room with a TOP door.
                        rand = Random.Range(0, roomTemp.TopTilemapInfos.Length);
                        tempRoom = Instantiate(roomTemp.TopTilemapInfos[rand].tm.gameObject, new Vector3(transform.position.x * 8, transform.position.y * 8), transform.rotation);
                        tempRoom.transform.SetParent(GameObject.Find("Map").transform);
                        rooms.Add(tempRoom);
                    }
                    else if (openingDirection == 2)
                    {
                        // Need to spawn a room with a LEFT door.
                        rand = Random.Range(0, roomTemp.LeftTilemapInfos.Length);
                        tempRoom = Instantiate(roomTemp.LeftTilemapInfos[rand].tm.gameObject, new Vector3(transform.position.x * 8, transform.position.y * 8), transform.rotation);
                        tempRoom.transform.SetParent(GameObject.Find("Map").transform);
                        rooms.Add(tempRoom);
                    }
                    else if (openingDirection == 3)
                    {
                        // Need to spawn a room with a RIGHT door.
                        rand = Random.Range(0, roomTemp.RightTilemapInfos.Length);
                        tempRoom = Instantiate(roomTemp.RightTilemapInfos[rand].tm.gameObject, new Vector3(transform.position.x * 8, transform.position.y * 8), transform.rotation);
                        tempRoom.transform.SetParent(GameObject.Find("Map").transform);
                        rooms.Add(tempRoom);
                    }
                    yield return 0.5f;
              //  }
                //yield return 0.5f;
                spawned = false;
           // }
            
        }
        
    }
}
