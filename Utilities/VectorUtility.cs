using UnityEngine;

public static class VectorUtility {
    public static Vector3 Vector2DTo3D(this Vector2 vector) {
        return new Vector3(vector.x, 0f, vector.y);
    }

    public static Vector2 Vector3DTo2D(this Vector3 vector) {
        return new Vector2(vector.x, vector.z);
    }
}