
name("CourtYard 1")
mapfile("CourtYard1.tmx")
battleTexture("test-battle-background")


east("CourtYard2.js")
south("HallWay2.js")


var courtyard1Civ1 = newNPE()
courtyard1Civ1.SetTexture("lady_right")
courtyard1Civ1.SetPosition(1,5)

courtyard1Civ1.SetInteractFunc(function(player) 
{
	dialogue("Lady Victoria: What a lovely day in the courtyard |||| Susan: This place is beautiful, i can't believe we almost skipped over it on our trip.|||| Lady Victoria: King NAME and queen NAME put together quite a nice castle here.")	

})

addNPE(courtyard1Civ1)



var courtyard1Civ2 = newNPE()
courtyard1Civ2.SetTexture("girl_left")
courtyard1Civ2.SetPosition(3,5)

courtyard1Civ2.SetInteractFunc(function(player) 
{
	dialogue("Susan: I'm so happy we agreed to visit this castle.|||| Lady Victoria: I can't wait to try the food here. Apparentently this castle has the best chef in the area. |||| Susan: We should go soon then, it's almost lunch time and i want to try out this 'grand' food!")	

})

addNPE(courtyard1Civ2)

var courtyard1Civ3 = newNPE()
courtyard1Civ3.SetTexture("guard2_left")
courtyard1Civ3.SetPosition(13,9)

courtyard1Civ3.SetInteractFunc(function(player) 
{
	dialogue("Joe: Look at this garden, the queen must have put a lot of work into it")	

})

addNPE(courtyard1Civ3)

//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)