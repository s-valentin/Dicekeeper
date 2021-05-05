using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public BoxCollider2D characterCollider;
    public BoxCollider2D characterBlockCollider;
    
    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, characterBlockCollider, true);
    }
}
