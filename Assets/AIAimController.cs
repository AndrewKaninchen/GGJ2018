using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAimController : MonoBehaviour {

    public Transform bodyTransform;

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        var target = GameManager.currentPlayerControlledBot.transform;
        if (target)
        {
            var lookPos = target.position;
            //lookPos.y = bodyTransform.position.y;

            bodyTransform.LookAt(lookPos);
            bodyTransform.Rotate(0f, 90f, 270f);
        }
    }
}
