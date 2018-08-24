using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreToolTip : MonoBehaviour
{
    private Item item;
    private string data;
    private GameObject tooltip;
    public GameObject tooltipPosition;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = tooltipPosition.transform.position;
            //tooltip.transform.position = Input.mousePosition; //설명칸을 만들어야할듯
        }

    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<Color=#0473f0><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
