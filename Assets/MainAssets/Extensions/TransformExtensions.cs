using UnityEngine;

public static class TransformExtensions 
{
    public static void Activate(this Transform transform)
    {
        transform.gameObject.SetActive(true);
    }

    public static void Deactivate(this Transform transform)
    {
        transform.gameObject.SetActive(false);
    }
}
