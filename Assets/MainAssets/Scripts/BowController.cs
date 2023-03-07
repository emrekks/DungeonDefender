using System;
using DG.Tweening;
using UnityEngine;

public class BowController : MonoBehaviour
{
    private void Update()
    {
        transform.DOLookAt(InputTouch.TouchPoint, 0, AxisConstraint.Y);
    }
}
