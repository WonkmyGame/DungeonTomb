using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 生成世界基础物
/// </summary>
public class GeneratorWorldBase: MonoBehaviour
{
    private GeneratorPlants generatorPlants;
    private GeneratorSurface generatorSurface;
    public GeneratorWorldBase() {
        generatorPlants = new GeneratorPlants(4);
        generatorSurface = new GeneratorSurface();
    }
    public IEnumerator GeneratorWorld(Tilemap tm,int worldWidth,int worldHeight, TileBase tb_dirt, TileBase tb_grass, TileBase tb_Tallgrass, TileBase tb_treeBase, TileBase tb_treeLeave, TileBase tb_stone)
    {
        for (int i = 0; i < worldWidth; i++)
        {
            int randomHeight = GameUtility.randomDistribution(1, worldHeight, 5);
            //int randomHeight = Random.Range(1, worldHeight);
            for (int j = 0; j < randomHeight; j++)
            {
                //tm.SetTile(new Vector3Int(i - 9, j - 5, 0), tb_dirt);//土地
                //tm.SetTile(new Vector3Int(i - 9, randomHeight - 5, 0), tb_grass);//草地
                generatorSurface.Generator(tm, new Vector3Int(i, j , 0), randomHeight, tb_dirt, tb_grass, tb_stone);
                generatorPlants.Generator(tm, new Vector3Int(i, randomHeight + 3, 0), tb_Tallgrass, tb_treeBase, tb_treeLeave);
                CheckIsHaveNullInTilemap(tm);
            }
            yield return 0.2f;
        }
    }

    public void CheckIsHaveNullInTilemap(Tilemap tm) {
        for (int i = 0; i < tm.origin.x; i++)
        {
            for (int j = 0; j < tm.origin.y; j++)
            {
                if(tm.GetTile(new Vector3Int(i,j,0))==null)
                {
                    tm.SetTile(new Vector3Int(i - 1, j, 0), tm.GetTile(new Vector3Int(i - 1, j, 0)));
                }
            }
        }
    }
}
