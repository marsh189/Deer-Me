using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private AudioSource source;
        public AudioClip jump;
        public AudioClip[] walk;
        public float timer;
        public float rate;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            source = GetComponent<AudioSource>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            if (h != 0 && GetComponent<Animator>().GetBool("Ground"))
            {
                if (Time.time > timer)
                {
                    if (!m_Character.isDead && !m_Character.isDrowning)
                    {
                        Debug.Log("HERE");
                        timer = Time.time + 1 / rate;
                        FootstepRandomize();
                    }
                }
            }
            else if(m_Jump)
            {
                Debug.Log("HERE!!!");
                source.PlayOneShot(jump);
            }
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

        void FootstepRandomize()
        {
            AudioClip soundToPlay = walk[UnityEngine.Random.Range(0, walk.Length)];
            source.PlayOneShot(soundToPlay);
        }
    }
}
