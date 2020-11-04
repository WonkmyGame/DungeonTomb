using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EntityGenerator : MonoBehaviour
{
    public abstract void Generator(Tilemap tm, int worldWidth, int worldHeight, TileBase tb_dirt, TileBase tb_grass, TileBase tb_Tallgrass, TileBase tb_treeBase, TileBase tb_treeLeave);
    public abstract void Generator(Tilemap tm, Vector3Int pos, TileBase tb_Tallgrass, TileBase tb_treeBase, TileBase tb_treeLeave);
}
