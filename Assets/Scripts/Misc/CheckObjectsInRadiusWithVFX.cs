using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectsInRadiusWithVFX : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject objectsCheckerLink;
    [SerializeField] GameObject vfxWithCurve;

    [Header("Parameters")]
    [SerializeField] float triggerRadius = 1f;
    
    public List<GameObject> getObjectsInRadius(int maxCheckedObjects, int checkedObjectsCount, GameObject excludedObject)
    {
        Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, triggerRadius);

        if (overlappingColliders.Length > 0)
        {
            List<GameObject> returnedObjects = new List<GameObject>();

            foreach (Collider collider in overlappingColliders){
                GameObject checkingObject = collider.gameObject;

                if (checkingObject != excludedObject)
                {
                    GameObject newVfx = Instantiate(vfxWithCurve, Vector3.zero, Quaternion.identity);

                    VFXCurveManager vfxCurveScript = newVfx.GetComponent<VFXCurveManager>();

                    Vector3 centerPoint = transform.position + (checkingObject.transform.position - transform.position) / 2;

                    newVfx.transform.position = centerPoint;

                    vfxCurveScript.SetCurvePoints(transform.position, centerPoint, centerPoint, checkingObject.transform.position);
                    vfxCurveScript.StartTimerToDestroy();

                    returnedObjects.Add(checkingObject);
                }
            }

            Destroy(gameObject);

            return returnedObjects;
        }
        else
        {
            Destroy(gameObject);

            return null;
        }
    }
}
