using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonBehaviour : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.clickStatus == ClickStatus.SCAN)
        {
            text.text = "Scan Mode";
        }
        else if(GameManager.Instance.clickStatus == ClickStatus.EXTRACT)
        {
            text.text = "Extract Mode";
        }
        else
        {
            text.text = "Click to Change Mode";
        }
    }

    public void ScanMode()
    {
        GameManager.Instance.clickStatus = ClickStatus.SCAN;
    }

    public void OpenMode()
    {
        GameManager.Instance.clickStatus = ClickStatus.EXTRACT;
    }
}
