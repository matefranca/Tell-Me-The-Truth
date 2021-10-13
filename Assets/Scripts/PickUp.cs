using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Energy
{
    public class PickUp : MonoBehaviour
    {
        [Header("PickUpPosition")]
        [SerializeField]
        private Transform pickUpParent;

        [Header("PickUp Distance.")]
        [SerializeField]
        private float pickUpDistance = 50f;

        private Interactable activeInteractable;
        private Choice activeChoice;

        void Update()
        {
            PlayerInput();
            CheckForChoice();

            // Activating the helper.
            UIManager.GetInstance().SetHelperText(activeInteractable);
        }

        // Checking for Player Input.
        private void PlayerInput()
        {
            if (Input.GetMouseButtonDown(0) && activeInteractable == null)
            {
                if (activeChoice)
                {
                    SelectionManager.GetInstance().SelectChoice(activeChoice.index);
                    activeChoice.Unchoose();
                    activeChoice = null;
                }

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpDistance))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable)
                    {
                        Debug.Log("Clicked");
                        if (activeInteractable)
                        {
                            activeInteractable.Deselect();
                        }

                        activeInteractable = interactable;
                        activeInteractable.Select(pickUpParent);
                    }
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                if (activeInteractable)
                {
                    activeInteractable.Deselect();
                    activeInteractable = null;
                }
            }

            
            // Object Rotation.
            if (Input.GetKey(KeyCode.Q) && activeInteractable)
            {
                activeInteractable.transform.Rotate(Vector3.up * 150f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E) && activeInteractable)
            {
                activeInteractable.transform.Rotate(Vector3.up * - 150f * Time.deltaTime);
            }
        }

        // Function for animating the choices.
        private void CheckForChoice()
        {
            if (!SelectionManager.GetInstance().CanSelect && activeInteractable != null)
                return;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpDistance))
            {
                Choice choice = hit.collider.GetComponent<Choice>();
                if (choice && activeInteractable == null)
                {
                    if (activeChoice)
                    {
                        activeChoice.Unchoose();
                    }

                    UIManager.GetInstance().SetInteractionText(true);
                    activeChoice = choice;
                    activeChoice.Choose();
                }
                else
                {
                    UIManager.GetInstance().SetInteractionText(false);

                    if (activeChoice && activeInteractable == null)
                    {
                        activeChoice.Unchoose();
                        activeChoice = null;
                    }
                }
            }
        }
    }
}