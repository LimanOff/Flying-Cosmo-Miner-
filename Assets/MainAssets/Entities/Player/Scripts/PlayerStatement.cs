using UnityEngine;

public class PlayerStatement : MonoBehaviour
{
    public static Statements PlayerState;

    private void OnDisable()
    {
        PlayerState = Statements.Stay;
    }
}

public enum Statements
{
    Stay,
    Moving
}
