
name("HallWay 3")
mapfile("HallWay3.tmx")
battleTexture("hallway-bg")


west("HallWay2.js")
east("HallWay4.js")


var armoryGuard = newNPE()
armoryGuard.SetTexture("guard1_left")

if(getFlag("armory-open"))
{ 
	armoryGuard.SetPosition(9,5)
	
}
else
{
	armoryGuard.SetPosition(10,4)
}

armoryGuard.SetInteractFunc(function(player) 
{
	if(getFlag("holy-water"))
	{
		dialogue("Guard Ryan: Well, i can't say no to someone who has holy water. |  Our priest would only give that out to the most important of people")
		setFlag("armory-open")
		reloadMap()
	}	
	else
	{
		dialogue("Guard Ryan: Past this point to the armory is off-limits, I would need something to give me reason to let you by. | Jordan: What would that be? | Guard Ryan: I won't know until i see it, but people have told me that i'm a holy man")
			
	}
})

addNPE(armoryGuard)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(3, 14)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var guardF = newEnemy("guard2_left", "Castle Guard", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "Ghost", 100, 9, 2, 3, 22, null)

addRandomEncounter(guardF)
addRandomEncounter(ghost)