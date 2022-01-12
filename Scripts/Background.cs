using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ���͸���
    public Material bgMaterial;
    // ��ũ�Ѽӵ�
    public float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 1. ��� �ִ� ���� ��� �ϰ� �ʹ�.
    // Update is called once per frame
    void Update()
    {
        // 2. ������ �ʿ��ϴ�.
        Vector2 direction = Vector2.up;
        // 3. ��ũ���� �ϰ� �ʹ�. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
