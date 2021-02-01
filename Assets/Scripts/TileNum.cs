using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceLeft
{
    MAX,
    HALF,
    QUARTER,
    MIN,
    NONE
}
public class TileNum : MonoBehaviour
{
    public int tileResources;
    public int tileCol, tileRow;
    public List<GameObject> neighbours;
    public List<GameObject> secondNeighbours;
    public ResourceLeft resourceLeft;
    // Start is called before the first frame update
    void Start()
    {
        var randNum = Random.Range(0, 9);
        if (randNum == 3)
        {
            tileResources = Random.Range(10, 100);
            resourceLeft = ResourceLeft.MAX;
        }
        else
        {
            tileResources = 0;
            resourceLeft = ResourceLeft.NONE;
        }
        tileCol = (int) gameObject.transform.position.x;
        
        tileRow = (int)gameObject.transform.position.y;

        getFirstTileAway();

        getSecondTileAway();
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
                }
            }
        }

        else if (tileRow == 0)
        {
            if (tileCol == GameManager.Instance.maxCol - 1)
            {
                for (int i = tileCol; i > tileCol - 2; i--)
                {
                    for (int j = tileRow; j < tileRow + 2; j++)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
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
                    }
                }
            }
        }

        else if (tileCol == 0)
        {
            if (tileRow == GameManager.Instance.maxRow - 1)
            {
                for (int i = tileCol; i < tileCol + 2; i++)
                {
                    for (int j = tileRow; j > tileRow - 2; j--)
                    {
                        neighbours.Add(GameManager.Instance.tilesArray[i, j]);
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
                    }
                }
            }
        }

        else if(tileRow == GameManager.Instance.maxRow - 1 && tileCol == GameManager.Instance.maxCol - 1)
        {
            for (int i = tileCol; i > tileCol - 2; i--)
            {
                for (int j = tileRow; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
        }


        else if(tileRow == GameManager.Instance.maxRow - 1)
        {
            for (int i = tileCol + 1; i > tileCol - 2; i--)
            {
                for (int j = tileRow; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
        }

        else if(tileCol == GameManager.Instance.maxCol - 1)
        {
            for (int i = tileCol; i > tileCol - 2; i--)
            {
                for (int j = tileRow + 1; j > tileRow - 2; j--)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
        }
        else if(tileCol > 0 && tileRow > 0 && tileCol < GameManager.Instance.maxCol - 1 && tileRow < GameManager.Instance.maxRow - 1)
        {
            for (int i = tileCol - 1; i < tileCol + 2; i++)
            {
                for (int j = tileRow - 1; j < tileRow + 2; j++)
                {
                    neighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    
                }
            }
        }
        neighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
    }

    void getSecondTileAway()
    {
        if (tileCol <= 1 && tileRow  <= 1)
        {
            for (int i = 0; i < tileCol + 3; i++)
            {
                for (int j = 0; j < tileRow + 3; j++)
                {
                    secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);
                    
                }
            }
        }

        else if (tileCol <= 1)
        {
            if (tileRow >= GameManager.Instance.maxRow - 2)
            {
                for (int i = 0; i < tileCol + 3; i++)
                {
                    for (int j = GameManager.Instance.maxRow - 1; j > tileRow - 3; j--)
                    {
                        secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);

                    }
                }
            }
            else
            {
                for (int i = 0; i < tileCol + 3; i++)
                {
                    for (int j = tileRow + 2; j > tileRow - 3; j--)
                    {
                        secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);

                    }
                }
            }
        }

        else if (tileRow <= 1)
        {
            if (tileCol >= GameManager.Instance.maxCol - 2)
            {
                for (int i = GameManager.Instance.maxCol - 1; i > tileCol - 3; i--)
                {
                    for (int j = 0; j < tileRow + 3; j++)
                    {
                        secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);

                    }
                }
            }
            else
            {
                for (int i = tileCol + 2; i > tileCol - 3; i--)
                {
                    for (int j = 0; j < tileRow + 3; j++)
                    {
                        secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);

                    }
                }
            }
        }

        else if (tileCol >= GameManager.Instance.maxCol - 2 && tileRow >= GameManager.Instance.maxRow - 2)
        {
            for (int i = GameManager.Instance.maxCol - 1; i > tileCol - 3; i--)
            {
                for (int j = GameManager.Instance.maxRow - 1; j > tileRow - 3; j--)
                {
                    secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);

                }
            }
        }

        else if (tileRow >= GameManager.Instance.maxRow - 2)
        {
            for (int i = tileCol - 2; i < tileCol + 3; i++)
            {
                for (int j = tileRow - 2; j < GameManager.Instance.maxRow - 2; j++)
                {
                    secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
        }

        else if (tileCol >= GameManager.Instance.maxCol - 2)
        {
            for (int i = tileCol - 2; i < GameManager.Instance.maxCol - 2; i++)
            {
                for (int j = tileRow - 2; j < tileRow + 3; j++)
                {
                    secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
        }

        else if (tileCol > 1 && tileRow > 1 && tileCol < GameManager.Instance.maxCol - 2 && tileRow < GameManager.Instance.maxRow - 2)
        {
            for (int i = tileCol - 2; i < tileCol + 3; i++)
            {
                for (int j = tileRow - 2; j < tileRow + 3; j++)
                {
                    secondNeighbours.Add(GameManager.Instance.tilesArray[i, j]);
                }
            }
           
        }

        secondNeighbours.Remove(GameManager.Instance.tilesArray[tileCol, tileRow]);
        for (int i = 0; i < neighbours.Count; i++)
        {
            secondNeighbours.Remove(neighbours[i]);
        }
    }
}
