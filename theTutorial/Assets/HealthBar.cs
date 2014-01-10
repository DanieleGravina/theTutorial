using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	GameObject lifeRoom, player;
	
	const int MAX_HEALTH = 99;
	
	public GameObject blood, respawnPoint;
	
	public float TimeOut = 5.0f;
	public float TimeOutDamage = 0.1f;
	public int normalTextSize = 100;
	public int increasedTextSize = 120;
	
	bool damageOn = false;
	//bool animationText = false;
	
	private int healthPoints = MAX_HEALTH;
	
	float Timer = 0f;
	
	float TimerDamage = 0f;
	
	//float animTimer = 0f;
	
	Color normalColor;
	
	// Use this for initialization
	void Start () {
		
		guiText.text = healthPoints.ToString();
		
		normalTextSize = guiText.fontSize;
		
		normalColor = RenderSettings.ambientLight;
		
		lifeRoom = GameObject.Find("LifeRoom");
		player = GameObject.Find ("RigidbodyController");
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if((float)healthPoints/MAX_HEALTH <= 0.9){
			Timer += Time.deltaTime;
			
			if(Timer >= TimeOut){
				increaseLife();
				Timer = 0;
			}
		}
		
		if(damageOn){
			TimerDamage += Time.deltaTime;
			
			if(TimerDamage >= TimeOutDamage){
				TimerDamage = 0;
				restoreNormalView();
			}
		}
		
		/*if(animationText){
			animTimer += Time.deltaTime*speedAnim;
			guiText.fontSize = Mathf.CeilToInt(Mathf.Lerp(normalTextSize, 
				normalTextSize + textAnimation, animTimer));
			
			if(guiText.fontSize >= normalTextSize + textAnimation)
				animationText = false;
			
		}*/
	}
	
	public void decreaseLife(){
		
		if(healthPoints > 0){
			
			if(healthPoints - 10 > 0)
				healthPoints -= 10;
			else
				healthPoints = 0;
			
			guiText.text = healthPoints.ToString();
			guiText.fontSize = increasedTextSize;
					
			RenderSettings.ambientLight = Color.red;
			
			blood.guiTexture.enabled = true;
			
			if(healthPoints <= 0){
				
				player.transform.position = new Vector3( respawnPoint.transform.position.x, 
					respawnPoint.transform.position.y, respawnPoint.transform.position.z);
				
				healthPoints = MAX_HEALTH;
				guiText.text = healthPoints.ToString();
				restoreNormalView();
				lifeRoom.GetComponent<HiddenDoor>().hideDoor();
				
			}else if(healthPoints < 10){
				
				lifeRoom.GetComponent<HiddenDoor>().showHiddenDoor();
				
			}else{
				damageOn = true;
			}
		}
	}
	
	public void increaseLife(){
		healthPoints += 5;
		
		guiText.text = healthPoints.ToString();
		
		if(healthPoints > 10 && RenderSettings.ambientLight != normalColor){
			restoreNormalView();
			lifeRoom.GetComponent<HiddenDoor>().hideDoor();
		}
	}
	
	private void restoreNormalView(){
		RenderSettings.ambientLight = normalColor;
		blood.guiTexture.enabled = false;
		damageOn = false;
		guiText.fontSize = normalTextSize;
	}
}
