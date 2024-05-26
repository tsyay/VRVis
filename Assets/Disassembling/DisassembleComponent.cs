using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine.Serialization;

namespace UnityEngine.XR.Interaction.Toolkit{
    public class DisassembleComponent : MonoBehaviour
    {
        public Vector3 LocalPosition;
        public Quaternion LocalRotation;

        public void MoveToDeafultPosition()
        {
            StartCoroutine(moveComponent(LocalPosition + transform.parent.position));
            transform.localRotation = LocalRotation;
        }

        public virtual void MoveAllModelToDefaultPosition(bool FromParent)
        {
            if(FromParent){
                MoveToDeafultPosition();
                Transform parent =transform;
                foreach (Transform child in parent)
                {
                    child.GetComponent<DisassembleComponent>().MoveAllModelToDefaultPosition(true);
                }
            }
            else{
                transform.parent.gameObject.GetComponent<DisassembleComponent>().MoveAllModelToDefaultPosition(false);
            }
        }

        public IEnumerator moveComponent(Vector3 Destination) {
            Vector3 Origin = transform.position;
            float totalMovementTime = 1f;
            float currentMovementTime = 0f;
            while (Vector3.Distance(transform.position, Destination) > 0) {
                currentMovementTime += Time.deltaTime;
                transform.position = Vector3.Lerp(Origin, Destination, currentMovementTime / totalMovementTime);
                yield return null;
            }
    }

        void Start()
        {
            LocalPosition = transform.localPosition;
            LocalRotation = transform.localRotation;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
