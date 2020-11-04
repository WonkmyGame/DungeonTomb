using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction { up,down,left,right};
public class CreateRandomRoom : MonoBehaviour
{
    public Direction direction;
    public Room startRoom;
    public Room endRoom;
    public Room normalRoom;

    private Room endRoomInList;

    public int generatorRoomNum;

    public float XOffset;
    public float YOffset;

    public LayerMask layerMask;

    public Transform generatorPoint;


    public List<Room> rooms = new List<Room>();

    private List<GameObject> farRooms=new List<GameObject>();
    private List<GameObject> lessFarRooms=new List<GameObject>();

    private List<GameObject> oneWayRooms=new List<GameObject>();

    private int maxStep;

    private void Awake()
    {
        CreateRoom();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetMap();
        }
    }

    public void ResetMap()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Destroy(rooms[i].gameObject);
        }
        rooms.Clear();
        generatorPoint.position = Vector3.zero;
        CreateRoom();
    }
    private void CreateRoom()
    {
        for (int i = 0; i < generatorRoomNum; i++)
        {
            //if(i==0)
            //{
            //    //
            //    Room newStartRoom=Instantiate(startRoom, Vector3.zero, Quaternion.identity).GetComponent<Room>();
            //    newStartRoom.transform.parent = transform;
            //    rooms.Add(newStartRoom);
            //    SetupRoom(newStartRoom,newStartRoom.transform.position);
            //}
            //else
            //{
                Room newRoom = Instantiate(normalRoom, generatorPoint.position, Quaternion.identity);
                newRoom.transform.parent = transform;
                rooms.Add(newRoom.GetComponent<Room>());
                SetupRoom(newRoom, newRoom.transform.position);
            //}
            ResetGeneratorPos();
        }

        endRoomInList = rooms[0];
        //foreach (var room in rooms)
        //{
        //    if (room.transform.position.sqrMagnitude > endRoomInList.transform.position.sqrMagnitude)
        //    {
        //        endRoomInList = room;
        //    }
        //    SetupRoom(rooms.Count, room, room.transform.position);
        //}
        
        //Room newEndRoom = Instantiate(endRoom, endRoomInList.transform.position, Quaternion.identity).GetComponent<Room>();
        //newEndRoom.transform.parent = transform;
        //rooms.Add(newEndRoom.GetComponent<Room>());
        //rooms.Remove(endRoomInList);
        //Destroy(endRoomInList.gameObject);
        //SetupRoom(newEndRoom, newEndRoom.transform.position);
    }

    public void ResetGeneratorPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, YOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -YOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-XOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(XOffset, 0, 0);
                    break;
                default:
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position,0.2f,layerMask));
    }
    //显示：有门（可通过）     显示：有门（不可通过）
    public void SetupRoom(Room room,Vector3 roomPos)
    {
        room.upDoorActive = !Physics2D.OverlapCircle(roomPos + new Vector3(0, YOffset), 0.5f, layerMask);
        room.downDoorActive = !Physics2D.OverlapCircle(roomPos + new Vector3(0, -YOffset), 0.5f, layerMask);
        room.leftDoorActive = !Physics2D.OverlapCircle(roomPos + new Vector3(-XOffset, 0), 0.5f, layerMask);
        room.rightDoorActive = !Physics2D.OverlapCircle(roomPos + new Vector3(XOffset, 0), 0.5f, layerMask);

        room.UpdateRoomInfo(XOffset,YOffset);
    }

    /*找到最终的房间*/
    public void FindEndRoom(){
        for (int i = 0; i < rooms.Count; i++)
        {
            if(rooms[i].stepToStartRoom>maxStep)
            {
                maxStep=rooms[i].stepToStartRoom;
            }
        }

        foreach (var room in rooms)
        {
            if(room.stepToStartRoom==maxStep)
            {
                farRooms.Add(room.gameObject);
            }
            if(room.stepToStartRoom==maxStep-1){
                lessFarRooms.Add(room.gameObject);
            }
        }

        for (int i = 0; i < farRooms.Count; i++)
        {
            if(farRooms[i].GetComponent<Room>().doorNums==1)
            {
                oneWayRooms.Add(farRooms[i]);
            }
        }
        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if(lessFarRooms[i].GetComponent<Room>().doorNums==1)
            {
                oneWayRooms.Add(lessFarRooms[i]);
            }
        }

        // if (oneWayRooms.Count != 0)
        // {
        //     endRoomInList=oneWayRooms[Random.Range(0,oneWayRooms.Count)].GetComponent<Room>();
            
        // }else{
        //     endRoomInList=farRooms[Random.Range(0,farRooms.Count)].GetComponent<Room>();
        // }
    }
}
