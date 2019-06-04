using Live2D.Cubism.Framework.LookAt;
using UnityEngine;

public class CubismLookTarget : MonoBehaviour, ICubismLookTarget
{
    public Vector3 GetPosition()
    {
        var targetPosition = Input.mousePosition;

        targetPosition = (Camera.main.ScreenToViewportPoint(targetPosition) * 2) - new Vector3(1.8f,2.7f,-1);

        return targetPosition;
    }


    public bool IsActive()
    {
        return true;
    }

}
