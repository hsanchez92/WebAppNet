function overPais(x) {
    //alert(x.id);
    if (x.id === "imgMX") {
        x.src = "Imagenes/Paises/MX_Habilitado.png";
        document.getElementById("imgAR").src = "Imagenes/Paises/AR_Deshabilitado.png";
    }

    if (x.id === "imgAR") {
        x.src = "Imagenes/Paises/AR_Habilitado.png";
        document.getElementById("imgMX").src = "Imagenes/Paises/MX_Deshabilitado.png";
    }


}

function outPais(x) {

    var paisSeleccionado = document.querySelector(
        'input[name="pais"]:checked');
    var paisId = paisSeleccionado.value;

    //alert(paisId);

    if (paisId === "mx") {
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Habilitado.png";
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Deshabilitado.png";
        //alert(paisId);
    }

    if (paisId === "ar") {
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Deshabilitado.png";
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Habilitado.png";
        // alert(paisId);
    }
    
}


function seleccionaPais(x) {

    // alert(x.id);

    if ("imgMX" === x.id) {
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Habilitado.png";
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Deshabilitado.png";
        document.getElementById('btnMX').checked = true;
        document.getElementById('btnAR').checked = false;

    }

    if ("imgAR" === x.id) {
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Deshabilitado.png";
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Habilitado.png";
        document.getElementById('btnMX').checked = false;
        document.getElementById('btnAR').checked = true;
    } 
    enviaPais(x.id);
}

function enviaPais(x) {

    var r = confirm("¿Desea cambiar el pais?");
    if (r == true) {
        window.location.href = "/ValidaPais.aspx?Pais="+x;
    } 

}

function validaPais(pais) {
    alert("11"+pais);

    if ("MX" === pais) {
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Habilitado.png";
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Deshabilitado.png";
        document.getElementById('btnMX').checked = true;
        document.getElementById('btnAR').checked = false;
        alert("12");
    }

    if ("AR" === pais) {
        alert("13AA")
        document.getElementById("imgMX").src =
            "Imagenes/Paises/MX_Deshabilitado.png";
        alert("13AA-2")
        document.getElementById("imgAR").src =
            "Imagenes/Paises/AR_Habilitado.png";
        alert("13AA-3")
        document.getElementById('btnMX').checked = false;
        alert("13AA-4")
        document.getElementById('btnAR').checked = true;
        alert("13AA-5")
        
    } 

    function validaPais() {
        alert("Prueba");
    }

}

