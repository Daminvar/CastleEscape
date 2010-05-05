
name("HallWay 3")
mapfile("HallWay3.tmx")
battleTexture("test-battle-background")


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
		dialogue("Guard Ryan: Well, i can't say no to someone who has holy water. ||||  Our priest would only give that out to the most important of people")
		setFlag("armory-open")
	}	
	else
	{
		dialogue("Guard Ryan: Past this point to the armory is off-limits, I would need something to give me reason to let you by. |||| Jordan: What would that be? |||| Guard Ryan: I won't know until i see it, but people have told me that i'm a holy man")
			
	}
})

addNPE(armoryGuard)


var snake = newEnemy("snake", "snake in your boot", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "ghost from the past", 100, 9, 2, 3, 22, null)

addRandomEncounter(snake)
addRandomEncounter(ghost)