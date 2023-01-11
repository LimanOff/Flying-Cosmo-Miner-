using UnityEngine;

public static class TransformExtensions 
{
    public static void MoveLeft(this Transform transform, float speed)
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    public static void MoveRight(this Transform transform, float speed)
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
