using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class RectUtility
{
    public static Rect CutLeft(this ref Rect rect, float size)
    {
        var result = new Rect(rect.xMin, rect.yMin, size, rect.height);
        rect.Set(result.xMax, rect.yMin, rect.width - size, rect.height);
        return result;
    }

    public static Rect CutTop(this ref Rect rect, float size)
    {
        var result = new Rect(rect.xMin, rect.yMin, rect.width, size);
        rect.Set(rect.xMin, result.yMax, rect.width, rect.height - size);
        return result;
    }

    public static Rect CutRight(this ref Rect rect, float size)
    {
        var result = new Rect(rect.xMax - size, rect.yMin, size, rect.height);
        rect.Set(rect.xMin, rect.yMin, rect.width - size, rect.height);
        return result;
    }

    public static Rect CutBottom(this ref Rect rect, float size)
    {
        var result = new Rect(rect.xMin, rect.yMin - size, rect.width, size);
        rect.Set(rect.xMin, rect.yMin, rect.width, rect.height - size);
        return result;
    }

    public static Rect CutSingleLine(this ref Rect rect)
    {
        return rect.CutTop(EditorGUIUtility.singleLineHeight);
    }

    public static Rect CutLabelWidth(this ref Rect rect)
    {
        return rect.CutLeft(EditorGUIUtility.labelWidth);
    }

    public static Rect Grow(this Rect rect, float value)
    {
        rect.position -= Vector2.one * value;
        rect.size += Vector2.one * value * 2f;
        return rect;
    }

    public static Rect Shrink(this Rect rect, float value)
    {
        return Grow(rect, -value);
    }

    public static Vector2 NormalizedValueToPoint(this Rect rect, Vector2 normalizedValue)
    {
        return new Vector2(
            Mathf.Lerp(rect.xMin, rect.xMax, normalizedValue.x),
            Mathf.Lerp(rect.yMin, rect.yMax, normalizedValue.y));
    }

    public static Vector2 PointToNormalizedValue(this Rect rect, Vector2 point)
    {
        return new Vector2(
            Mathf.InverseLerp(rect.xMin, rect.xMax, point.x),
            Mathf.InverseLerp(rect.yMin, rect.yMax, point.y));
    }

#if UNITY_EDITOR

    public static bool IsClicked(this Rect rect, bool useEvent = false)
    {
        if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
        {
            if (useEvent)
            {
                Event.current.Use();
            }

            return true;
        }

        return false;
    }

#endif
}