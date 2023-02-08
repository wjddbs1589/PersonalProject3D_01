using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UseableObject
{
    /// <summary>
    /// 상호작용할 때 실행될 함수
    /// </summary>
    void objectInteractive();

    /// <summary>
    /// 상호작용 가능한 오브젝트의 이름 반환할 함수
    /// </summary>
    /// <returns>현재 마우스가 가리키고있는 오브젝트명 반환</returns>
    string objectName();

    /// <summary>
    /// 인벤토리에 보유중인 아이템을 사용하는 함수
    /// </summary>
    void UseItem();

    /// <summary>
    /// 현재 아이템의 스프라이트를 반환
    /// </summary>
    /// <returns>현재 아이템의 스프라이트</returns>
    Sprite returnItemSprite();
    
}
