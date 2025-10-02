using UnityEngine;
using UnityEngine.InputSystem; // �s����J�t��

[RequireComponent(typeof(Camera))]
public class CameraMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return; // �S��������L�N������^

        float h = (k.aKey.isPressed ? -1f : 0f) + (k.dKey.isPressed ? 1f : 0f);
        float v = (k.sKey.isPressed ? -1f : 0f) + (k.wKey.isPressed ? 1f : 0f);
        float y = (k.qKey.isPressed ? -1f : 0f) + (k.eKey.isPressed ? 1f : 0f);

        Vector3 dir = new Vector3(h, y, v);
        if (dir.sqrMagnitude > 0f)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.Self);
        }
    }
}