using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	GameObject lifeRoom, player;
	
	const int MAX_HEALTH = 99;
	const int MIN_HEALTH = 20;
	
	public GameObject blood, respawnPoint, LifeWall;
	
	LifeWall _lifeWall;
	
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
		
		//guiText.text = healthPoints.ToString();
		
		//normalTextSize = guiText.fontSize;
		
		normalColor = RenderSettings.ambientLight;
		
		lifeRoom = GameObject.Find("LifeRoom");
		player = GameObject.Find ("RigidbodyController");
		
		_lifeWall = LifeWall.GetComponent<LifeWall>();
	
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
	}
	
	public void decreaseLife(){
		
		if(healthPoints > 0){
			
			_lifeWall.decreaseLifeWall();
			
			if(healthPoints - 10 > 0)
				healthPoints -= 10;
			else
				healthPoints = 0;
			
			//guiText.text = healthPoints.ToString();
			//guiText.fontSize = increasedTextSize;
					
			RenderSettings.ambientLight = Color.red;
			
			blood.guiTexture.enabled = true;
			
			if(healthPoints <= 0){
				
				player.transform.position = new Vector3( respawnPoint.transform.position.x, 
					respawnPoint.transform.position.y, respawnPoint.transform.position.z);
				
				healthPoints = MAX_HEALTH;
				
				_lifeWall.restoreSize();
				
				//guiText.text = healthPoints.ToString();
				restoreNormalView();
				//lifeRoom.GetComponent<HiddenDoor>().hideDoor();
				
			}else if(healthPoints < MIN_HEALTH){
				
				_lifeWall.changeColorWall(Color.red);
				TimeOut = 15f;
				//lifeRoom.GetComponent<HiddenDoor>().showHiddenDoor();
				
			}else{
				damageOn = true;
			}
		}
	}
	
	public void increaseLife(){
		healthPoints += 5;
		
		//guiText.text = healthPoints.ToString();
		
		_lifeWall.increaseLifeWall();
		
		if(healthPoints > MIN_HEALTH && RenderSettings.ambientLight != normalColor){
			restoreNormalView();
			_lifeWall.changeColorWall(Color.green);
			//lifeRoom.GetComponent<HiddenDoor>().hideDoor();
		}
	}
	
	private void restoreNormalView(){
		RenderSettings.ambientLight = normalColor;
		blood.guiTexture.enabled = false;
		damageOn = false;
		_lifeWall.changeColorWall(Color.green);
		//guiText.fontSize = normalTextSize;
	}
}