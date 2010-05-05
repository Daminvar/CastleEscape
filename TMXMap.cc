#include "TMXMap.hh"

#include <string>
#include <vector>
using namespace std;

#include "tinyxml/tinyxml.h"

namespace CastleEscape {

typedef std::vector<std::vector<int> > LayerVector;
LayerVector parseLayer(TiXmlNode* node, int width, int height);

TMXMap::TMXMap() {
	//TODO: Constructor
}

MapVector TMXMap::GetBaseLayers() {
	//TODO: Get base layers
}

MapVector TMXMap::GetTopLayers() {
	//TODO: Get top layers
}

int TMXMap::GetMapWidth() {
	//TODO
}

int TMXMap::GetMapHeight() {
	//TODO
}

int TMXMap::GetTileSize() {
	//TODO
}

void TMXMap::ParseTMXFile(string filename) {
	TiXmlDocument doc(filename);
	doc.LoadFile();
	TiXmlHandle handle(&doc);

	TiXmlHandle map = handle.FirstChild("map");
	map.ToElement()->QueryIntAttribute("width", &mapWidth);
	map.ToElement()->QueryIntAttribute("height", &mapHeight);
	map.ToElement()->QueryIntAttribute("tilewidth", &tilesize);

	baseLayers.clear();
	topLayers.clear();
	collisionRects.clear();

	TiXmlElement* layers = handle.FirstChild("layer").ToElement();
	for (; layers; layers = layers->NextSiblingElement()) {
		string name = layers->Attribute("name");
		TiXmlNode* layerData = layers->FirstChild();
		if (name == "base")
			baseLayers.push_back(parseLayer(layerData, mapWidth, mapHeight));
		else if (name == "top")
			topLayers.push_back(parseLayer(layerData, mapWidth, mapHeight));
	}

	//TODO: Get collision data
}

LayerVector parseLayer(TiXmlNode* node, int width, int height) {
	vector<vector<int> > layer;
	layer.resize(height);
	TiXmlElement* curTile = node->FirstChild()->ToElement();
	for (int i = 0; i < layer.size(); i++) {
		layer[i].resize(width);
		for (int j = 0; j < layer[i].size(); j++) {
			curTile->QueryIntAttribute("gid", &layer[i][j]);
			layer[i][j]--;
			curTile = curTile->NextSiblingElement();
		}
	}
	return layer;
}

bool TMXMap::IsCollisionAt(int x, int y) {
	//TODO
	return false;
}

} // namespace CastleEscape
