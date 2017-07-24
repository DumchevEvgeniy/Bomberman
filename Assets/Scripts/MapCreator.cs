using System;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public Int32 length = 5;
    public Int32 width = 5;
    [SerializeField] private GameObject mapPrefab;
    [SerializeField] private GameObject concreteCubePrefab;
    [SerializeField] private Camera cameraPrefab;
    private GameObject map;
    private Field field;

    void Start() {
        MapSize.AdjustmentSize(ref width, ref length);
        field = new Field(width, length);
        InitializeMap();
        InitializeConcreteCubes();
        InitializeComponents();
        CreateAll();
        InitializeCamera();
    }

    public void CreateAll() {
        field.ForEach(cell => {
            if(!cell.IsEmpty()) {
                var element = cell.GameObject;
                element.transform.position = new Vector3(cell.IndexRow, 1, cell.IndexColumn);
                Instantiate(element);
            }
        });
    }

    private void InitializeCamera() {
        if(cameraPrefab == null)
            return;
        Single onCenterWithOffsetByWidthMap = (Single)(width * 70 / 100.0);
        Single heightCamera = (Single)(length / width * onCenterWithOffsetByWidthMap);
        Single onCenterByHeightMap = (Single)(length / 2.0);
        cameraPrefab.transform.position = new Vector3(onCenterWithOffsetByWidthMap, heightCamera, onCenterByHeightMap);
        cameraPrefab.transform.rotation = Quaternion.Euler(80, 270, 0);
        cameraPrefab.fieldOfView = 100;
    }

    private void InitializeMap() {
        map = Instantiate(mapPrefab) as GameObject;
        Single offsetByX = (Int32)(width / 2.0);
        Single offsetByZ = (Int32)(length / 2.0);
        map.transform.position = new Vector3(offsetByX, 0, offsetByZ);
        map.transform.localScale = new Vector3(width, mapPrefab.transform.localScale.y, length);
        map.transform.rotation = new Quaternion();
    }
    private void InitializeConcreteCubes() {
        for(Int32 indexRow = 0; indexRow < field.Width; indexRow++) {
            for(Int32 indexColumn = 0; indexColumn < field.Length; indexColumn++) {
                if(OnLeftOrRightBorder(indexColumn) || OnTopOrBottomBorder(indexRow) || OnNeededPosition(indexRow, indexColumn)) {
                    var concreteCube = concreteCubePrefab;
                    concreteCube.transform.position = new Vector3(indexRow, 1, indexColumn);
                    concreteCube.transform.rotation = new Quaternion();
                    field.AddElement(indexRow, indexColumn, concreteCube);
                }
            }
        }
    }
    private void InitializeComponents() {
        var components = GetComponents<BaseSetLocationForElements>();
        if(components == null || components.Length == 0)
            return;
        foreach(var gameObjectsCreator in components) {
            gameObjectsCreator.InitializeElements();
        }
    }

    private Boolean OnLeftOrRightBorder(Int32 indexColumn) {
        return indexColumn == 0 || indexColumn == length - 1;
    }
    private Boolean OnTopOrBottomBorder(Int32 indexRow) {
        return indexRow == 0 || indexRow == width - 1;
    }
    private Boolean OnNeededPosition(Int32 indexRow, Int32 indexColumn) {
        return indexRow % 2 == 0 && indexColumn % 2 == 0;
    }

    public Field Field {
        get { return field; }
    }
}
