using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        public bool m_FacingRight = true;  // For determining which way the player is currently facing.
        public bool climbing;
        private float gravity;
        public float climbSpeed;
        public float climbVelocity;
		public bool isDead;
		public bool isDrowning;
		public RawImage fadeScreen;
		public Canvas deathScreen;
		private Color tempColor;

        public bool swinging = false;
        public bool canswing = true;
		public GameObject onRope;
		public Sprite onRopeSprite;
		public Sprite idleSprite;
        public Transform startPosition;
     
        public bool hasTorch;
        public GameObject torchHandle;
        public GameObject torchFlame;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            gravity = m_Rigidbody2D.gravityScale;
			isDead = false;
			tempColor = Color.black;
			tempColor.a = 0f;

			if (PlayerPrefs.GetString ("Level_Checkpoint") != null && PlayerPrefs.GetString ("Level_Checkpoint") != "") 
			{
                Debug.Log("HERE");
				GameObject cp = GameObject.Find (PlayerPrefs.GetString ("Level_Checkpoint"));
				this.gameObject.transform.position = cp.transform.position;
			}
                
        }
            
        public void Update()
        {

			if (!isDead && !isDrowning) 
			{
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Throwing") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("PickingUp"))
                {
                    
                    if (!swinging)
                    {
                    
                        if (m_Grounded && Input.GetKeyDown(KeyCode.Space) && m_Anim.GetBool("Ground"))
                        {
                            // Add a vertical force to the player.
                            m_Grounded = false;
                            m_Anim.SetBool("Ground", false);
                            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                        }
                        if (!m_Grounded && Input.GetKeyUp(KeyCode.Space))
                        {
                            m_Rigidbody2D.AddForce(new Vector2(0f, -m_JumpForce * 0.25f));
                        }

                        if (climbing)
                        {
                            m_Rigidbody2D.gravityScale = 0;
                            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                            m_Anim.SetFloat("ClimbSpeed", Mathf.Abs(climbVelocity));
                            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, climbVelocity);
                        }
                        if (!climbing)
                        {
                            m_Anim.SetFloat("ClimbSpeed", 0);
                            m_Rigidbody2D.gravityScale = gravity;
                        }
                    }
                    else if (swinging)
                    {
                        m_Anim.enabled = false;
                        GetComponent<SpriteRenderer>().sprite = onRopeSprite;

                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            m_Anim.enabled = true;
                            swinging = false;
                            onRope.GetComponent<Rope>().letGo = true;
                            Destroy(this.gameObject.GetComponent<HingeJoint2D>());
                            m_Rigidbody2D.AddForce(new Vector2(m_JumpForce, m_JumpForce));
                            StartCoroutine(DelayedSwing());
                        }
                    }
                }
			} 

			else if (isDead) 
            {
                HideTorch(false);
				
				if (m_Anim.GetCurrentAnimatorStateInfo (0).IsName ("DEAD"))
				{
					m_Anim.SetBool ("DEAD", true);
					if (fadeScreen.color.a < 0.8f) 
					{
						tempColor.a += Time.deltaTime;
						fadeScreen.color = tempColor;
					} 

					else 
					{
						deathScreen.gameObject.SetActive (true);
					}
				}
			} 

			else if (isDrowning) 
			{
                HideTorch(false);

				if (fadeScreen.color.a < 0.8f) 
				{
					tempColor.a += Time.deltaTime;
					fadeScreen.color = tempColor;
				} 
				else 
				{
					deathScreen.gameObject.SetActive (true);
				}
			}

         
        }

        public void HideTorch(bool t)
        {
            if (hasTorch)
            {
                torchFlame.SetActive(t);
                torchHandle.SetActive(t);
            }
        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

        }


        public void Move(float move, bool crouch, bool jump)
        {
			if (!isDead &&  !isDrowning) 
			{
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Throwing") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("PickingUp"))
                {
                    // If crouching, check to see if the character can stand up
                    if (!crouch && m_Anim.GetBool("Crouch"))
                    {
                        // If the character has a ceiling preventing them from standing up, keep them crouching
                        if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                        {
                            crouch = true;
                        }
                    }

                    // Set whether or not the character is crouching in the animator
                    m_Anim.SetBool("Crouch", crouch);

                    //only control the player if grounded or airControl is turned on
                    if (m_Grounded || m_AirControl)
                    {
                        // Reduce the speed if crouching by the crouchSpeed multiplier
                        move = (crouch ? move * m_CrouchSpeed : move);

                        // The Speed animator parameter is set to the absolute value of the horizontal input.
                        m_Anim.SetFloat("Speed", Mathf.Abs(move));

                        // Move the character
                        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);


                        // If the input is moving the player right and the player is facing left...
                        if (move > 0 && !m_FacingRight)
                        {
                            // ... flip the player.
                            Flip();
                        }
                    // Otherwise if the input is moving the player left and the player is facing right...
                    else if (move < 0 && m_FacingRight)
                    {
                            // ... flip the player.
                            Flip();
                        }
                    }
                }
                else
                {
                    m_Rigidbody2D.velocity = Vector2.zero;
                }
			} 
			else 
			{
				m_Rigidbody2D.velocity = Vector2.zero;
				if (!m_Anim.GetBool ("isDying")) 
				{
					m_Anim.SetBool ("isDying", true);
				}
			}
        }


        private void Flip()
        {
			if (!swinging) 
			{
				// Switch the way the player is labelled as facing.
				m_FacingRight = !m_FacingRight;

				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Rope" && canswing)
            {
                canswing = false;
                swinging = true;
				onRope = col.gameObject.transform.parent.gameObject;
                HingeJoint2D hinge = this.gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
                hinge.connectedBody = col.gameObject.GetComponent<Rigidbody2D>();
            }
        }
        IEnumerator DelayedSwing()
        {
            yield return new WaitForSeconds(0.5f);
            canswing = true;
			onRope.GetComponent<Rope> ().letGo = false;
			onRope = null;
        }
    }
    
}
