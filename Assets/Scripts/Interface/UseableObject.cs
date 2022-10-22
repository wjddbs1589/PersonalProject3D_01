using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UseableObject 
{
    //아이템이 바로 사용될 것인지 확인할 함수
    bool directUseable();    
    //맵에 있는 아이템 상호 작용할 함수
    void objectIneractive();
    // 상호작용 가능한 오브젝트의 이름 반환할 함수
    string objectName();
}
