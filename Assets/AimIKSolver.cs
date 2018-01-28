using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimIKSolver : MonoBehaviour {
    public Transform target;
    public float damping;

    public Transform bodyTransform;
    public Transform leftWeaponTransform;
    public Transform rightWeaponTransform;

    private void Update ()
    {
        var lookPos = target.position;
        lookPos.y = 0f;

        bodyTransform.LookAt(lookPos);
      // bodyTransform.rotation = Quaternion.LookRotation(bodyTransform.position + lookPos, Vector3.up);
        bodyTransform.Rotate(0f, 90f, 270f);

        //lookPos = target.position;

        //lookPos.x = leftWeaponTransform.position.x;
        //lookPos.z = (leftWeaponTransform.position + leftWeaponTransform.forward) .z;

        //leftWeaponTransform.rotation = Quaternion.LookRotation(leftWeaponTransform.position + lookPos, Vector3.up);
        //leftWeaponTransform.Rotate(0f, 90f, 0f);

        //lookPos = target.position;

        //lookPos.x = rightWeaponTransform.position.x;
        //lookPos.z = (rightWeaponTransform.position + rightWeaponTransform.forward).z;

        //rightWeaponTransform.rotation = Quaternion.LookRotation(rightWeaponTransform.position + lookPos, Vector3.down);
        //rightWeaponTransform.Rotate(0f, 90f, 0f);

    }
}
