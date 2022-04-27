using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBaseRotate : MonoBehaviour
{

    // Variables
    public bool isInPosition;
    public TurretSpawnScript turretSpawner; 

    [SerializeField]
    private float heading = 0.0f;
    private float turnRate = 15.0f;

    private float desiredHeading = 0.0f;
    public Vector3 eulerRotation = Vector3.zero;
    public Vector3 diff = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diff = transform.position - turretSpawner.GetPredictionPosition();
        desiredHeading = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        desiredHeading = Utils.DegreeClamp(desiredHeading);

        if (Utils.Approximation(heading, desiredHeading))
        {
            isInPosition = true;
        }
        else if (Utils.AngleDiffPosNeg(desiredHeading, heading) > 0)
        {
            heading += turnRate * Time.deltaTime;
            isInPosition = false;
        }
        else if (Utils.AngleDiffPosNeg(desiredHeading, heading) < 0)
        {
            heading -= turnRate * Time.deltaTime;
            isInPosition = false;
        }
        heading = Utils.DegreeClamp(heading);

        eulerRotation.y = heading;
        transform.localEulerAngles = eulerRotation;
    }
}
