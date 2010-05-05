
name("CourtYard 2")
mapfile("CourtYard2.tmx")
battleTexture("test-battle-background")

north("Graveyard1.js")
west("CourtYard1.js")

var courtyard2Civ1= newNPE()
courtyard2Civ1.SetTexture("man_right")
courtyard2Civ1.SetPosition(9,8)

courtyard2Civ1.SetInteractFunc(function(player) 
{
	dialogue("Dan: I don't believe i've seen you before..|| Jordan: Yeah, i get that a lot.")	

})

addNPE(courtyard2Civ1)


var courtyard2Civ2 = newNPE()
courtyard2Civ2.SetTexture("gGirl-left")
courtyard2Civ2.SetPosition(12,8)

courtyard2Civ2.SetInteractFunc(function(player) 
{
	dialogue("Christie: Nothing quite like reading a book on England's kind and peaceful rulers")	
})

addNPE(courtyard2Civ2)

var snake = newEnemy("snake", "snake in your boot", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "ghost from the past", 100, 9, 2, 3, 22, null)

addRandomEncounter(snake)
addRandomEncounter(ghost)