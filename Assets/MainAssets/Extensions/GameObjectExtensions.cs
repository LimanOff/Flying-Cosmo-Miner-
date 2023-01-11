using UnityEngine;

public static class GameObjectExtensions
{
    public static void Activate(this GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void Deactivate(this GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
