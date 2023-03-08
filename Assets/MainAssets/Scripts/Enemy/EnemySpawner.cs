using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnerTransforms;

    private int i;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (i < 6)
            {
                var enemyType1 = ObjectPool.Instance.GetPooledObject(0, spawnerTransforms[i], Vector3.zero);
            }

            else
            {
                i = 0;
            }
        
            i++;
        }
    }
}
