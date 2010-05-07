#include "ScriptableMap.hh"

#include <string>
using namespace std;

#include <v8.h>

namespace CastleEscape {

const string MAP_DIRECTORY = "Content/maps/";

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
	loadMapAndScript(filename);
}

void ScriptableMap::loadMapAndScript(string filename) {
	parseScriptFile(filename);
	tmxMap.ParseTMXFile(MAP_DIRECTORY + tmxMapFilename);
}

void ScriptableMap::ReloadMap() {
	//TODO
}

bool ScriptableMap::ChangeMap(Directions direction) {
	//TODO
	return false;
}

void ScriptableMap::parseScriptFile(string filename) {
	//TODO v8::
}

} // namespace CastleEscape
