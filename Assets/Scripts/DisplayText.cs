using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayText : MonoBehaviour
{
    public Text res1Text, res2Text, res3Text, res4Text;
    public Text scanText, extractText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        res1Text.text = "Tiberium : " + GameManager.Instance.res1.ToString();
        res2Text.text = "Unobtanium : " + GameManager.Instance.res2.ToString();
        res3Text.text = "Generic Ore : " + GameManager.Instance.res3.ToString();
        res4Text.text = "Gold : " + GameManager.Instance.res4.ToString();

        scanText.text = "Scans Left : " + GameManager.Instance.scansLeft.ToString();
        extractText.text = "Extracts Left : " + GameManager.Instance.extractsLeft.ToString();
    }
}
