using UnityEngine;
using UnityEngine.InputSystem; // �s����J�t��

[RequireComponent(typeof(Camera))]
public class CameraMove2 : MonoBehaviour
{
    public float moveSpeed = 5f;       // ��¦�t��
    public float boostMultiplier = 2f; // �[�t���v
    public float turnSpeed = 90f;      // ����t��

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // �P�_�O�_�[�t
        float currentSpeed = moveSpeed;
        if (k.spaceKey.isPressed)
        {
            currentSpeed *= boostMultiplier;
        }

        // �e�i/��h (Z �b)
        float v = (k.sKey.isPressed ? -1f : 0f) + (k.wKey.isPressed ? 1f : 0f);

        // ���k���Y (Yaw, ¶ Y �b)
        float yaw = (k.aKey.isPressed ? -1f : 0f) + (k.dKey.isPressed ? 1f : 0f);

        // �W�U���Y�C�Y (Pitch, ¶ X �b)
        float pitch = (k.qKey.isPressed ? -1f : 0f) + (k.eKey.isPressed ? 1f : 0f);

        // �첾�G�e��
        if (Mathf.Abs(v) > 0f)
        {
            transform.Translate(Vector3.forward * v * currentSpeed * Time.deltaTime, Space.Self);
        }

        // ����GYaw ���k
        if (Mathf.Abs(yaw) > 0f)
        {
            transform.Rotate(Vector3.up, yaw * turnSpeed * Time.deltaTime, Space.Self);
        }

        // ����GPitch �W�U
        if (Mathf.Abs(pitch) > 0f)
        {
            transform.Rotate(Vector3.right, pitch * turnSpeed * Time.deltaTime, Space.Self);
        }
    }
}
