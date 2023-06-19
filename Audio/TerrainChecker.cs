using UnityEngine;

public class TerrainChecker
{
    private float[] GetTextureMix(Vector3 playerPos, Terrain t)
    {
        Vector3 tPos = t.transform.position;
        TerrainData tData = t.terrainData;

        int mapX = Mathf.RoundToInt((playerPos.x - tPos.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerPos.z - tPos.z) / tData.size.z * tData.alphamapHeight);
        float[,,] splatMapData = tData.GetAlphamaps(mapX, mapZ, 1, 1);

        float[] cellMix = new float[splatMapData.GetUpperBound(2) + 1];
        for (int i = 0; i < cellMix.Length; i++)
        {
            cellMix[i] = splatMapData[0, 0, i];
        }
        return cellMix;
    }

    public string GetLayerName(Vector3 playerPos, Terrain t)
    {
        float[] cellMix = GetTextureMix(playerPos, t);
        float strongest = 0;
        int maxIndex = 0;
        for (int i = 0; i < cellMix.Length; i++)
        {
            if (cellMix[i] > strongest)
            {
                maxIndex = i;
                strongest = cellMix[i];
            }
        }
        return t.terrainData.terrainLayers[maxIndex].name;
    }

    public Terrain GetCurrentTerrain(Vector3 playerPosition)
    {
        Terrain[] terrains = Terrain.activeTerrains;
        Terrain closestTerrain = null;

        for (int i = 0; i < terrains.Length; i++)
        {
            TerrainData terrainData = terrains[i].terrainData;
            Vector3 localPosition = terrains[i].transform.InverseTransformPoint(playerPosition);
            localPosition.y = 0;

            if (terrainData.bounds.Contains(localPosition))
            {
                closestTerrain = terrains[i];
            }
        }
        return closestTerrain;
    }
}