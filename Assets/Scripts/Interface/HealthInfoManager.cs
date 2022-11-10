using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthInfoManager
{
    /// <summary>
    /// 받은 데미지만큼 체력을 감소시키는 함수
    /// </summary>
    void takeDamage(float damage);

}
