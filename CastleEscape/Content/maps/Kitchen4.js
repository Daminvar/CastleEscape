name("Kitchen")
mapfile("Kitchen4.tmx")
battleTexture("test-battle-background")
south("Kitchen3.js")

var vegetable = newEnemy("snake", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("ghostie", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)