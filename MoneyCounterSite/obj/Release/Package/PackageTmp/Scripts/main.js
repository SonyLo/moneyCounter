/* ---- particles.js config ---- */


particlesJS("particles-js", {
    "particles": {
        "number": {
            "value": 40,
            "density": {
                "enable": true,
                "value_area": 800
            }
        },
        "color": {
            "value": "#ffffff"
        },
        "shape": {
            "type": "circle",
            "stroke": {
                "width": 0,
                "color": "#000000"
            },
            "polygon": {
                "nb_sides": 5
            },
            "image": {
                "src": "img/github.svg",
                "width": 100,
                "height": 100
            }
        },
        "opacity": {
            "value": 0.5,
            "random": false,
            "anim": {
                "enable": false,
                "speed": 1,
                "opacity_min": 0.1,
                "sync": false
            }
        },
        "size": {
            "value": 3,
            "random": true,
            "anim": {
                "enable": false,
                "speed": 40,
                "size_min": 0.1,
                "sync": false
            }
        },
        "line_linked": {
            "enable": true,
            "distance": 150,
            "color": "#ffffff",
            "opacity": 0.4,
            "width": 1
        },
        "move": {
            "enable": true,
            "speed": 6,
            "direction": "none",
            "random": false,
            "straight": false,
            "out_mode": "out",
            "bounce": false,
            "attract": {
                "enable": false,
                "rotateX": 600,
                "rotateY": 1200
            }
        }
    },
    "interactivity": {
        "detect_on": "canvas",
        "events": {
            "onhover": {
                "enable": true,
                "mode": "grab"
            },
            "onclick": {
                "enable": true,
                "mode": "push"
            },
            "resize": true
        },
        "modes": {
            "grab": {
                "distance": 140,
                "line_linked": {
                    "opacity": 1
                }
            },
            "bubble": {
                "distance": 400,
                "size": 40,
                "duration": 2,
                "opacity": 8,
                "speed": 3
            },
            "repulse": {
                "distance": 200,
                "duration": 0.4
            },
            "push": {
                "particles_nb": 4
            },
            "remove": {
                "particles_nb": 2
            }
        }
    },
    "retina_detect": true
});


/* ---- stats.js config ---- */




var ctx = document.getElementById('myChart').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль'],
        datasets: [{
            label: 'Lorem',
            backgroundColor: 'rgb(86, 176, 240)',
            borderColor: 'rgb(40, 153, 235)',
            data: [0, 10, 5, 2, 20, 30, 45]
        }]
    },

    // Configuration options go here
    options: {}
});


function createFamily() {
    
    

    var Family = new Object();
    Family.FamilyName = document.getElementById('FamilyName').value;
    Family.idUserAdd = document.getElementById('idUserAdd').value;
    Family.idUserInit = document.getElementById('userid').value;


    if (Family.FamilyName == "" || Family.idUserAdd == "") {
        if (Family.FamilyName == "") {
            addElement("Нужно заполнить", "FamilyName");
        }
        if (Family.idUserAdd == "") {
            addElement("Нужно заполнить", "idUserAdd");
        }
    }
    else {
        $.ajax({
            type: "POST",
            url: "/User/CreateFamily",
            data: JSON.stringify(Family),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    alert(response);
                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

    





    //if (Family != null) {
    //    $.ajax({
    //        type: "POST",
    //        url: "/User/CreateFamily",
    //        data: JSON.stringify(Family),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (response) {
    //            if (response != null) {
    //                alert(response);
    //            } else {
    //                alert("Something went wrong");
    //            }
    //        },
    //        failure: function (response) {
    //            alert(response.responseText);
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });
    //}

    

    
}





function addElement( msg, idInsert) {

    document.getElementById(idInsert).className = "form-control is-invalid";

    var newDiv = document.createElement("div");  // Create with DOM
    newDiv.className = "alert alert-danger mt-2";
    
    newDiv.innerHTML = msg;
    $("#" + idInsert).after(newDiv);  


}
