
name("HallWay 4")
mapfile("HallWay4.tmx")
battleTexture("test-battle-background")


west("HallWay3.js")
south("todo")


var hallway4civ1 = newNPE()
hallway4civ1.SetTexture("ghostie")
hallway4civ1.SetPosition(10,5)

hallway4civ1.SetInteractFunc(function(player) 
{
	dialogue("I do love this painting")	

})

addNPE(hallway4civ1)

var hallway4civ2 = newNPE()
hallway4civ2.SetTexture("ghostie")
hallway4civ2.SetPosition(12,10)

hallway4civ2.SetInteractFunc(function(player) 
{
	dialogue("I hear the head knight spends most of his time in the armory ")	

})

addNPE(hallway4civ2)


//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)