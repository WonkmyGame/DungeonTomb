using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject upDoor, downDoor, leftDoor, rightDoor;

    public bool upDoorActive, downDoorActive, leftDoorActive, rightDoorActive;

    public int doorNums;
    public int stepToStartRoom;

    void Start()
    {
        upDoor.SetActive(upDoorActive);
        downDoor.SetActive(downDoorActive);
        leftDoor.SetActive(leftDoorActive);
        rightDoor.SetActive(rightDoorActive);
    }

    public void UpdateRoomInfo(float xOffset,float yOffset)
    {
        stepToStartRoom = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));
        GetComponentInChildren<TextMeshPro>().text = stepToStartRoom.ToString();

        if (upDoor)
            doorNums++;
        if (downDoor)
            doorNums++;
        if (leftDoor)
            doorNums++;
        if (rightDoor)
            doorNums++;
    }
}
