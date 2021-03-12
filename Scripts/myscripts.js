var content;
var loading;
var lnkFaireSimulation;
var lnkEffacerSimulation;
var lnkEnregistrerSimulation;
var lnkTerminerSession;
var lnkVoirSimulation;
var lnkRetourFormulaire;
var options;

function faireSimulation() {
    var formulaire = $("#formulaire");


    if (!formulaire.validate().form()) {
        return;
    }


    var simulation = $("#simulation");
    $.ajax({
        url: 'Pam/FaireSimulation',
        type: 'POST',
        data: formulaire.serializeArray(),
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {
            simulation.html(data);
        },
        error: function (jqXHR) {
            simulation.html(jqXHR.responseText);
            simulation.show();
        },
        complete: function () {
            loading.hide();
        }
    })
    simulation.show();
    setMenu([lnkEffacerSimulation, lnkVoirSimulation, lnkEnregistrerSimulation, lnkTerminerSession]);
}

function effacerSimulation() {
    var hT = $("#HeuresTravaillees")
    var jT = $("#joursTravaillees")

    hT.val("");
    jT.val("");

    $("#simulation").hide();
    setMenu([lnkFaireSimulation, lnkTerminerSession, lnkVoirSimulation]);
}

function enregistrerSimulation() {
    


    $.ajax({
        url: '/Pam/EnregistrerSimulation',
        type: 'POST',
        data: content,
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {

            content.html(data);
        },
        complete: function () {
            loading.hide();
        }
    })
    setMenu([lnkRetourFormulaire, lnkTerminerSession]);
}

function voirSimulation() {
    $.ajax({
        url: '/Pam/VoirSimulation',
        type: 'POST',
        data: content,
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {

            content.html(data);
        },
        complete: function () {
            loading.hide();
        }
    })
    setMenu([lnkRetourFormulaire, lnkTerminerSession]);
}

function retourFormulaire() {
    $.ajax({
        url: '/Pam/Formulaire',
        type: 'POST',
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {

            content.html(data);
        },
        complete: function () {
            loading.hide();

        }
    })
    setMenu([lnkFaireSimulation, lnkVoirSimulation, lnkTerminerSession]);
}

function terminerSession() {
    $.ajax({
        url: '/Pam/TerminerSession',
        type: 'POST',
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {

            content.html(data);
        },
        complete: function () {
            loading.hide();
        }
    })
    setMenu([lnkFaireSimulation, lnkVoirSimulation, lnkTerminerSession]);
}

function setMenu(show) {
    for (let i = 0; i < options.length; i++) {
        options[i].hide();
    }
    for (let i = 0; i < show.length; i++) {
        show[i].show();
    }
    
}

function retirerSimulation(N) {
    $.ajax({
        url: '/Pam/RetirerSimulation',
        type: 'POST',
        data: "num="+N,
        dataType: 'html',
        beforeSend: function () {
            loading.show();
        },
        success: function (data) {

            content.html(data);
        },
        complete: function () {
            loading.hide();
        }
    });
    setMenu([lnkRetourFormulaire, lnkTerminerSession]);
}

//au chargemetn du doc
$(document).ready(function () {
    //var culture = 'fr-FR';
    //Globalize.culture(culture);
    //recuperationdes differents compossant de la page
    loading = $("#loading");
    content = $("#content");

    lnkEnregistrerSimulation = $("#lnkEnregistrerSimulation");
    lnkEffacerSimulation = $("#lnkEffacerSimulation");
    lnkFaireSimulation = $("#lnkFaireSimulation");
    lnkRetourFormulaire = $("#lnkRetourFormulaire");
    lnkTerminerSession = $("#lnkTerminerSession");
    lnkVoirSimulation = $("#lnkVoirSimulation");

    options = [lnkFaireSimulation, lnkEffacerSimulation, lnkEnregistrerSimulation, lnkVoirSimulation, lnkTerminerSession, lnkRetourFormulaire];
    loading.hide();
    setMenu([lnkFaireSimulation, lnkVoirSimulation, lnkTerminerSession]);
});


