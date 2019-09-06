using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildMode : MonoBehaviour
{
    [HideInInspector]
    public Services services;
    BuildableTile curBuildTile;
    GameObject curBuildTileObj;
    SpriteRenderer curBuildTileSprite;

    public void StartBuildMode(GameObject newBuildTile) {
        curBuildTileObj = newBuildTile;
        curBuildTile = newBuildTile.GetComponent<BuildableTile>();
        curBuildTileSprite = curBuildTileObj.GetComponent<SpriteRenderer>();
    }

    public void RunBuildMode() {
        TileMono hoverTile = services.masterService.hoverTile;
        if(hoverTile) {
            curBuildTileObj.SetActive(true);
            curBuildTileObj.transform.position = hoverTile.transform.position;
            if(curBuildTile.buildableTileTypes.Contains(hoverTile.data.tileType)) {
                curBuildTileSprite.color = new Color32(117, 255, 135, 255);
            } else {
                curBuildTileSprite.color = new Color32(255, 118, 124, 255);
            }
        } else {
            curBuildTileObj.SetActive(false);
        }
    }
}