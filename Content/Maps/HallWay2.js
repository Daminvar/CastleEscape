
name("HallWay 2")
mapfile("HallWay2.tmx")
overworldMusic("hallway-song")
randomBattleMusic("regular-battle-song")
battleTexture("hallway-bg")

north("CourtYard1.js")
west("HallWay1.js")
east("HallWay3.js")
south("bedroom1.js")

var courtyardGuard1 = newNPE()
courtyardGuard1.SetTexture("bGuard-front")

courtyardGuard1.SetPosition(4,5)

courtyardGuard1.SetInteractFunc(function(player){
	if(getFlag("defeated-librarian-and-got-pendant"))
	{
		dialogue("Guard Allan: Just get out of my sight.")
	}
	else
	{
		dialogue("Guard Allan: Get away, the courtyard is off-limits! |Jordan: I just need to pass by real quick, I promise I won't cause any problems. |Guard Allan: GO AWAY!")
	}
})
addNPE(courtyardGuard1)

var courtyardGuard2 = newNPE()
courtyardGuard2.SetTexture("guard1_front")

if(getFlag("courtyard-and-chapel-open"))
{ 
	courtyardGuard2.SetPosition(6,6)
}
else
{
	courtyardGuard2.SetPosition(5,5)
}

courtyardGuard2.SetInteractFunc(function(player) 
{
	if(getFlag("defeated-librarian-and-got-pendant"))
	{
		dialogue("Guard Mark: That's some pendant you have there, sir. You may pass into the courtyard.")		
		setFlag("courtyard-and-chapel-open")
		reloadMap()

	}	
	else
	{
		dialogue("Jordan: Can I please get by to the courtyard? It's of utmost importance.|Guard Mark: Sorry, it's against the rules to let just anyone have access to the courtyard.|Jordan: Is there any way you might let me through?|Guard Mark: Past this point is royalty only, and right now I don't see anything royal about you.")
		//Some sort of test/check to see if they have the neccessary item
			}
})

addNPE(courtyardGuard2)


var bedroomGuard = newNPE()
bedroomGuard.SetTexture("girl_left")

if(getFlag("bedroom-open"))
{ 
	bedroomGuard.SetPosition(7,10)
	bedroomGuard.SetTexture("girl_front")
}
else
{
	bedroomGuard.SetPosition(8,11)
}

bedroomGuard.SetInteractFunc(function(player) 
{
	if(getFlag("go-to-bedroom"))
	{
		dialogue("Lady Mary: Oh you have food for the family? Well, I can't very well deny them food... Go ahead.")
		
		setFlag("bedroom-open")
		reloadMap()
	}	
	else
	{
		dialogue("Lady Mary: I'm sorry, but at this time no one may enter the bedrooms. The maid hasn't arrived yet. Unless you have food or something for the family quarters, you can't pass.")
	}
})


addNPE(bedroomGuard)


var guardF = newEnemy("soldier3_battle", "Castle Guard", 90, 45, 2, 2, 20, null)
var ghost = newEnemy("ghost1_battle", "Ghost", 100, 50, 2, 3, 22, null)

addRandomEncounter(guardF)
addRandomEncounter(ghost)