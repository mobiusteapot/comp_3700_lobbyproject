using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListItem : MonoBehaviour
{
    [SerializeField] TMP_Text labelText;
    // Start is called before the first frame update
    public string Label
    {
        get
        {
            return labelText.text;
        }
        set
        {
            labelText.text = value;
        }
    }
}
