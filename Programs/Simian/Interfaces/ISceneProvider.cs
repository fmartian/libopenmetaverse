using System;
using OpenMetaverse;

namespace Simian
{
    public delegate void ObjectAddCallback(object sender, Agent creator, SimulationObject obj);
    public delegate void ObjectRemoveCallback(object sender, SimulationObject obj);
    public delegate void ObjectTransformCallback(object sender, SimulationObject obj,
        Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 acceleration,
        Vector3 angularVelocity, Vector3 scale);
    public delegate void ObjectFlagsCallback(object sender, SimulationObject obj, PrimFlags flags);
    public delegate void ObjectModifyCallback(object sender, SimulationObject obj,
        Primitive.ConstructionData data);
    // TODO: Convert terrain to a patch-based system
    public delegate void TerrainUpdatedCallback(object sender);

    public interface ISceneProvider
    {
        event ObjectAddCallback OnObjectAdd;
        event ObjectRemoveCallback OnObjectRemove;
        event ObjectTransformCallback OnObjectTransform;
        event ObjectFlagsCallback OnObjectFlags;
        event ObjectModifyCallback OnObjectModify;
        event TerrainUpdatedCallback OnTerrainUpdated;

        // TODO: Convert to a patch-based system, and expose terrain editing
        // through functions instead of a property
        float[] Heightmap { get; set; }

        bool ObjectAdd(object sender, Agent creator, SimulationObject obj);
        bool ObjectRemove(object sender, SimulationObject obj);
        void ObjectTransform(object sender, SimulationObject obj, Vector3 position,
            Quaternion rotation, Vector3 velocity, Vector3 acceleration,
            Vector3 angularVelocity, Vector3 scale);
        void ObjectFlags(object sender, SimulationObject obj, PrimFlags flags);
        void ObjectModify(object sender, SimulationObject obj, Primitive.ConstructionData data);
        bool TryGetObject(uint localID, out SimulationObject obj);
        bool TryGetObject(UUID id, out SimulationObject obj);
    }
}
