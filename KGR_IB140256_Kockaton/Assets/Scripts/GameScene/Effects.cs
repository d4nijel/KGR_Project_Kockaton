using UnityEngine;
public class Effects : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Rotate(3, 0, 0);
    }
}
