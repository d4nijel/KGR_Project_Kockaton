using UnityEngine;
public class DestroyBlocks : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
