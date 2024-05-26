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
    public class Disassembler : MonoBehaviour
    {
        public InputActionProperty resetOnlySelected;
        public InputActionProperty resetAll;
        public Transform HowerObject;

        public void OnHoverEntered(HoverEnterEventArgs args)
        {
            HowerObject = args.interactableObject.transform;
        }
    
        public void OnHoverExited(HoverExitEventArgs args)
        {
            HowerObject = null;
        }
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(resetOnlySelected.action.ReadValue<float>() == 1 && HowerObject!=null  && HowerObject.GetComponent<DisassembleComponent>()){
                HowerObject.GetComponent<DisassembleComponent>().MoveToDeafultPosition();
            }
            if(resetAll.action.ReadValue<float>() == 1 && HowerObject!=null  && HowerObject.GetComponent<DisassembleComponent>()){
                HowerObject.GetComponent<DisassembleComponent>().MoveAllModelToDefaultPosition(false);
            }
        }
    }
}