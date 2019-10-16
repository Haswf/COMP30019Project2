using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Image ImageSelection;
    public List<Sprite> ItemList = new List<Sprite>();
    private int itemSpot = 0;
   
    public void RightSelection()
    {
        if(itemSpot < ItemList.Count - 1)
        {
            itemSpot++;
            ImageSelection.sprite = ItemList[itemSpot];
        }
    }

    public void LeftSelection()
    {
        if (itemSpot > 0)
        {
            itemSpot--;
            ImageSelection.sprite = ItemList[itemSpot];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
