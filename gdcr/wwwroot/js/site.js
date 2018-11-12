// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function nextIteration(){
    $.ajax({
        url: '/Home/NextIteration',
        type: "POST",
        //dataType: 'json',
        success: function(){},
        error: function(xhr, status, error){
            console.log(error);
            console.log(xhr.error);
        }
    });
}