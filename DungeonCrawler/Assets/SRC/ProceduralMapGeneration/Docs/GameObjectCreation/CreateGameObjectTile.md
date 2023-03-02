# Function Summary
The CreateGameObjectTile function adds several components to a GameObject to create a tile with a mesh, material, collider, and rigidbody.

# Parameters
baseObject (type: GameObject) - The base object that the mesh, material, collider, and rigidbody components will be added to.
envMat (type: Material) - The material that will be applied to the MeshRenderer component of the baseObject.
Return Value
The function returns a GameObject object that represents the completed tile.

# Implementation Details
The CreateGameObjectTile function adds a MeshFilter component to the baseObject and assigns it a mesh obtained from the GetMesh() function. It then adds a MeshRenderer component to the baseObject and assigns it the envMat material. Next, the function adds a MeshCollider component with convex set to true and shared mesh set to the mesh obtained earlier from the MeshFilter. After that, the function adds a Rigidbody component to the baseObject with useGravity set to false and isKinematic set to true. Finally, the function sets the isStatic property of the baseObject to true and returns the baseObject.