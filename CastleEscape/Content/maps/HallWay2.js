
name("HallWay 2")
mapfile("HallWay2.tmx")
battleTexture("test-battle-background")

north("CourtYard1.js")
west("HallWay1.js")
east("HallWay3.js")
south("bedroom1.js")

var courtyardGuard1 = newNPE()
courtyardGuard1.SetTexture("guard2_front")

courtyardGuard1.SetPosition(4,5)

courtyardGuard1.SetInteractFunc(function(player){
	dialogue("Guard Allan: Get away, the courtyard is off-limits! |||| Jordan: I just need to pass by real quick, i won't cause any problems. |||| Guard Allan: GO AWAY!")
})
addNPE(courtyardGuard1)

var courtyardGuard2 = newNPE()
courtyardGuard2.SetTexture("guard1_front")

if(getFlag("talked-to-cyg2"))
{ 
	courtyardGuard2.SetPosition(6,6)
}
else
{
	courtyardGuard2.SetPosition(5,5)
}

courtyardGuard2.SetInteractFunc(function(player) 
{
	if(getFlag("talked-to-cyg2"))
	{
		dialogue("Guard Mark: Be quick about if you need to go through the courtyard.")
		courtyardGuard2.SetTexture("guard1_left")
	}	
	else
	{
		dialogue("Jordan: Can i please get by to the courtyard, it's of utmost importance. |||| Guard Mark: Sorry, it's against the rules to let just anyone have access to the courtyard or further. |||| Jordan: Please, i really need to go.. |||| Guard Mark: Okay, i might be able to slip you through, if you get me SOMETHING from family's bedroom")
		//Some sort of test/check to see if they have the neccessary item
		setFlag("talked-to-cyg2")
		reloadMap()
	}
})

addNPE(courtyardGuard2)


var bedroomGuard = newNPE()
bedroomGuard.SetTexture("girl_left")

if(getFlag("talked-to-bedroomGuard"))
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
	if(getFlag("talked-to-bedroomGuard"))
	{
		dialogue("Lady Mary: Oh you bought food for the family? Well i can't deny them food.. Go ahead")
	}	
	else
	{
		dialogue("Lady Mary: I'm sorry but at this time no one may enter the bedrooms, the maid hasnt arrived yet. |||| Lady Mary: Unless you have food or something for the family quarters, you can't pass ")
		//Some sort of test/check to see if they have the neccessary item
		setFlag("talked-to-bedroomGuard")
		reloadMap()
	}
})


addNPE(bedroomGuard)


//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)