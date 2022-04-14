using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CursorController : MonoBehaviour
{
   public static CursorController cursorController;
   private IEnumerator coroutineDelayRemoveUIWindow;


   public Texture2D cursor;
   public Texture2D cursorClicked;
   private CursorControls _cursorControls;
   private Camera _mainCamera;



   private void Awake()
   {
      cursorController = this;
      _cursorControls = new CursorControls();
      ChangeCursor(cursor);
      Cursor.lockState = CursorLockMode.Confined;
      _mainCamera = Camera.main;
   }

   private void Start()
   {
      _cursorControls.Mouse.Click.started += _ => StartedClick();
      _cursorControls.Mouse.Click.performed += _ => EndedClick();
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
               ObjectConnection(hit.collider.GetComponent<Connection>());
            
         }
      }
   }

   private void ObjectConnection(Connection connection)
   {
      if (NetworkManager.networkManager.noCreateUIMenu == false)
      {
         connection.OpenUIWindow();

         NewDelayRemoveUIWindow();
      }
      else if (NetworkManager.networkManager.connectionUsing != connection)
      {
         ActivateCommandConnection(connection);
      }
   }

   private void ActivateCommandConnection(Connection connection)
   {
      if (NetworkManager.networkManager.stateNetworkConnection != ConnectionState.Nothing)
      {
         switch (NetworkManager.networkManager.stateNetworkConnection)
         {
            case ConnectionState.Create:
               NetworkManager.networkManager.connectionUsing.AddConnection(connection);
               break;

            case ConnectionState.Remove:
               NetworkManager.networkManager.connectionUsing.RemoveConnection(connection);
               break;
         }
      }
   }

   private void NewDelayRemoveUIWindow()
   {
      StopCoroutineDelayRemoveUIWindow();

      coroutineDelayRemoveUIWindow = DelayRemoveUIWindow();

      StartCoroutine(coroutineDelayRemoveUIWindow);
   }

   private IEnumerator DelayRemoveUIWindow()
   {
      yield return new WaitForSeconds(3f);

      NetworkManager.networkManager.RemoveUIWindowConnection();
      Debug.Log("@@@@@@@@@@");
   }

   public void StopCoroutineDelayRemoveUIWindow()
   {
      if (coroutineDelayRemoveUIWindow != null)
         StopCoroutine(coroutineDelayRemoveUIWindow);
   }



   private void ChangeCursor(Texture2D cursorType)
   {
      Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
   }
}
