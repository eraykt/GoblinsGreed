using UnityEngine;

public static class GOBLibrary
{
    public static Vector3 ToVector3(this Vector2 vector2, float y = 0.0f)
    {
        return new Vector3(vector2.x, y, vector2.y);
    }
}
