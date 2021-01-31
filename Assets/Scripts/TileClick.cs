using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClickStatus
{
    NONE,
    SCAN,
    OPEN
}
public class TileClick : MonoBehaviour
{

    private bool tileOpened;
    private bool tileScanned;
    private int tileNumber;
    public ClickStatus clickStatus;
    // Start is called before the first frame update
    void Start()
    {
        tileOpened = false;
        tileScanned = false;
        clickStatus = ClickStatus.NONE;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        
        var planeRenderer = gameObject.GetComponent<Renderer>();
        if (!tileScanned)
        {
            planeRenderer.material.SetColor("_Color", Color.red);
        }

        if (Input.GetMouseButtonDown(0)){
            if (!tileScanned)
            {
                tileScanned = true;
                planeRenderer.material.SetColor("_Color", Color.blue);
            }
            else if(tileScanned && !tileOpened)
            {
                planeRenderer.material.SetColor("_Color", Color.yellow);
                tileNumber = GetComponent<TileNum>().tileResources;
                GetComponentInChildren<TileText>().displayText = true;
                var tiles = GetComponent<TileNum>().neighbours;
                for (int i = 0; i < tiles.Count; i ++)
                {
                    tiles[i].GetComponentInChildren<TileText>().displayText = true;
                    var tempPlane = tiles[i].gameObject.GetComponent<Renderer>();
                    tempPlane.material.SetColor("_Color", Color.magenta);
                    tiles[i].gameObject.GetComponent<TileClick>().tileScanned = true;
                    tiles[i].gameObject.GetComponent<TileClick>().tileOpened = true;
                }
                tileOpened = true;
                Debug.Log(tileNumber);
            }
            Debug.Log(gameObject.transform.position.x + " " + gameObject.transform.position.y);
        }
    }

    private void OnMouseExit()
    {
        if (!tileScanned)
        {
            var planeRenderer = gameObject.GetComponent<Renderer>();
            planeRenderer.material.SetColor("_Color", Color.white);
        }
    }

   
}
