var props = {
    size: {
        height: 900,
        width: 1200
    },

    colors: {
        backgroundColor: '#25252B',
        globeDotColor: '#892cdc',
        globeColor: '#520E8F'
    },
    controls: {
        autoRotate: true,
        enableZoom: false,
        autoRotateSpeed: 1
    }

}
var postsData;
function startGlobe() {
    //get data from db
    $(document).ready(function () {
        $.ajax({
            url: 'WebService1.asmx/GetAllNews',
            dataType: "json",
            method: 'post',
            async: false,
            success: function (data) {
                postsData = data;
                console.log(data);
            },
            error: function (err) {
                alert(err);
            }
        });
    });
    //create scene with globe
    fetch('../Datasets/ne_110m_admin_0_countries.geojson').then(res => res.json()).then(countries => {
        const world = Globe()
            //Globe Layer
            .hexPolygonsData(countries.features)
            .hexPolygonResolution(3)
            .hexPolygonMargin(0.3)
            .hexPolygonAltitude(0.005)
            .hexPolygonMargin(0.65)
            .hexPolygonColor(() => props.colors.globeDotColor)
            //globeData
            .pointsData(postsData)
            .pointsTransitionDuration(0)
            .pointLat(d => d.latitude)
            .pointLng(d => d.longitude)
            .pointRadius(0.3)
            .pointColor(() => '#FF424F')
            .pointLabel((postsData) =>`

          <div class="globe-popup"><span style="display: inline; width: 200px;">${postsData.header}</span><span style="display: inline; width: 200px;">created by ${postsData.UserName}</span></div>

        `)
            .onPointHover(hoverD =>
                hoverD ? world.controls().autoRotate = false : world.controls().autoRotate = true
        )
            .onPointClick(point => window.location.href = "/News/Details/" + point.ID)
            
            
            (document.getElementById('globe'))
        // console.log(postsData.latitude)
        console.log(countries);
        //set size
        world.globeMaterial().color = new THREE.Color(props.colors.globeColor);
        world.width(1200);
        world.height(1000);
        world.backgroundColor("#25252B")
        //set controls
        world.controls().enableZoom = false;
        world.controls().autoRotate = true;
        world.controls().autoRotateSpeed = 1;
        console.log(world.globeMaterial());

        console.log(world.controls());
    });
}
window.addEventListener("load", startGlobe);