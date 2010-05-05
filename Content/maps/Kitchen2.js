name("Kitchen")
mapfile("Kitchen2.tmx")
battleTexture("test-battle-background")
south("Kitchen1.js")
east("Kitchen3.js")

var cook1 = newNPE()
var cook2 = newNPE()
var cook3 = newNPE()
var cook4 = newNPE()

cook1.SetPosition(17,13)
cook1.SetTexture("chef_left")
cook1.SetInteractFunc(function(player)
{
	dialogue("Devon: Who's there?!|I'm off duty, I swear!|||Devon: Oh, it's just some newbie cook.")
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

var vegetable = newEnemy("snake", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("ghostie", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)