using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine.Serialization;
namespace UnityEngine.XR.Interaction.Toolkit{
    public class Disassemblable : DisassembleComponent
    {
        public List<GameObject> allObjects;

        public  override void MoveAllModelToDefaultPosition(bool FromParent)
        {
            Transform parent = transform;
            foreach (Transform child in parent)
            {
                child.GetComponent<DisassembleComponent>().MoveAllModelToDefaultPosition(true);
            }
        }

        private void AddDescendants(Transform parent, List<GameObject> list)
        {
            foreach (Transform child in parent)
            {
                list.Add(child.gameObject);
                InitComponent(child.gameObject);
                AddDescendants(child, list);
            }
        }

        private void InitComponent(GameObject component)
        {
            component.AddComponent<DisassembleComponent>();
            component.AddComponent<XRGrabInteractable>();
            component.GetComponent<Rigidbody>().useGravity = false;
            component.GetComponent<Rigidbody>().isKinematic = true;
        }
    
        void Start()
        {
            AddDescendants(transform, allObjects);
        }

        void Update()
        {
            
        }
    }
}
