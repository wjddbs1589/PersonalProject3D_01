using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UseableObject 
{
    /// <summary>
    /// 아이템이 바로 사용될 것인지 확인할 함수
    /// </summary>
    /// <returns>true면 바로사용되는 아이템, false면 인벤토리에 저장되는 아이템</returns>
    bool immediatelyUseable();    

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
    /// 아이템의 최대 소지갯수를 반환
    /// </summary>
    /// <returns>아이템의 소지가능 개수를 반환</returns>
    int maxCount();
}
