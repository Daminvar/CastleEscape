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
	return tmxMap.GetMapWidth();
}

int ScriptableMap::GetMapHeight() {
	return tmxMap.GetMapHeight();
}

int ScriptableMap::GetTileSize() {
	return tmxMap.GetTileSize();
}

string ScriptableMap::GetMapName() {
	//TODO
	return "Meh";
}

void ScriptableMap::LoadMap(string filename) {
	tmxMap.ParseTMXFile(filename);//TODO
}

void ScriptableMap::ReloadMap() {
	//TODO
}

bool ScriptableMap::ChangeMap(Directions direction) {
	//TODO
	return false;
}

} // namespace CastleEscape
