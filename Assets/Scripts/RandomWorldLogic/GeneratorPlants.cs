using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratorPlants: MonoBehaviour
{
    private int seed;
    public int Seed
    {
        get
        {
            return seed;
        }
        set
        {
            if(seed>5)
            {
                seed = 5;
            }else if(seed<=1)
            {
                seed = 2;
            }
            seed = value;
        }
    }
    /// <summary>
    /// 生成种子
    /// </summary>
    /// <param name="seed"></param>
    public GeneratorPlants(int seed)
    {
        Seed = seed;
    }
    /// <summary>
    /// 生成普通植物
    /// </summary>
    /// <param name="tm"></param>
    /// <param name="isTallPlant">是否是高植物</param>
    /// <param name="plantBase"></param>
    /// <param name="pos">生成的位置</param>
    public void GenerateP(Tilemap tm, bool isTallPlant, TileBase plantBase, Vector3Int pos)
    {
        int rand = GameUtility.randomDistribution(0, 15, Seed+1);
        if (rand < 8)
        {
            rand = GameUtility.randomDistribution(10, 50, Seed-1);
            if (rand > 40)
            {
                if (isTallPlant)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5 + i, 0)))
                        {
                            tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5 + i, 0), plantBase);
                        }
                    }
                }
                else
                {
                    if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5, 0)))
                    {
                        tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5, 0), plantBase);
                    }
                }

            }
        }
        else
        {
            rand = GameUtility.randomDistribution(10, 50, Seed-1);
            if (rand < 20)
            {
                if (isTallPlant)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5 + i, 0)))
                        {
                            tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5 + i, 0), plantBase);
                        }
                    }
                }
                else
                {
                    if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5, 0)))
                    {
                        tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5, 0), plantBase);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 生成有叶子的树木
    /// </summary>
    /// <param name="tm"></param>
    /// <param name="treeBase"></param>
    /// <param name="treeLeave"></param>
    /// <param name="pos"></param>
    public void GenerateP(Tilemap tm, TileBase treeBase, TileBase treeLeave, Vector3Int pos,int treeHeight=3)
    {
        int rand = GameUtility.randomDistribution(0, 15, Seed+1);

        if (rand < 3)
        {
            rand = GameUtility.randomDistribution(10, 50, 2);
            if (rand > 40)
            {
                for (int i = 0; i < treeHeight; i++)
                {
                    if (i < 2)
                    {

                        if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5 + i, 0)))
                        {
                            tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5 + i, 0), treeBase);
                        }
                    }
                    else
                    {
                        for (int j = 8; j < 11; j++)
                        {
                            if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - j, pos.y - 5 + i, 0)))
                            {
                                tm.SetTile(new Vector3Int(pos.x - j, pos.y - 5 + i, 0), treeLeave);
                            }
                        }
                    }
                }
            }
        }
        else if (rand > 11)
        {
            rand = GameUtility.randomDistribution(10, 50, Seed-1);
            if (rand < 10)
            {
                for (int i = 0; i < treeHeight; i++)
                {
                    if (i < 2)
                    {

                        if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - 9, pos.y - 5 + i, 0)))
                        {
                            tm.SetTile(new Vector3Int(pos.x - 9, pos.y - 5 + i, 0), treeBase);
                        }
                    }
                    else
                    {
                        for (int j = 8; j < 11; j++)
                        {
                            if (!GameUtility.CheckMapHaveTile(tm, new Vector3Int(pos.x - j, pos.y - 5 + i, 0)))
                            {
                                tm.SetTile(new Vector3Int(pos.x - j, pos.y - 5 + i, 0), treeLeave);
                            }
                        }
                    }
                }
            }
        }
    }

    public void Generator(Tilemap tm,Vector3Int pos,TileBase tb_Tallgrass, TileBase tb_treeBase, TileBase tb_treeLeave)
    {
        GenerateP(tm, false, tb_Tallgrass,pos);
        GenerateP(tm, tb_treeBase, tb_treeLeave, pos);
    }
}
