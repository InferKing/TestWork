using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableModel : MonoBehaviour
{
    private GameObject[,] arrayOfPoint = new GameObject[2,3];
    [SerializeField] private GameObject[] prefab; // 0 is square, 1 is circle
    private void Awake()
    {
        for (int col = 0; col < 2; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                int index = col == 1 && row == 2 ? 0 : 1; 
                arrayOfPoint[col, row] = Instantiate(prefab[index]);
                arrayOfPoint[col, row].transform.position = new Vector3(col * 2f - 1f, row * 2f - 2f, 0);
            }
        }
    }

    public bool HasActiveCircle()
    {
        for (int col = 0; col < 2; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (arrayOfPoint[col,row].activeSelf && arrayOfPoint[col,row].tag == "Circle")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
