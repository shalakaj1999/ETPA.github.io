$(document).ready(function () { 
    InitializeToastMessage(); 
});

function ResetForm(form) {
    $(form).find(".field-validation-error").each(function () {
        $(this).html("");
        $(this).addClass("field-validation-valid");
        $(this).removeClass("field-validation-error");
    });

    $(form).trigger("reset");
}


function InitializeToastMessage() {

    var ToastWindow = "<div style='position: fixed; top: 100px; right: 20px; z-index:-1' class='mt-2'>";
    ToastWindow += "<div id='ToastWindow' class='toast toast-black' style='z-index:5000' role='alert' aria-live='assertive' aria-atomic='true' data-delay='2000'>";
    ToastWindow += "<div class='toast-titlebar d-flex justify-content-between align-items-center'>";
    ToastWindow += "<strong id='Title'>Title</strong>";
    ToastWindow += "<button type='button' class='toast-close' data-dismiss='toast' aria-label='Close'>";
    ToastWindow += "<span aria-hidden='true'>&times;</span>";
    ToastWindow += "</button>";
    ToastWindow += "</div >";
    ToastWindow += "<div id='Message' class='toast-body'>";
    ToastWindow += "Messenger is just like texting, but you don't have to pay for every message";
    ToastWindow += "</div>";
    ToastWindow += "</div >";
    ToastWindow += "</div >";

    $("#ToastContainer").append(ToastWindow);

    //$(ToastWindow).on('show.bs.toast', function () { 
    //    $("#ToastWindow").addClass("top-5000");
    //});

    //$(ToastWindow).on('hidden.bs.toast', function () {
    //    $("#ToastWindow").removeClass("top-5000");
    //});
     
}

function ShowToastMessage(Title, Message, Duration) {

    $("#ToastWindow").data("delay", Duration);
    $("#ToastWindow #Title").html(Title);
    $("#ToastWindow #Message").html(Message);

    $('#ToastWindow').toast('show');
}

