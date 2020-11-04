using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 生成地表（地形）
/// </summary>
public class GeneratorSurface : MonoBehaviour
{
    public void Generator(Tilemap tm,Vector3Int pos,int randomHeight,TileBase tb_dirt, TileBase tb_grass,TileBase tb_stone)
    {
        tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 3, 0), tb_dirt);//草地
        tm.SetTile(new Vector3Int(pos.x - 9, randomHeight - 3, 0), tb_grass);//土地
        
            tm.SetTile(new Vector3Int(pos.x - 9, pos.y-5, 0), tb_stone);//石头
        
    }
}
