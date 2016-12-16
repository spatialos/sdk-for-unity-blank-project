using Improbable.General;
using Improbable.Worker;
using Improbable.Math;
using Improbable.Unity.Core.Acls;
using UnityEngine;

namespace Assets.EntityTemplates
{
    public class ExampleEntityTemplate : MonoBehaviour
    {
        // Template definition for a Example entity
        public static SnapshotEntity GenerateExampleSnapshotEntityTemplate()
        {
            // Set name of Unity prefab associated with this entity
            var exampleEntity = new SnapshotEntity { Prefab = "ExampleEntity" };

            // Define components attached to snapshot entity
            exampleEntity.Add(new WorldTransform.Data(new WorldTransformData(new Coordinates(-5, 10, 0))));

            // Grant FSim (server-side) workers write-access over all of this entity's components, read-access for visual (e.g. client) workers
            var acl = Acl.GenerateServerAuthoritativeAcl(exampleEntity);
            exampleEntity.SetAcl(acl);

            return exampleEntity;
        }
    }
}