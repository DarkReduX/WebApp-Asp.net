var canvas = document.getElementById('threeModel');
var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const color = 0xFFFFFF;
const intensity = 1;
const light = new THREE.DirectionalLight(color, intensity);
light.position.set(-1, 2, 4);
scene.add(light);
var renderer = new THREE.WebGLRenderer({ canvas: canvas });
renderer.setClearColor(0x055550);
renderer.setSize(window.innerWidth, window.innerHeight);
var geometry = new THREE.SphereGeometry();
var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
var sphere = new THREE.Mesh(geometry, material);
sphere.setScale(100, 100, 100);
scene.add(sphere);

camera.position.z = 5;

var animate = function () {
    requestAnimationFrame(animate);

    sphere.rotation.x += 0.01;
    sphere.rotation.y += 0.01;

    renderer.render(scene, camera);
};

animate();