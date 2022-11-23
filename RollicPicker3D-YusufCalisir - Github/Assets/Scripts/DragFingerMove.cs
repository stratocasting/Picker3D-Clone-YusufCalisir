using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    void OnEnable()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 1, 3).setEaseShake().setLoopCount(10);
    }
}
