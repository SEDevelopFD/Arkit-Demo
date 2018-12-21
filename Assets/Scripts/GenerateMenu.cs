using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GenerateMenu : MonoBehaviour {

    [SerializeField]
    private GameObject[] items; //在编辑器里直接链接相关物品prefab到itemList
    private float canvasWidth;
    private float canvasHeight;
    [SerializeField]
    private float itemWidth;
    [SerializeField]
    private float itemHeight;
    [SerializeField]
    private float interval;
    [SerializeField]
    private Font m_Font;
	// Use this for initialization
	void Start () {
        //update itemList's transform according to canvas first
        //gameObject.GetComponent<RectTransform>().position = gameObject.transform.parent.GetComponent<RectTransform>().position
          //  +new Vector3(-30f,0,0);
        //get parent canvas's width and height to arrange the menu position
        RectTransform canvas = gameObject.transform.parent.GetComponent<RectTransform>();
        canvasWidth = canvas.rect.width;
        canvasHeight = canvas.rect.height;
        RectTransform menu = gameObject.GetComponent<RectTransform>();
        float posTopLeftX = -canvasWidth/2;
        float posTopLeftY = canvasHeight / 2;
        //Debug.Log(posTopLeftX);
        //Debug.Log(posTopLeftY);
        //calculate column count
        int maxColumnCnt = Mathf.FloorToInt(canvasWidth / (itemWidth + 2*interval));
        //to store the current position of each item
        int row = 0;
        int column = 0;
        //generate and align the items
        for(var i=0; i<items.Length;i++)
        {
            //新建子物品，命名
            GameObject tmpItem = new GameObject(items[i].name,typeof(Button));
            tmpItem.transform.SetParent(gameObject.transform);
            //设置物品名称的text
            GameObject tmpText = new GameObject("Name", typeof(Text));
            tmpText.GetComponent<Text>().text = items[i].name;
            tmpText.GetComponent<Text>().font = m_Font;
            tmpText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            tmpText.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth + interval, 2 * interval);
            tmpText.transform.SetParent(tmpItem.transform);
            //给子物品赋封面图
            Texture2D t = AssetPreview.GetAssetPreview(items[i]);            
            //Sprite temp = Sprite.Create(t, new Rect(0, 0,itemWidth, itemHeight), new Vector2(0.5f, 0.5f));
            GameObject tmpImg = new GameObject("Thumbnail", typeof(RawImage));
            tmpImg.GetComponent<RawImage>().texture = t;
            tmpImg.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth, itemHeight);
            tmpImg.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            tmpImg.transform.SetParent(tmpItem.transform);
            //TODO 排版？改变transform
          
            tmpItem.transform.position = gameObject.transform.position+new Vector3((float)(posTopLeftX + (column+0.5)* (itemWidth + 2*interval)+interval),
                (float)(posTopLeftY-(0.5+row)*(itemHeight+2*interval)-interval),0);
            //Debug.Log(tmpItem.transform.position);
            tmpText.transform.position = tmpItem.transform.position + new Vector3(0f, (float)-0.5 * (itemHeight + 2*interval), 0f);
            column++;
            if(column>=maxColumnCnt)
            {
                row++;
                column = 0;
            }
        }

    }
	
}
