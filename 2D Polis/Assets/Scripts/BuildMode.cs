using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildMode : MonoBehaviour
{
    [HideInInspector]
    public Services services;
    public GameObject buildTileMarkerPrefab;
    GameObject buildMarker;
    SpriteRenderer buildMarkerSprite;
    BuildableTile curBuildTile;

    public void StartBuildMode(GameObject newBuildTile) {
        services.masterService.curMode = GameModes.Build;
        buildMarker = (GameObject)Instantiate(buildTileMarkerPrefab, new Vector3(0, 0, 0), buildTileMarkerPrefab.transform.rotation);
        curBuildTile = newBuildTile.GetComponent<BuildableTile>();
        buildMarkerSprite = buildMarker.GetComponent<SpriteRenderer>();
    }

    public void RunBuildMode() {
        TileMono hoverTile = services.masterService.hoverTile;
        if(hoverTile) {
            buildMarker.SetActive(true);
            buildMarker.transform.position = hoverTile.transform.position;
            if(curBuildTile.buildableTileTypes.Contains(hoverTile.data.tileType)) {
                buildMarkerSprite.color = new Color32(117, 255, 135, 255);
            } else {
                buildMarkerSprite.color = new Color32(255, 118, 124, 255);
            }
        } else {
            buildMarker.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0)) {
            if(services.masterService.hoverTile) {
                Place(services.masterService.hoverTile);
            }
        }
    }

    public void Place(TileMono replaceTile) {
        Debug.Log("Place " + replaceTile.data.loc);
        services.mapService.ReplaceTile(replaceTile.data.loc, curBuildTile);
    }

    public void ExitBuildMode() {
        services.masterService.curMode = GameModes.Run;
        Destroy(buildMarker);
    }
}