using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileClick : MonoBehaviour
{
    public int tileClicked;
    private bool tileScanned;
    private int tileNumber;
    // Start is called before the first frame update
    void Start()
    {
        tileScanned = false;
        tileClicked = 0;
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

            var tiles = GetComponent<TileNum>().neighbours;
            var secondTiles = GetComponent<TileNum>().secondNeighbours;

            for (int i = 0; i < tiles.Count; i++)
            {
                var tempPlane = tiles[i].gameObject.GetComponent<Renderer>();
                if (!tiles[i].GetComponent<TileClick>().tileScanned)
                {
                    tempPlane.material.SetColor("_Color", Color.red);
                }
            }

            for (int i = 0; i < secondTiles.Count; i++)
            {
                var tempPlane = secondTiles[i].gameObject.GetComponent<Renderer>();
                if(!secondTiles[i].GetComponent<TileClick>().tileScanned)
                {
                    tempPlane.material.SetColor("_Color", Color.red);
                }
            }
        }

        if (Input.GetMouseButtonDown(0)){
            if (GameManager.Instance.clickStatus == ClickStatus.SCAN && !tileScanned && GameManager.Instance.scansLeft > 0)
            {
                dispColor(gameObject, planeRenderer);
                GetComponentInChildren<TileText>().displayText = true;
                var tiles = GetComponent<TileNum>().neighbours;
                var secondTiles = GetComponent<TileNum>().secondNeighbours;

                for (int i = 0; i < tiles.Count; i++)
                {
                    tiles[i].GetComponentInChildren<TileText>().displayText = true;
                    tiles[i].gameObject.GetComponent<TileClick>().tileScanned = true;
                    var tempPlane = tiles[i].gameObject.GetComponent<Renderer>();
                    dispColor(tiles[i], tempPlane);
                }

                for (int i = 0; i < secondTiles.Count; i++)
                {
                    secondTiles[i].GetComponentInChildren<TileText>().displayText = true;
                    secondTiles[i].gameObject.GetComponent<TileClick>().tileScanned = true;
                    var tempPlane = secondTiles[i].gameObject.GetComponent<Renderer>();
                    dispColor(secondTiles[i], tempPlane);
                }

                tileScanned = true;

                GameManager.Instance.scansLeft--;
            }
            else if(GameManager.Instance.clickStatus == ClickStatus.EXTRACT && GameManager.Instance.extractsLeft > 0)
            {
                GetComponentInChildren<TileText>().displayText = true;

                var tiles = GetComponent<TileNum>().neighbours;
                var secondTiles = GetComponent<TileNum>().secondNeighbours;
                addResource(gameObject);
                changeResource(gameObject);
                dispColor(gameObject, planeRenderer);
                
                for (int i = 0; i < tiles.Count; i ++)
                {
                    tiles[i].GetComponentInChildren<TileText>().displayText = true;
                    var tempPlane = tiles[i].gameObject.GetComponent<Renderer>();
                    tiles[i].gameObject.GetComponent<TileClick>().tileScanned = true;
                    tiles[i].gameObject.GetComponent<TileClick>().tileClicked++;
                    addResource(tiles[i]);
                    changeResource(tiles[i]);
                    dispColor(tiles[i], tempPlane);
                }

                for (int i = 0; i < secondTiles.Count; i++)
                {
                    secondTiles[i].GetComponentInChildren<TileText>().displayText = true;
                    var tempPlane = secondTiles[i].gameObject.GetComponent<Renderer>();
                    secondTiles[i].gameObject.GetComponent<TileClick>().tileScanned = true;
                    secondTiles[i].gameObject.GetComponent<TileClick>().tileClicked++;
                    addResource(secondTiles[i]);
                    changeResource(secondTiles[i]);
                    dispColor(secondTiles[i], tempPlane);
                    
                }

                tileScanned = true;
                tileClicked++;

                GameManager.Instance.extractsLeft--;
            }
        }
    }

    private void OnMouseExit()
    {
        if (!tileScanned)
        {
            var planeRenderer = gameObject.GetComponent<Renderer>();
            planeRenderer.material.SetColor("_Color", Color.white);

            var tiles = GetComponent<TileNum>().neighbours;
            var secondTiles = GetComponent<TileNum>().secondNeighbours;

            for (int i = 0; i < tiles.Count; i++)
            {
                var tempPlane = tiles[i].gameObject.GetComponent<Renderer>();
                if (!tiles[i].GetComponent<TileClick>().tileScanned)
                {
                    tempPlane.material.SetColor("_Color", Color.white);
                }
            }

            for (int i = 0; i < secondTiles.Count; i++)
            {
                var tempPlane = secondTiles[i].gameObject.GetComponent<Renderer>();
                if (!secondTiles[i].GetComponent<TileClick>().tileScanned)
                {
                    tempPlane.material.SetColor("_Color", Color.white);
                }
            }
        }
    }

    void dispColor(GameObject tile, Renderer planeRenderer)
    {
        if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.MAX)
        {
            planeRenderer.material.SetColor("_Color", Color.green);
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.HALF)
        {
            planeRenderer.material.SetColor("_Color", Color.yellow);
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.QUARTER)
        {
            planeRenderer.material.SetColor("_Color", Color.magenta);
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.MIN)
        {
            planeRenderer.material.SetColor("_Color", Color.red);
        }
        else
        {
            planeRenderer.material.SetColor("_Color", Color.grey);
        }
    }

    void changeResource(GameObject tile)
    {
        if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.MAX)
        {
            tile.GetComponent<TileNum>().resourceLeft = ResourceLeft.HALF;
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.HALF)
        {
            tile.GetComponent<TileNum>().resourceLeft = ResourceLeft.QUARTER;
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.QUARTER)
        {
            tile.GetComponent<TileNum>().resourceLeft = ResourceLeft.MIN;
        }
    }

    void addResource(GameObject tile)
    {
        if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.MAX)
        {
            if (tile.GetComponentInChildren<TileText>().tileText.Equals("T"))
            {
                GameManager.Instance.res1 += 1;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("U"))
            {
                GameManager.Instance.res2 += 1;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("O"))
            {
                GameManager.Instance.res3 += 1;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("G"))
            {
                GameManager.Instance.res4 += 1;
            }
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.HALF)
        {
            if (tile.GetComponentInChildren<TileText>().tileText.Equals("T"))
            {
                GameManager.Instance.res1 += 0.5;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("U"))
            {
                GameManager.Instance.res2 += 0.5;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("O"))
            {
                GameManager.Instance.res3 += 0.5;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("G"))
            {
                GameManager.Instance.res4 += 0.5;
            }
        }
        else if (tile.GetComponent<TileNum>().resourceLeft == ResourceLeft.QUARTER)
        {
            if (tile.GetComponentInChildren<TileText>().tileText.Equals("T"))
            {
                GameManager.Instance.res1 += 0.25;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("U"))
            {
                GameManager.Instance.res2 += 0.25;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("O"))
            {
                GameManager.Instance.res3 += 0.25;
            }
            else if (tile.GetComponentInChildren<TileText>().tileText.Equals("G"))
            {
                GameManager.Instance.res4 += 0.25;
            }
        }
        else
        { }
    }

}
