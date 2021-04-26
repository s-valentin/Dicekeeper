using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static float AngleTowardsMouse(Vector3 position)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5.23f;

        Vector3 objectPosition = Camera.main.WorldToScreenPoint(position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        return angle;
    }
}
