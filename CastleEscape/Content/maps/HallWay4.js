
name("HallWay 4")
mapfile("HallWay4.tmx")
battleTexture("test-battle-background")


west("HallWay3.js")
south("armory1.js")


var hallway4civ1 = newNPE()
hallway4civ1.SetTexture("gGirl-back")
hallway4civ1.SetPosition(10,5)

hallway4civ1.SetInteractFunc(function(player) 
{
	dialogue("Kelly: I do love this painting || Jordan: Who is that a portrait of? || Kelly: How do you not know NAME, he's our castle's best knight. || Jordan: (Looks like thats the guy i have to chat with)")	

})

addNPE(hallway4civ1)

var hallway4civ2 = newNPE()
hallway4civ2.SetTexture("guard2_left")
hallway4civ2.SetPosition(12,10)

hallway4civ2.SetInteractFunc(function(player) 
{
	dialogue("Harry: NAME is in the armory, right now. Be careful if you happen to travel south to him, I hear he's not in the best of moods. ")	

})

addNPE(hallway4civ2)


var snake = newEnemy("snake", "snake in your boot", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "ghost from the past", 100, 9, 2, 3, 22, null)

addRandomEncounter(snake)
addRandomEncounter(ghost)