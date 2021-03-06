name("Kitchen")
mapfile("Kitchen2.tmx")
overworldMusic("kitchen-song")
randomBattleMusic("regular-battle-song")
battleTexture("restaurant-kitchen")
south("Kitchen1.js")
east("Kitchen3.js")

var cook1 = newNPE()
var cook2 = newNPE()
var cook3 = newNPE()
var cook4 = newNPE()

cook1.SetPosition(18,12)
cook1.SetTexture("chef_left")
cook1.SetInteractFunc(function(player)
{
	dialogue("Doven: Who's there?! I'm off duty, I swear!||||Doven: Oh, it's just some newbie cook.")
} )

cook2.SetPosition(3,6)
cook2.SetTexture("chef_front")
cook2.SetInteractFunc(function(player)
{
	dialogue("Harald: I always wanted to be a tailor...")
} )

cook3.SetPosition(7,12)
cook3.SetTexture("waiter_front")
cook3.SetInteractFunc(function(player)
{
	dialogue("Hale: La la la~|Cleaning the tables~|||Hale: Mother says my talents are wasted here, but it's just so easy to do!")
} )

cook4.SetPosition(13,9)
cook4.SetTexture("chef_left")
cook4.SetInteractFunc(function(player)
{
	dialogue("Nidos: Are you new here?")
} )

addNPE(cook1)
addNPE(cook2)
addNPE(cook3)
addNPE(cook4)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(17, 10)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var salad = []
salad[0] = newItem("Salad", "A fresh green salad.", 130, 10, 0)

var turnip = []
turnip[0] = newItem("Turnip", "A homegrown turnip.", 70, 30, 0)

var vegetable = newEnemy("deadgetable_battle", "Deadgetable", 90, 45, 2, 2, 20, turnip)
var evSalad = newEnemy("salad_battle", "Evil Salad", 100, 40, 7, 3, 25, salad)

addRandomEncounter(vegetable)
addRandomEncounter(evSalad)