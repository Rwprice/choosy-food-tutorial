@tool
extends EditorScenePostImport

func _post_import(scene):
	scene = scene as Node3D
	var mesh = scene.get_child(0) as MeshInstance3D
	mesh.create_trimesh_collision()
	
	return scene
