using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooperPlaytime : MonoBehaviour {

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int horizontalCount;
    [SerializeField] private int verticalCount;
    [SerializeField] private float spacing;
    [SerializeField] private bool overlap;

    private void Start() {
        // Получаем размер спрайта
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Рассчитываем размер с учетом количества объектов и расстоянием между ними
        float finalWidth = spriteSize.x * horizontalCount + (spacing * (horizontalCount - 1));
        float finalHeight = spriteSize.y * verticalCount + (spacing * (verticalCount - 1));

        // Рассчитываем начальную позицию для первого спрайта в центре
        Vector2 startPosition = new Vector2(-(finalWidth / 2) + spriteSize.x / 2, finalHeight / 2 - spriteSize.y / 2);

        for (int y = 0; y < verticalCount; y++) {
            for (int x = 0; x < horizontalCount; x++) {
                GameObject newSpriteObj = new GameObject("Sprite");
                SpriteRenderer newSpriteRenderer = newSpriteObj.AddComponent<SpriteRenderer>();

                // Если необходимо, компенсируем наложение спрайтов друг на друга
                float offset = 0;
                if (overlap) {
                    offset = spriteSize.y / 2;
                }

                // Рассчитываем позицию для нового спрайта
                Vector2 newPosition = new Vector2(startPosition.x + spriteSize.x * x + spacing * x,
                    startPosition.y - spriteSize.y * y - spacing * y - offset);

                // Устанавливаем спрайт и позицию
                newSpriteRenderer.sprite = spriteRenderer.sprite;
                newSpriteObj.transform.position = transform.position + (Vector3)newPosition;
                newSpriteObj.transform.SetParent(transform);
            }
        }
    }

}