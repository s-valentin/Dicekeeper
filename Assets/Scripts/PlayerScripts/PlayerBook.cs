using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBook : MonoBehaviour
{

    [SerializeField] Transform book;

    void Update()
    {
        rotateBook();
    }

    void rotateBook()
    {
        float angle = Utility.AngleTowardsMouse(book.position);
        book.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle-90f));
    }
}
