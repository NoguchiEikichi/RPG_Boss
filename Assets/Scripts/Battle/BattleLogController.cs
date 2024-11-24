using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogController : MonoBehaviour
{
    public int displayTime = 3;
    float currentTime = 0;

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= displayTime) Destroy(this.gameObject);
    }
}
