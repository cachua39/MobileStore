$(document).ready(function () {
    var inputFile = $("#fileInput").get(0);
    var imgPreview = $("#imgPreview").get(0);

    inputFile.addEventListener('change', function () {
        var reader = new FileReader();

        reader.onload = function (event) {
            imgPreview.src = event.target.result;
        }

        reader.readAsDataURL(inputFile.files[0]);
    });
})
