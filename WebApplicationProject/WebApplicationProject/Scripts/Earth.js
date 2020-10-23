
//var loader = new THREE.OBJLoader();
var canvas = document.getElementById('threeModel');
var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(50, window.innerWidth / window.innerHeight, 0.1, 1000);
var renderer = new THREE.WebGLRenderer({ canvas: canvas, alpha: true });
renderer.setClearColor(0x000000, 0);
renderer.setSize(window.innerWidth/2, window.innerHeight/2);
var geometry = new THREE.SphereGeometry();
var material = new THREE.MeshBasicMaterial({ color: 0x117a8e, skinning: true, wireframeLinewidth: 100, wireframe: true });
var sphere = new THREE.Mesh(geometry, material);

//load a resource
//loader.load(
//    // resource URL
//    '/Scripts/Earth.obj  ',
//    // called when resource is loaded
//    function (object) {
//        scene.add(object);

//    },
//    // called when loading is in progresses
//    function (xhr) {

//        console.log((xhr.loaded / xhr.total * 100) + '% loaded');

//    },
//    // called when loading has errors
//    function (error) {

//        console.log('An error happened');

//    })
scene.add(sphere);

camera.position.z = 5;
//camera.position.x = 0;

var animate = function () {
    requestAnimationFrame(animate);

    sphere.rotation.x += 0.001;
    sphere.rotation.y += 0.001;

    renderer.render(scene, camera);
};


animate();