
name("CourtYard 2")
mapfile("CourtYard2.tmx")
overworldMusic("courtyard-song")
randomBattleMusic("regular-battle-song")
battleTexture("courtyard.2")

north("Graveyard1.js")
west("CourtYard1.js")

var courtyard2Civ1= newNPE()
courtyard2Civ1.SetTexture("man_right")
courtyard2Civ1.SetPosition(9,8)

courtyard2Civ1.SetInteractFunc(function(player) 
{
	dialogue("Dan: I don't believe I've seen you before...|Jordan: Yeah, I get that a lot.")	

})

addNPE(courtyard2Civ1)


var courtyard2Civ2 = newNPE()
courtyard2Civ2.SetTexture("gGirl-left")
courtyard2Civ2.SetPosition(12,8)

courtyard2Civ2.SetInteractFunc(function(player) 
{
	dialogue("Christie: Nothing quite like reading a book on England's kind and peaceful rulers.")	
})

addNPE(courtyard2Civ2)

var gardener = newEnemy("guyHat-left", "Gardener", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghost1_battle", "Ghost", 100, 9, 2, 3, 22, null)

addRandomEncounter(gardener)
addRandomEncounter(ghost)

