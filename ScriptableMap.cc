#include "ScriptableMap.hh"

#include <string>
using namespace std;

namespace CastleEscape {

ScriptableMap::ScriptableMap() {
	//TODO: Constructor
}

ScriptableMap::~ScriptableMap() {
	//TODO: Destructor
}

int ScriptableMap::GetMapWidth() {
	//TODO
	return 20;
}

int ScriptableMap::GetMapHeight() {
	//TODO
	return 15;
}

int ScriptableMap::GetTileSize() {
	//TODO
	return 32;
}

string ScriptableMap::GetMapName() {
	//TODO
	return "Meh";
}

void ScriptableMap::LoadMap(string filename) {
	//TODO
}

void ScriptableMap::ReloadMap() {
	//TODO
}

bool ScriptableMap::ChangeMap(Directions direction) {
	//TODO
	return false;
}

} // namespace CastleEscape
