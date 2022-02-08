using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPosition, targetPosition;
    private float timeToMove = 0.2f;

    private void OnTriggerEnter2D(Collider2D other) {
        targetPosition = originalPosition;
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / (timeToMove/1.2f)));
            elapsedTime += Time.deltaTime;
            yield return null;
        } 

        transform.position = targetPosition;

        isMoving = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));
        if(Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));
        if(Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));
        if(Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
        if(Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("Overworld");
        
    }
}
