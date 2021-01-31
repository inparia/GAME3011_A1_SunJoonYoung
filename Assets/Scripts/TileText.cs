using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileText : MonoBehaviour
{
    private TextMesh dtext;
    private int tileResources;
    public bool displayText;
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
        else
        {
            dtext.text = "G";
        }
    }
}
