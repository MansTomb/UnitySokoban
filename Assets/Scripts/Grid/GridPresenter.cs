using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridPresenter : MonoBehaviour
{
    private Grid _Grid;

    void Start()
    {
        _Grid = new Grid(10, 10, 4);

        for (int i = 0; i < _Grid.grid.GetLength(0); i++)
        {
            for (int j = 0; j < _Grid.grid.GetLength(1); j++)
            {
                Debug.DrawLine(_Grid.GetWorldPosition(i, j), _Grid.GetWorldPosition(i, j + 1), Color.black, 100f);
                Debug.DrawLine(_Grid.GetWorldPosition(i, j), _Grid.GetWorldPosition(i + 1, j), Color.black, 100f);
            }
            Debug.DrawLine(_Grid.GetWorldPosition(0, _Grid.height), _Grid.GetWorldPosition(_Grid.width, _Grid.height), Color.black, 100f);
            Debug.DrawLine(_Grid.GetWorldPosition(_Grid.width, 0), _Grid.GetWorldPosition(_Grid.width, _Grid.height), Color.black, 100f);
        }
    }
}
