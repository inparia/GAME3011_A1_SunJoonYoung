using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAgain()
    {
        for (int i = 0; i < GameManager.Instance.maxCol; i++)
        {
            for (int j = 0; j < GameManager.Instance.maxRow; j++)
            {
                Destroy(GameManager.Instance.tilesArray[i, j]);
            }
        }
        GameManager.Instance.resetTiles = false;
        gameObject.SetActive(false);
    }
}
