using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CreateAssetMenu]
public class WonkmyTileBase : RuleTile
{
    public string w_tileBaseName = "";
    [HideInInspector]
    public Sprite look;
    public Tile.ColliderType type;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = look;
        tileData.colliderType = type;
        base.GetTileData(position, tilemap, ref tileData);
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(WonkmyTileBase))]
public class WonkmyTileBaseEditor : Editor
{
    private WonkmyTileBase tile { get { return (target as WonkmyTileBase); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        tile.look = (Sprite)EditorGUILayout.ObjectField("Sprite ", tile.look, typeof(Sprite), false, null);
    }
}
#endif
