using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    public GameObject tiles;
    public int ColumnLength;
    public int RowHeight;
    public GameObject[,] tilesArray;


    // Start is called before the first frame update
    void Start()
    {
        tilesArray = new GameObject[ColumnLength, RowHeight];
        for (int i = 0; i < ColumnLength; i++)
        {
            for (int j = 0; j < RowHeight; j++)
            {
                tilesArray[i, j] = (GameObject)Instantiate(tiles, new Vector3(i, j, 0), Quaternion.Euler(tiles.transform.rotation.x, 270, 90));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getNext(float x, float y)
    {
        int tempx = (int)x;
        int tempy = (int)y;
        tilesArray[tempx + 1, tempy].GetComponentInChildren<TileText>().displayText = true;
    }

}
