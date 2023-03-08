using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public Transform arrowFirePoint;
    
    public int fireRate;

    private float _timeSinceLastShoot;

    private bool CanShoot() => _timeSinceLastShoot > 1f / (fireRate / 60);
    
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.DOLookAt(InputTouch.TouchPoint, 0.2f, AxisConstraint.Y);

            StartCoroutine(Shoot());
        }
        
        _timeSinceLastShoot += Time.deltaTime;
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);

        if (CanShoot())
        {
            ObjectPool.Instance.GetPooledObject(1, arrowFirePoint, transform.rotation.eulerAngles);

            _timeSinceLastShoot = 0;
        }
    }
}
