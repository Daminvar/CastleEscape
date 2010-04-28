
name("CourtYard 2")
mapfile("CourtYard2.tmx")
battleTexture("test-battle-background")


west("CourtYard1.js")
//north("todo")


var courtyard2Civ1= newNPE()
courtyard2Civ1.SetTexture("ghostie")
courtyard2Civ1.SetPosition(9,8)

courtyard2Civ1.SetInteractFunc(function(player) 
{
	dialogue("i don't believe i've seen you before..")	

})

addNPE(courtyard2Civ1)


var courtyard2Civ2 = newNPE()
courtyard2Civ2.SetTexture("test-npe")
courtyard2Civ2.SetPosition(12,8)

courtyard2Civ2.SetInteractFunc(function(player) 
{
	dialogue("Nothing quite like reading a book on England's kind and peaceful rulers")	

})

addNPE(courtyard2Civ2)

//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)