using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UseableObject
{
    /// <summary>
    /// 맵에 있는 아이템 상호 작용할 함수
    /// </summary>
    void objectIneractive();

    /// <summary>
    /// 상호작용 가능한 오브젝트의 이름 반환할 함수
    /// </summary>
    /// <returns>현재 조준하고있는 오브젝트명 반환</returns>
    string objectName();

    /// <summary>
    /// 아이템을 사용하는 함수
    /// </summary>
    void UseItem();
    
}
