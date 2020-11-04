using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public struct TilemapInfo
{
    public string mapName;
    public Tilemap tm;
}
public class RoomTemplateData : MonoBehaviour
{
    public TilemapInfo[] BottomTilemapInfos;
    public TilemapInfo[] TopTilemapInfos;
    public TilemapInfo[] LeftTilemapInfos;
    public TilemapInfo[] RightTilemapInfos;
    public Dictionary<string, TilemapInfo> roomTemplates;

    public int mapWidth;//整个地图上横向有多少个房间
    public int mapHeight;//整个地图上竖向有多少个房间

    private void Start()
    {
        //int count = roomWidth * roomHeight;
        //GameObject newRoom = null;
        //for (int i = 0; i < roomWidth; i++)
        //{
        //    for (int j = 0; j < roomHeight; j++)
        //    {
        //        --count;

        //        //newRoom = Instantiate(roomTemplates["alldir"].gameObject, new Vector3(i * 8, j * 8), Quaternion.identity);


        //        newRoom.name = newRoom.name.Substring(0, newRoom.name.IndexOf('('));
        //        newRoom.AddComponent<TilemapCollider2D>();
        //        newRoom.AddComponent<CompositeCollider2D>();
        //        newRoom.GetComponent<Rigidbody2D>().gravityScale = 0;
        //        newRoom.GetComponent<TilemapCollider2D>().usedByComposite = true;
        //        newRoom.transform.parent = GameObject.Find("Map").transform;
        //        yield return 0.5f;
        //    }
        //    yield return 0.5f;
        //}
    } 
}
