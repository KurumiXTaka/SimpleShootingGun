using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;
    
    public float topClamp = -90f;
    public float bottomClamp = 90f;
    
    void Start()
    {
      //Mengunci kursor di tengah layar dan membuatnya tidak terlihat
      Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
      //Mendapatkan input mouse
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 

      // Rotasi pada sumbu x (Lihat ke atas dan ke bawah)
      xRotation -= mouseY; 

      // Jepit Rotasi
      xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

      // Rotasi pada sumbu y (Lihat kiri dan kanan)
      yRotation += mouseX;

      //// Terapkan rotasi pada transformasi kita
      transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
