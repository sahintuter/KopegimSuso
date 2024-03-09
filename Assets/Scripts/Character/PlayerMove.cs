using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý
    public float rotationSpeed = 10f; // Dönme hýzý
    private Rigidbody rb; // Karakterin RigidBody bileþeni
    private Animator animator; // Karakterin Animator bileþeni
    private bool isRunning = false; // Koþma durumu

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // RigidBody bileþenini al
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        Move(); // Hareket fonksiyonunu çaðýr
        UpdateAnimation(); // Animasyonu güncelle
    }

    void Move()
    {
        // Hareket iþlemi
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.TransformDirection(movement); // Hareketi dünya koordinatlarýna göre dönüþtür

        float currentSpeed = speed * (Input.GetKey(KeyCode.LeftShift) ? 2f : 1f); // Koþma tuþuna basýlýysa hýzý arttýr
        rb.velocity = movement.normalized * currentSpeed; // Hareketi normalize edip hýza çarp

        // Hareket varsa koþuyor olarak iþaretle, yoksa koþmuyor olarak iþaretle
        isRunning = movement.magnitude > 0f;

        // Karakterin dönme hýzýný ayarla
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void UpdateAnimation()
    {
        // Animasyonu güncelle
        animator.SetBool("IsRun", isRunning);
    }
}
