
name("CourtYard 1")
mapfile("CourtYard1.tmx")
overworldMusic("courtyard-song")
randomBattleMusic("regular-battle-song")
battleTexture("courtyard.2")


east("CourtYard2.js")
south("HallWay2.js")


var courtyard1Civ1 = newNPE()
courtyard1Civ1.SetTexture("lady_right")
courtyard1Civ1.SetPosition(1,5)

courtyard1Civ1.SetInteractFunc(function(player) 
{
	dialogue("Lady Victoria: What a lovely day in the courtyard!|Susan: This place is beautiful... I can't believe we almost skipped over it on our trip.|Lady Victoria: King Mervyn and Queen Nicoline put together quite a nice castle here.")	

})

addNPE(courtyard1Civ1)



var courtyard1Civ2 = newNPE()
courtyard1Civ2.SetTexture("girl_left")
courtyard1Civ2.SetPosition(3,5)

courtyard1Civ2.SetInteractFunc(function(player) 
{
	dialogue("Susan: I'm so happy we agreed to visit this castle.|Lady Victoria: I can't wait to try the food here. Apparentently this castle has the best chef in the area. |Susan: We should go soon then, it's almost lunch time and I want to try out this 'grand' food!")	

})

addNPE(courtyard1Civ2)

var courtyard1Civ3 = newNPE()
courtyard1Civ3.SetTexture("guyHat-left")
courtyard1Civ3.SetPosition(13,9)

courtyard1Civ3.SetInteractFunc(function(player) 
{
	dialogue("Joe: Look at this garden, the queen must have put a lot of work into it.")	

})

addNPE(courtyard1Civ3)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(1, 9)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)



var gardener = newEnemy("gardeninja_battle", "Gardeninja", 220, 55, 2, 30, 55, null)
var ghost = newEnemy("ghost1_battle", "Ghost", 200, 65, 2, 5, 50, null)

addRandomEncounter(gardener)
addRandomEncounter(ghost)