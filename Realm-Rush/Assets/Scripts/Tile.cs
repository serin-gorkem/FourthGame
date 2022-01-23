using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] Cannon cannonPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    GridManager gridManager;
    PathFinder pathFinder;

    Vector2Int coordinates = new Vector2Int();
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }
    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    private void CannonPlace()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccesfull = cannonPrefab.CreateCannon(cannonPrefab, transform.position);
            if(isSuccesfull)
            {
                gridManager.BlockNode(coordinates);
                pathFinder.NotifyReceivers();   
            }
        }
    }

    void OnMouseDown()
    {

        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccesfull = towerPrefab.CreateTower(towerPrefab, transform.position);
            if(isSuccesfull)
            {
                gridManager.BlockNode(coordinates);
                pathFinder.NotifyReceivers();
            }
        }
    }
    void OnMouseOver() 
    {
    if(Input.GetKey(KeyCode.X))
        {
            CannonPlace();
        }
    }
}
