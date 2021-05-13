$(document).ready(function () { });
$("#imagesave").change(function () {
    
    var files = event.target.files;
    $("#imagesavetoshow").attr("src", window.URL.createObjectURL(files[0]));

});

$("#uploadimage").click(function () {
    var files = $("#imagesave").prop("files");
    var formData = new FormData();

    for (var i = 0; i < files.length; i++) {

        formData.append("file", files[i]);
    }

    var imageupload = {
        
        File: files
    };
    formData.append("File", imageupload);
    $.ajax(
        {
            type: "POST",
            url: "/Users/SaveImages",
            data: formData,
            processData: false,
            contentType: false,
            success: function () {
                alert("Congrats u upload");
            },
            error: function (data) {
                console.log("FAILED");
            }
    });
});


