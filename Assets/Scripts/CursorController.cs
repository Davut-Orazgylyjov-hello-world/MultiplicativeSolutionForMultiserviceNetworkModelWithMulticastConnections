using System;
using UnityEngine;
using UnityEngine.AI;

public class CursorController : MonoBehaviour
{


   public Texture2D cursor;

   public Texture2D cursorClicked;
   
   private CursorControls _cursorControls;

   private Camera _mainCamera;
   

   
   
   private void Awake()
   {
      _cursorControls = new CursorControls();
      ChangeCursor(cursor);
      Cursor.lockState = CursorLockMode.Confined;
      _mainCamera = Camera.main;
   }
   
   private void Start()
   {
      _cursorControls.Mouse.Click.started += _ => StartedClick();
      _cursorControls.Mouse.Click.started += _ => EndedClick();
   }



   private void OnEnable()
   {
      _cursorControls.Enable();
   }

   private void OnDisable()
   {
      _cursorControls.Disable();
   }


   private void StartedClick()
   {
      ChangeCursor(cursorClicked);
   }

   private void EndedClick()
   {
      ChangeCursor(cursor);
      DetectObject();
   }


   private void DetectObject()
   {
      Ray ray = _mainCamera.ScreenPointToRay(_cursorControls.Mouse.Position.ReadValue<Vector2>());
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit))
      {
         if (hit.collider != null)
         {
            if (hit.collider.CompareTag("Connection"))
            {
               hit.collider.GetComponent<Connection>().OpenUIWindow();
               Debug.Log(hit.collider.name);
            }
         }
      }

   }
   
   
   private void ChangeCursor(Texture2D cursorType)
   {
      Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
   }
}
