using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_TestPlayer : MonoBehaviour
{

    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    float jumpForce = 880.0f;     // 점프에 전달할 힘 값
    float walkForce = 80.0f;      // 이동에 전달할 힘 값
    float maxSpeed = 10.0f;        // 캐릭터 최대 이동속도
    float currentSpeed = 0.0f;    // 캐릭터의 속도 절대 값을 담을 변수

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.acceleration.x < -10f)
        {
            if (currentSpeed < maxSpeed)
            // 강체의 x 축 이동속도가 maxSpeed 보다 작을 때만 이동
            {
                rigidBody.AddForce(transform.right * -1 * walkForce);
            }

            // 스케일 값을 -로 적용하면 이미지가 -값의 축방향으로 반전된다
        }

        if (Input.GetKey(KeyCode.D) || Input.acceleration.x > 10f)
        {
            if (currentSpeed < maxSpeed)
            // 강체의 x 축 이동속도가 maxSpeed 보다 작을 때만 이동
            {
                rigidBody.AddForce(transform.right * 1 * walkForce);
            }

        }
        Vector3 sample = new Vector3(3, 4, 0);
        // 앞 대각선으로 방향

        // 마우스 버튼을 클릭하면 점프
        if (Input.GetKeyDown(KeyCode.Space))
        // 강체는 속도값을 관리하고 있음
        // 그것이 velocity
        // 점프 중이거나 추락 중에는 y축의 속도값이 0이 아닌 값이 발생
        // 상승 중에는 + 속도값, 추락 중에는 - 속도값이 나옴
        // y값이 0이면 착지하고 있다는 뜻
        {
            rigidBody.AddForce(transform.up * jumpForce);
            // AddForce (벡터의 크기)는 Rigidbody에 힘을 가하는 함수
            // transform.up 트랜스폼 벡터값의 방향이 위고, 크기는 1인 벡터
            // transform.up == (0, 1, 0)
        }

        currentSpeed = Mathf.Abs(rigidBody.velocity.x);
        // rigidBody의 x축 속도값을 절대값으로 변환
        // Mathf.Abs(값) 절대값을 반환해주는 함수


    }
}