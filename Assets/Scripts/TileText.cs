using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileText : MonoBehaviour
{
    private TextMesh dtext;
    private int tileResources;
    public bool displayText;
    public string tileText;
    // Start is called before the first frame update
    void Start()
    {
        dtext = GetComponent<TextMesh>();
        tileResources = GetComponentInParent<TileNum>().tileResources;
        displayText = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(displayText)
        {
            dispText();
        }
        setText();

    }

    void dispText()
    {
        if (tileResources >= 75)
        {
            dtext.text = "T";
        }
        else if (tileResources >= 50)
        {
            dtext.text = "U";
        }
        else if (tileResources >= 25)
        {
            dtext.text = "O";
        }
        else if(tileResources > 10)
        {
            dtext.text = "G";
        }
        else
        {
            dtext.text = "";
        }
    }

    void setText()
    {
        if (tileResources >= 75)
        {
            tileText = "T";
        }
        else if (tileResources >= 50)
        {
            tileText = "U";
        }
        else if (tileResources >= 25)
        {
            tileText = "O";
        }
        else if (tileResources > 10)
        {
            tileText = "G";
        }
        else
        {
        }
    }
}
