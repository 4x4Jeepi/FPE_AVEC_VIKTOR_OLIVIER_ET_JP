using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class Aura : MonoBehaviour {

    public bool m_IsActive = false;

    [SerializeField]
    private GameObject m_Aura;
    [SerializeField]
    private float m_ActiveTime = 5.0f;
    [SerializeField]
    private float m_ActiveTimeLeft = 0.0f;
    [SerializeField]
    private float m_CoolDownTime = 10.0f;
    [SerializeField]
    private float m_CoolDownTimeLeft = 0.0f;
    [SerializeField]
    private bool m_IsOnCooldown = false;
    [SerializeField]
    private bool m_isPlayerOne = true;

    private void Start() {
        
    }

    private void Update() {

        // Player 1 Input

        if (Input.GetKey(KeyCode.Space) && !m_IsOnCooldown) {

            SoundManagerFPE.m_Instance.PlayASound(0);

            m_IsActive = true;
            m_Aura.SetActive(true);
            m_ActiveTimeLeft = m_ActiveTime;
        }

        if (m_IsActive) {

            m_ActiveTimeLeft -= Time.deltaTime;

            if (m_ActiveTimeLeft <= 0.0f) {

                SoundManagerFPE.m_Instance.PlayASound(1);

                m_IsOnCooldown = true;
                m_CoolDownTimeLeft = m_CoolDownTime;

                m_IsActive = false;
                m_Aura.SetActive(false);
                m_ActiveTimeLeft = 0.0f;
            }
        }

        if (m_IsOnCooldown) {

            m_CoolDownTimeLeft -= Time.deltaTime;

            if(m_CoolDownTimeLeft <= 0.0f) {

                m_IsOnCooldown = false;
                m_CoolDownTimeLeft = 0.0f;
            }
        }
    }
}
