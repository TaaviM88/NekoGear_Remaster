using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float destroyTimer = 1f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTimer);
    }
}
