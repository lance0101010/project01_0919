using UnityEngine;
using UnityEngine.InputSystem; // 新版輸入系統

[RequireComponent(typeof(Camera))]
public class CameraMove2 : MonoBehaviour
{
    public float moveSpeed = 5f;       // 基礎速度
    public float boostMultiplier = 2f; // 加速倍率
    public float turnSpeed = 90f;      // 旋轉速度

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // 判斷是否加速
        float currentSpeed = moveSpeed;
        if (k.spaceKey.isPressed)
        {
            currentSpeed *= boostMultiplier;
        }

        // 前進/後退 (Z 軸)
        float v = (k.sKey.isPressed ? -1f : 0f) + (k.wKey.isPressed ? 1f : 0f);

        // 左右轉頭 (Yaw, 繞 Y 軸)
        float yaw = (k.aKey.isPressed ? -1f : 0f) + (k.dKey.isPressed ? 1f : 0f);

        // 上下抬頭低頭 (Pitch, 繞 X 軸)
        float pitch = (k.qKey.isPressed ? -1f : 0f) + (k.eKey.isPressed ? 1f : 0f);

        // 位移：前後
        if (Mathf.Abs(v) > 0f)
        {
            transform.Translate(Vector3.forward * v * currentSpeed * Time.deltaTime, Space.Self);
        }

        // 旋轉：Yaw 左右
        if (Mathf.Abs(yaw) > 0f)
        {
            transform.Rotate(Vector3.up, yaw * turnSpeed * Time.deltaTime, Space.Self);
        }

        // 旋轉：Pitch 上下
        if (Mathf.Abs(pitch) > 0f)
        {
            transform.Rotate(Vector3.right, pitch * turnSpeed * Time.deltaTime, Space.Self);
        }
    }
}
