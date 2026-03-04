using UnityEngine;
using UnityEngine.InputSystem; // 必须使用新版输入系统命名空间

public class KeyboardQuit : MonoBehaviour
{
    void Update()
    {
        // 检测键盘上的 Escape 键是否被按下
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("检测到退出指令");

            // 情况 A：如果在 Unity 编辑器里运行，点击退出会让 Play 模式停止
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; 
            #else
                // 情况 B：如果是在导出后的程序中运行，则直接关闭应用
                Application.Quit(); 
            #endif
        }
    }
}
