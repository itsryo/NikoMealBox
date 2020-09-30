// dom
var emptycartBtn = document.getElementById("emptycart");


// event
emptycartBtn.addEventListener('click', function (e) {
    e.preventDefault();
    setTimeout(function () {
        $("#alertmodal").modal("hide");
    }, 2000);
});