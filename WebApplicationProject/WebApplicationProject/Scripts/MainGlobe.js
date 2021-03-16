var props = {
    size: {
        height: 900,
        width: 1200
    },

    colors: {
        backgroundColor: '#25252B',
        globeDotColor: '#892cdc',
        globeColor: '#440a67'
    }

}

fetch('../Datasets/ne_110m_admin_0_countries.geojson').then(res => res.json()).then(countries => {
    const world = Globe()

        .hexPolygonsData(countries.features)
        .hexPolygonResolution(3)
        .hexPolygonMargin(0.3)
        .hexPolygonAltitude(0.005)
        .hexPolygonMargin(0.65)
        .hexPolygonColor(() => props.colors.globeDotColor)

        (document.getElementById('globe'))
    
    //set size
    world.globeMaterial().color = new THREE.Color(props.colors.globeColor);
    world.width(1200);
    world.height(1000);
    world.backgroundColor("#25252B")
    world.controls().zoom = false;
    const boxWidth = 20;
    const boxHeight = 200;
    const boxDepth = 20;
    const geometry = new THREE.BoxGeometry(boxWidth, boxHeight, boxDepth);

    const material = new THREE.MeshBasicMaterial({ color: 0xFF0F5F });  // greenish blue

    var cube = new THREE.Mesh(geometry, material);
    cube.position.set(150, 0, 0);
    console.log(world.globeMaterial());
//    const coords = world.toGlobeCoords(61.210817, 35.650072);

});