using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;


public class ListButton
{
    public GameObject item;
    public GameObject parent;
    public ListButton(GameObject item){
        this.item = item;
        this.parent =GameObject.Find("Container");//search
    }

    public void ListButtonClick(){
        GameObject.Instantiate(this.item,this.parent.transform);
    }

    public void DeleteButton(){
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject.Destroy(parent.transform.GetChild(i).gameObject);
        }

        //for (parent.getcomponentsInChild<Transform>();){//have self or not?

        //}
    }
}
