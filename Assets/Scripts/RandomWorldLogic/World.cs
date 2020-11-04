using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class World : MonoBehaviour
{
    Tilemap tm;
    [Header("图块类型")]
    [Tooltip("泥土块")]
    public TileBase tb_dirt;
    [Tooltip("草地块")]
    public TileBase tb_grass;
    [Tooltip("高草块")]
    public TileBase tb_Tallgrass;
    [Tooltip("树干块")]
    public TileBase tb_treeBase;
    [Tooltip("树叶块")]
    public TileBase tb_treeLeave;
    [Tooltip("石头块")]
    public TileBase tb_stone;
    [Header("世界宽度")]
    public int worldWidth;
    [Header("世界高度")]
    public int worldHeight;

    private GeneratorWorldBase generatorWorldBase;

    private void Start()
    {
        tm = GetComponent<Tilemap>();
        generatorWorldBase = new GeneratorWorldBase();
        StartCoroutine(generatorWorldBase.GeneratorWorld(tm, worldWidth, worldHeight, tb_dirt, tb_grass, tb_Tallgrass, tb_treeBase, tb_treeLeave, tb_stone));
    }
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            tm.ClearAllTiles();
            StartCoroutine(generatorWorldBase.GeneratorWorld(tm, worldWidth, worldHeight, tb_dirt, tb_grass, tb_Tallgrass, tb_treeBase, tb_treeLeave, tb_stone));
        }
    }
   


    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 worldPosOfMouse= Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector3Int cellPos = tm.WorldToCell(worldPosOfMouse);
    //        tm.SetTile(cellPos, null);
    //    }
    //}
}
