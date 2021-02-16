var WIDTH = window.innerWidth;
var HEIGHT = window.innerHeight;
var renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(WIDTH, HEIGHT);
renderer.setClearColor(0xfffff, 1);
document.body.appendChild(renderer.domElement);
var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(70, WIDTH / HEIGHT);
camera.position.z = 50;
scene.add(camera); function render() {
    requestAnimationFrame(render);
    renderer.render(scene, camera);
}
render();
var sphereGeometry = new THREE.SphereGeometry(10, 10, 10);
var basicMaterial = new THREE.MeshBasicMaterial({ color: 0x0095DD, wireframe: false, alphaMap: "/Content/Images/earthspec1k.jpg"});
var sphere = new THREE.Mesh(sphereGeometry, basicMaterial);
scene.add(sphere);
sphere.rotation.set(0., 0., 0);