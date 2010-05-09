
name("HallWay 4")
mapfile("HallWay4.tmx")
overworldMusic("hallway-song")
randomBattleMusic("regular-battle-song")
battleTexture("hallway-bg")


west("HallWay3.js")
south("armory1.js")


var hallway4civ1 = newNPE()
hallway4civ1.SetTexture("gGirl-back")
hallway4civ1.SetPosition(10,5)

hallway4civ1.SetInteractFunc(function(player) 
{
	dialogue("Kelly: I do love this painting.|Jordan: Who is that a portrait of?|Kelly: How do you not know Kristof? He's our castle's best knight.|Jordan: (Looks like that's the guy I have to chat with.)")	

})

addNPE(hallway4civ1)

var hallway4civ2 = newNPE()
hallway4civ2.SetTexture("guard2_left")
hallway4civ2.SetPosition(12,10)

hallway4civ2.SetInteractFunc(function(player) 
{
	dialogue("Harry: Kristof is in the armory right now. Be careful if you happen to travel south to him... I hear he's not in the best of moods.|Jordan: (No one ever is...)")	

})

addNPE(hallway4civ2)

var hallway4civ3 = newNPE()
hallway4civ3.SetTexture("man_left")
hallway4civ3.SetPosition(17,11)

hallway4civ3.SetInteractFunc(function(player) 
{
	dialogue("Donald: You know, in the original design for this castle, this was to be a large armoire. The builders just got a bit confused.|Jordan: I guess that's what happens when the majority of people are illiterate.")	

})

addNPE(hallway4civ3)


var guardF = newEnemy("soldier3_battle", "Castle Guard", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghost1_battle", "Ghost", 100, 9, 2, 3, 22, null)

addRandomEncounter(guardF)
addRandomEncounter(ghost)