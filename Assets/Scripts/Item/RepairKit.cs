using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour, UseableObject
{
    public bool immediatelyUseable()
    {
        return false;
    }

    public int maxCount()
    {
        return 4;
    }

    public void objectIneractive()
    {
        // 인벤토리에 저장
        GameManager.Inst.ItemManager.saveItem(Itemlist.RepairKit);
        Debug.Log($"{gameObject.name}을 얻었습니다.");
        Destroy(gameObject);
    }

    public string objectName()
    {
        return "수리키트";
    }
}
