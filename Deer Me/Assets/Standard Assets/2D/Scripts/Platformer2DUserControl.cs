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
        public AudioClip jump; //0 = grass, 1 = wood, 2 = metal
        public AudioClip[] walk_grass;
        public AudioClip[] walk_metal;
        public AudioClip[] walk_wood;
        public AudioClip[] walk_stone;
        public float timer;
        public float rate;

        public float pushRate;

        public int layer;

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
                        if (!GetComponent<Animator>().GetBool("Pushing"))
                        {
                            timer = Time.time + 1 / rate;
                        }
                        else
                        {
                            timer = Time.time + 1 / pushRate;
                        }
                        if (layer == 0)
                        {
                            GrassFootstepRandomize();
                        }
                        else if (layer == 8 || layer == 19)
                        {
                            WoodFootstepRandomize();
                        }
                        else if (layer == 18)
                        {
                            MetalFootstepRandomize();
                        }
                        else if (layer == 20)
                        {
                            StoneFootstepRandomize();
                        }
                    }
                }
            }

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

		public void Jump()
		{
			source.PlayOneShot(jump);
		}

        void GrassFootstepRandomize()
        {
            AudioClip soundToPlay = walk_grass[UnityEngine.Random.Range(0, walk_grass.Length)];
            source.PlayOneShot(soundToPlay);
        }

        void WoodFootstepRandomize()
        {
            AudioClip soundToPlay = walk_wood[UnityEngine.Random.Range(0, walk_wood.Length)];
            source.PlayOneShot(soundToPlay);
        }

        void MetalFootstepRandomize()
        {
            AudioClip soundToPlay = walk_metal[UnityEngine.Random.Range(0, walk_metal.Length)];
            source.PlayOneShot(soundToPlay);
        }
        void StoneFootstepRandomize()
        {
            AudioClip soundToPlay = walk_stone[UnityEngine.Random.Range(0, walk_stone.Length)];
            source.PlayOneShot(soundToPlay);
        }
    }
}
