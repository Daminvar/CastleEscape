
name("HallWay 2")
mapfile("HallWay2.tmx")
battleTexture("test-battle-background")

north("CourtYard1.js")
west("HallWay1.js")
east("HallWay3.js")
south("bedroom1.js")

var courtyardGuard1 = newNPE()
courtyardGuard1.SetTexture("test-npe")

courtyardGuard1.SetPosition(4,5)

courtyardGuard1.SetInteractFunc(function(player){
	dialogue("Get away, the courtyard is off-limits!")
})
addNPE(courtyardGuard1)

var courtyardGuard2 = newNPE()
courtyardGuard2.SetTexture("snake")

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
		dialogue("Be quick about it if you need to go through the courtyard.")
	}	
	else
	{
		dialogue("I'm not suposed to let you into the courtyard but if you bring me something i might change my mind")
		//Some sort of test/check to see if they have the neccessary item
		setFlag("talked-to-cyg2")
		reloadMap()
	}
})

addNPE(courtyardGuard2)


var bedroomGuard = newNPE()
bedroomGuard.SetTexture("ghostie")

if(getFlag("talked-to-bedroomGuard"))
{ 
	bedroomGuard.SetPosition(7,10)
}
else
{
	bedroomGuard.SetPosition(8,11)
}

bedroomGuard.SetInteractFunc(function(player) 
{
	if(getFlag("talked-to-bedroomGuard"))
	{
		dialogue("Took you long enough, hurry up and get to work")
	}	
	else
	{
		dialogue("I'm sorry but at this time no one may enter the bedrooms, the maid hasnt arrived yet")
		//Some sort of test/check to see if they have the neccessary item
		setFlag("talked-to-bedroomGuard")
		reloadMap()
	}
})


addNPE(bedroomGuard)


//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)