using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if(GameManager.Instance.IsPlaying == true)
        {
            if (kb.digit1Key.wasPressedThisFrame || kb.numpad1Key.wasPressedThisFrame)
            LaneRouter.For(1)?.TryHit();
        if (kb.digit2Key.wasPressedThisFrame || kb.numpad2Key.wasPressedThisFrame)
            LaneRouter.For(2)?.TryHit();
        if (kb.digit3Key.wasPressedThisFrame || kb.numpad3Key.wasPressedThisFrame)
            LaneRouter.For(3)?.TryHit();
        if (kb.digit4Key.wasPressedThisFrame || kb.numpad4Key.wasPressedThisFrame)
            LaneRouter.For(4)?.TryHit();

        bool shift = kb.leftShiftKey.isPressed || kb.rightShiftKey.isPressed;
        if (shift && (kb.digit1Key.wasPressedThisFrame || kb.numpad1Key.wasPressedThisFrame))
            LaneRouter.For(1)?.AddBox();
        if (shift && (kb.digit2Key.wasPressedThisFrame || kb.numpad2Key.wasPressedThisFrame))
            LaneRouter.For(2)?.AddBox();
        if (shift && (kb.digit3Key.wasPressedThisFrame || kb.numpad3Key.wasPressedThisFrame))
            LaneRouter.For(3)?.AddBox();
        if (shift && (kb.digit4Key.wasPressedThisFrame || kb.numpad4Key.wasPressedThisFrame))
            LaneRouter.For(4)?.AddBox();
            
         if (kb.spaceKey.wasPressedThisFrame)
        {
            if (TimeCheck.Instance != null)
                TimeCheck.Instance.TryTimeButton();
        }    
        }
        
        if (kb.escapeKey.wasPressedThisFrame)
        {
           Application.Quit();
        }    
        
    }
}
