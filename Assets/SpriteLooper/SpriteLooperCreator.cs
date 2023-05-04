using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooperCreator : MonoBehaviour
{
public void OnClick() {
    var spriteLooper = FindObjectOfType<SpriteLooper>();
    if (spriteLooper == null) {
        Debug.LogWarning("SpriteLooper not found!");
        return;
    }

    spriteLooper.CreateSprites();
}
}
