using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour, UseableObject
{
    Rigidbody rigid;
    ItemManager itemManager;
    public ItemUsePos itemUsePos;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        itemUsePos = FindObjectOfType<ItemUsePos>();
    }
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.GlowStick))
        {
            Destroy(gameObject);
        }
    }

    public string objectName()
    {
        return "야광봉";
    }

    public void UseItem()
    {
        GameObject obj = Instantiate(GameManager.Inst.ItemManager.SavedItem[(int)Itemlist.GlowStick]);
        obj.transform.position = itemUsePos.transform.position;
        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.GetComponent<Collider>().isTrigger = false;

        //rigid.AddForce(GameManager.Inst.Player.cameraTarget.transform.forward, ForceMode.Force);

        itemManager.currentItemCount[(int)Itemlist.GlowStick]--;
        if (itemManager.currentItemCount[(int)Itemlist.GlowStick] == 0)
        {
            itemManager.ItemDelete(Itemlist.GlowStick);
            Destroy(gameObject);
        }
    }
   
}
