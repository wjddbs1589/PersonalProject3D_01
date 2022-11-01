using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour, UseableObject
{
    public int maxCount()
    {
        return 100;
    }

    bool UseableObject.immediatelyUseable()
    {
        return false;
    }

    void UseableObject.objectIneractive()
    {
        GameManager.Inst.ItemManager.saveItem(Itemlist.GlowStick);
        Debug.Log($"{gameObject.name}을 얻었습니다.");
        Destroy(gameObject);
    }

    string UseableObject.objectName()
    {
        return "형광봉";
    }
}
