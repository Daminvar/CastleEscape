
name("HallWay 3")
mapfile("HallWay3.tmx")
battleTexture("test-battle-background")


west("HallWay2.js")
east("HallWay4.js")


var armoryGuard = newNPE()
armoryGuard.SetTexture("guard1_left")

if(getFlag("talked-to-ag"))
{ 
	armoryGuard.SetPosition(9,5)
	
}
else
{
	armoryGuard.SetPosition(10,4)
}

armoryGuard.SetInteractFunc(function(player) 
{
	if(getFlag("talked-to-ag"))
	{
		dialogue("Guard Ryan: Enter the armory if you dare..")
	}	
	else
	{
		dialogue("Guard Ryan: Past this point is off-limits, I would need someone of authority to tell me to let you through. |||| Jordan: What, like the king? |||| Guard Ryan: That would definitely help, but since i haven't been given orders, you're stuck")
		//Some sort of test/check to see if they have the neccessary item
		setFlag("talked-to-ag")
		reloadMap()
	}
})

addNPE(armoryGuard)








//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)