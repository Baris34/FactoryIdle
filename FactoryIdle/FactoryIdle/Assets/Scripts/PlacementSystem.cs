using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator,cellIndicator;
    [SerializeField]
    private InputManager ýnputManager;
    [SerializeField]
    private Grid grid;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = ýnputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);

    }
}
