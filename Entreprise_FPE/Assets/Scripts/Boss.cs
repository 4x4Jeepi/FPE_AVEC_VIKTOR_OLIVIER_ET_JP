using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class Boss : MonoBehaviour {

    public float m_Hp = 100f;
    [SerializeField]
    private float m_Speed = 5.0f;

    Vector3 m_currentPos = new Vector3();
    [SerializeField]
    Vector3 m_BattleStartPos = new Vector3();

    [SerializeField]
    Vector3 m_TargetPositionRight = new Vector3();
    [SerializeField]
    Vector3 m_TargetPositionLeft = new Vector3();

    private bool m_IsBattleStarted;
    private bool m_IsMoveOnCooldown = false;

    private bool m_LastMoveWasRight = false;
    

    private void Start() {

        m_currentPos = transform.position;
        //SoundManagerFPE.m_Instance.PlayMusic(1);
    }

    private void Update() {

        if (!m_IsBattleStarted) {

            if (transform.position != m_BattleStartPos) {

                transform.position = Vector3.Lerp(transform.position, m_BattleStartPos, 0.2f * Time.deltaTime);

                if (Vector3.Distance(transform.position, m_BattleStartPos) < 0.7f) {

                    m_IsBattleStarted = true;
                    
                }
            }
        }

        if (m_IsBattleStarted) {

            Debug.Log("Battle Started");

            if (!m_IsMoveOnCooldown) {
                m_IsMoveOnCooldown = true;
                StartCoroutine(MovePattern());
            }
        }
    }

    private IEnumerator MovePattern() {

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (!m_LastMoveWasRight) {

            m_LastMoveWasRight = true;

            while (transform.position != m_TargetPositionRight) {

                transform.position = Vector3.MoveTowards(transform.position, m_TargetPositionRight, m_Speed * Time.deltaTime);
                yield return null;
            }
            m_IsMoveOnCooldown = false;
        }
        else {

            m_LastMoveWasRight = false;
            while (transform.position != m_TargetPositionLeft) {

                transform.position = Vector3.MoveTowards(transform.position, m_TargetPositionLeft, m_Speed * Time.deltaTime);
                yield return null;
            }
            m_IsMoveOnCooldown = false;
        }

    }
}
