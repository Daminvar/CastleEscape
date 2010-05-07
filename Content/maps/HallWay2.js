
name("HallWay 2")
mapfile("HallWay2.tmx")
battleTexture("hallway-bg")

north("CourtYard1.js")
west("HallWay1.js")
east("HallWay3.js")
south("bedroom1.js")

var courtyardGuard1 = newNPE()
courtyardGuard1.SetTexture("bGuard-front")

courtyardGuard1.SetPosition(4,5)

courtyardGuard1.SetInteractFunc(function(player){
	dialogue("Guard Allan: Get away, the courtyard is off-limits! | Jordan: I just need to pass by real quick, i won't cause any problems. | Guard Allan: GO AWAY!")
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
		dialogue("Guard Mark: That's some pendant you have there. You may pass into the courtyard")		
		setFlag("courtyard-and-chapel-open")
		reloadMap()

	}	
	else
	{
		dialogue("Jordan: Can i please get by to the courtyard, it's of utmost importance. | Guard Mark: Sorry, it's against the rules to let just anyone have access to the courtyard or further. | Jordan: Is there any way you might let me go?| Guard Mark: Past this point is royalty only, and right now i don't see anything royal about you.")
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
		dialogue("Lady Mary: Oh you bought food for the family? Well i can't deny them food.. Go ahead")
		
		setFlag("bedroom-open")
		reloadMap()
	}	
	else
	{
		dialogue("Lady Mary: I'm sorry but at this time no one may enter the bedrooms, the maid hasnt arrived yet. | Lady Mary: Unless you have food or something for the family quarters, you can't pass ")
	}
})


addNPE(bedroomGuard)


var guardF = newEnemy("guard2_left", "Castle Guard", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "Ghost", 100, 9, 2, 3, 22, null)

addRandomEncounter(guardF)
addRandomEncounter(ghost)