using UnityEngine;

// https://www.youtube.com/watch?v=uMUTy7Y14ug 


public class LightMotion : MonoBehaviour{
    [SerializeField] Vector2 m_cycleDurationXZ = new Vector2(20f, 20f);
    [SerializeField] AnimationCurve m_movementPathX;
    [SerializeField] AnimationCurve m_movementPathZ;
    [SerializeField] Vector2 m_movementMagnitudeXZ = new Vector2(1,1);
    [SerializeField] Vector2 m_movementTimeOffsetXZ = new Vector2();

    private Vector3 m_initialPosition;

    private void Awake(){
        m_initialPosition = transform.position;
    }

    void Update(){
        UpdateMotion();
    }

    // moves light cookie along curves
    private void UpdateMotion(){
        float timeX = Time.time % m_cycleDurationXZ.x;
        timeX /= m_cycleDurationXZ.x;

        float timeZ = Time.time % m_cycleDurationXZ.y;
        timeZ /= m_cycleDurationXZ.y;

        float newX = m_movementPathX.Evaluate(timeX + m_movementTimeOffsetXZ.x) * m_movementMagnitudeXZ.x;
        float newZ = m_movementPathZ.Evaluate(timeZ + m_movementTimeOffsetXZ.y) * m_movementMagnitudeXZ.y;

        transform.position = m_initialPosition + new Vector3(newX, 0, newZ);
    }


}
