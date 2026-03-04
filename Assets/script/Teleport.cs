using UnityEngine;
using UnityEngine.InputSystem; // 保持引用，解决之前的报错

public class TeleportLogic : MonoBehaviour
{
    // 1. 定义要移动的对象（你的 XR Origin）
    public Transform playerTransform; 
    
    // 2. 定义两个位置坐标
    public Vector3 roomPosition = new Vector3(0, 0, 0);       // 房间内
    public Vector3 externalPosition = new Vector3(-20, 0, 0); // 房间外

    // 3. 增加一个逻辑开关
    private bool inRoom = true; 

    void Update()
    {
        // 4. 使用同样的 Keyboard 检测方式，这次改为空格键
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (inRoom)
            {
                // 如果在房间里，就跳到外面
                playerTransform.position = externalPosition;
                inRoom = false;
            }
            else
            {
                // 如果在外面，就跳回房间
                playerTransform.position = roomPosition;
                inRoom = true;
            }

            Debug.Log("位置已切换！当前在房间内吗：" + inRoom);
        }
    }
}