using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public Transform[] transform;

    private int i;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (i < 6)
            {
                var enemyType1 = ObjectPool.Instantiate.GetPooledObject(0);

                enemyType1.transform.position = transform[i].position;
            }

            else
            {
                i = 0;
            }
        
            i++;
        }
    }
}
