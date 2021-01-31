using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNum : MonoBehaviour
{
    public int tileResources;
    public int tileCol, tileRow;
    public List<GameObject> neighbours;
    // Start is called before the first frame update
    void Start()
    {
        tileResources = Random.Range(0, 100);

        tileCol = (int) gameObject.transform.position.x;
        
        tileRow = (int)gameObject.transform.position.y;

        getFirstTileAway();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getFirstTileAway()
    {
        if (tileCol == 0 && tileRow == 0)
        {
            for (int i = 0; i < tileCol + 2; i++)
            {
                for (int j = 0; j < tileRow + 2; j++)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                }
            }
        }

        else if (tileRow == 0)
        {
            if (tileCol == 31)
            {
                for (int i = tileCol; i > tileCol - 2; i--)
                {
                    for (int j = tileRow; j < tileRow + 2; j++)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                        neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                    }
                }
            }
            else
            {
                for (int i = tileCol - 1; i < tileCol + 2; i++)
                {
                    for (int j = 0; j < tileRow + 2; j++)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                        neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                    }
                }
            }
        }

        else if (tileCol == 0)
        {
            if (tileRow == 31)
            {
                for (int i = tileCol; i < tileCol + 2; i++)
                {
                    for (int j = tileRow; j > tileRow - 2; j--)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                        neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < tileCol + 2; i++)
                {
                    for (int j = tileRow - 1; j < tileRow + 2; j++)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                        neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                    }
                }
            }
        }

        else if(tileRow == 31 && tileCol == 31)
        {
            for (int i = tileCol; i > tileCol - 2; i--)
            {
                for (int j = tileRow; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                }
            }
        }
        else if(tileRow == 31)
        {
            for (int i = tileCol + 1; i > tileCol - 2; i--)
            {
                for (int j = tileRow; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                }
            }
        }

        else if(tileCol == 31)
        {
            for (int i = tileCol; i > tileCol - 2; i--)
            {
                for (int j = tileRow + 1; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                }
            }
        }
        else if(tileCol > 0 && tileRow > 0 && tileCol < 31 && tileRow < 31)
        {
            for (int i = tileCol - 1; i < tileCol + 2; i++)
            {
                for (int j = tileRow - 1; j < tileRow + 2; j++)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
                }
            }
        }
    }
}
