using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum ClickStatus
{
    NONE,
    SCAN,
    EXTRACT
}

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
    public int maxCol;
    public int maxRow;
    public GameObject[,] tilesArray;
    public ClickStatus clickStatus;
    public int scansLeft, extractsLeft;
    public double res1, res2, res3, res4;
    public bool resetTiles;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        resetTiles = false;
        clickStatus = ClickStatus.EXTRACT;
        scansLeft = 6;
        extractsLeft = 3;
        res1 = 0;
        res2 = 0;
        res3 = 0;
        res4 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!resetTiles)
        {
            CreateTiles();
            
        }

        if (extractsLeft == 0)
        {
            scansLeft = 0;
            button.gameObject.SetActive(true);
        }

    }
    void CreateTiles()
    {
        Reset();

        tilesArray = new GameObject[maxCol, maxRow];
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                tilesArray[i, j] = (GameObject)Instantiate(tiles, new Vector3(i, j, 0), Quaternion.Euler(tiles.transform.rotation.x, 270, 90));
            }
        }
        resetTiles = true;
    }

    private void Reset()
    {
        clickStatus = ClickStatus.EXTRACT;
        scansLeft = 6;
        extractsLeft = 3;
        res1 = 0;
        res2 = 0;
        res3 = 0;
        res4 = 0;
    }
}
