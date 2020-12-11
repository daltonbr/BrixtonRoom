using UnityEngine;

public class GazeTriggerByAngle : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform _transform;
    [SerializeField] private Material blendMaterial;
    [SerializeField] private float gazeAngle = 15f;
   // [SerializeField] private LayerMask mask;
    
    private void Update()
    {
        Vector3 forwardDirection = _transform.forward;
        Vector3 directionToTarget = target.transform.position - _transform.position;
        
        // Debug.DrawLine(_transform.position, _transform.forward * 3, Color.green);
        // Debug.DrawLine(_transform.position, _transform.position + directionToTarget, Color.magenta);
        float angle = Vector3.Angle(forwardDirection, directionToTarget);
        //Debug.Log($"Angle:{angle}");
        
        //Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(_transform.forward);
        //Vector3 direction = (_transform.position + _transform.forward) - transform.position;
        
        // if (Physics.SphereCast(_transform.position, SphereCastRadius, direction, out RaycastHit hit, CastMaxDistance, mask))
        // {
        //     if (hit.collider.name == "GazeTarget")
        //     {
        //         Debug.Log($"SphereCast {hit.collider.name}");
        //         blendMaterial.color = Color.green;
        //         return;    
        //     }
        // }

        if (angle < gazeAngle)
        {
            blendMaterial.color = Color.green;
            return;
        }
        blendMaterial.color = Color.red;    
    }
    
    private void OnDrawGizmos()
    {
        // Gizmos.DrawWireSphere(_transform.position, 0.1f);
        // Gizmos.DrawWireSphere(_transform.position + _transform.forward, 0.1f);
        // Debug.DrawLine(_transform.position, _transform.forward * 3, Color.green);
        // Debug.DrawLine(_transform.position, target.transform.position, Color.magenta);
    }
}
